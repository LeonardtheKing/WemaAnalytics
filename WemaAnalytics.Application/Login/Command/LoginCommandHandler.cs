using System.Net.WebSockets;
using System.Text.RegularExpressions;
using Uplift.Application.Constants;
using WemaAnalytics.Domain.Contract;

namespace WemaAnalytics.Application.Login.Command;

public class LoginCommandHandler(
    IJwtService jwtManager,
    IActiveDirectoryService activeDirectoryService,
    //IApplicationUserRepository users,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager
    ) : IRequestHandler<LoginCommand, BaseResponse<LoginResponse>>
{
    public async Task<BaseResponse<LoginResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var email = command.Email.ToLower();
        var user = await userManager.FindByEmailAsync(email);
        
        var staffId  = activeDirectoryService.GetCompanyName(email);
        var position = activeDirectoryService.GetDepartment(email);


        if (string.IsNullOrEmpty(staffId) || staffId==null)
        {
            return BaseResponse<LoginResponse>.Unauthorized("User not found in the Active Directory");
        }

        // Extract UserId from the token

        if (user != null)
        {
            // Check if the user is locked out
            if (await userManager.IsLockedOutAsync(user))
            {
               // return new BaseResponse<LoginResponse>("You have been locked out. Please try again later.");
                return new BaseResponse<LoginResponse>();
            }
        }
        bool isAuthenticated = false;

        try
        {
            isAuthenticated = activeDirectoryService.AuthenticateStaff(email, command.Password);
        }
        catch (UnauthorizedAccessException)
        {
            if (user != null)
            {
                await userManager.AccessFailedAsync(user);
                if (await userManager.IsLockedOutAsync(user))
                {
                    return  BaseResponse<LoginResponse>.    Unauthorized("You have been locked out. Please try again later.");
                }
            }
            return  BaseResponse<LoginResponse>.Unauthorized("Password is incorrect.");
        }
        catch (Exception ex)
        {
            return  BaseResponse<LoginResponse>.Unauthorized($"An error occurred: {ex.Message}");
        }

        if (!isAuthenticated)
        {
            if (user != null)
            {
                await userManager.AccessFailedAsync(user);
                if (await userManager.IsLockedOutAsync(user))
                {
                    //return new BaseResponse<LoginResponse>("You have been locked out. Please try again later.");
                    return BaseResponse<LoginResponse>.Unauthorized("You have been locked out. Please try again later.");
                }
            }
            return  BaseResponse<LoginResponse>.Unauthorized("User Authentication Failed");
        }

        // Reset failed attempts if the user is authenticated successfully via Active Directory
        if (user != null)
        {
            await userManager.ResetAccessFailedCountAsync(user);
        }

        // Check if the user exists in the local database, if not, create a new user
        if (user == null)
        {
            var nameList = email.Split('@')[0].Split('.');
            var firstName = nameList.Length > 0 ? UpperCaseFirstChar(nameList[0]) : "";
            var lastName = nameList.Length > 1 ? UpperCaseFirstChar(nameList[1]) : "";

            user = new ApplicationUser
            {
                StaffId = staffId,
                FirstName = firstName,
                LastName = lastName,
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),

            };

            var createdUser = await userManager.CreateAsync(user);
            if (!createdUser.Succeeded)
            {
                var errorString = "User Creation Failed Because: ";
                foreach (var error in createdUser.Errors)
                {
                    errorString += " # " + error.Description;
                }
                // return new BaseResponse<LoginResponse>(errorString);
                return BaseResponse<LoginResponse>.Unauthorized(errorString);
            }

            await AssignAccountOfficerRole(user, position);

            await userManager.AddToRoleAsync(user, Roles.ROLE_ADMIN);
            
        }

        // Manually create the authentication ticket and JWT token
        var userRoles = await userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("JWTID", Guid.NewGuid().ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("StaffId", user.StaffId),
            };

        foreach (var role in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        // If you want to return a comma-separated string of roles
        var token = jwtManager.GenerateJWT(authClaims);
        var refreshToken = await jwtManager.GenerateRefreshToken();
        var name = $"{user.FirstName} {user.LastName}";
        var userRole = userRoles.FirstOrDefault();
        var loginResponse = new LoginResponse(name, email, token, refreshToken, userRole, staffId, position);

        return   BaseResponse<LoginResponse>.Success(loginResponse,"Login succesful",true);
    }

    private static string UpperCaseFirstChar(string text) =>
       Regex.Replace(text, "^[a-z]", m => m.Value.ToUpper());

    private   async Task AssignAccountOfficerRole(ApplicationUser user, string accountOfficer)
    {
        if (string.IsNullOrWhiteSpace(accountOfficer))
            return;

        // Remove all spaces
        var normalizedAccountOfficer = accountOfficer.Replace(" ", string.Empty, StringComparison.OrdinalIgnoreCase);

        // Check if it contains "RMO" or "RelationshipManagementOfficer"
        if (normalizedAccountOfficer.Contains("RMO", StringComparison.OrdinalIgnoreCase) ||
            normalizedAccountOfficer.Contains("RelationshipManagementOfficer", StringComparison.OrdinalIgnoreCase))
        {
            await userManager.AddToRoleAsync(user, Roles.ROLE_ACCOUNT_OFFICER);
        }
    }



}
