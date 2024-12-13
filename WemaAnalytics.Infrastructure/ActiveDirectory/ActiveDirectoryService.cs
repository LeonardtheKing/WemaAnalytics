using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Net;
using WemaAnalytics.Domain.Contract;
using DirectoryEntry = System.DirectoryServices.DirectoryEntry;
namespace WemaAnalytics.Infrastructure.ActiveDirectory;

public class ActiveDirectoryService : IActiveDirectoryService
{
    private readonly ActiveDirectoryConfigOptions _options;
    private readonly ILogger<ActiveDirectoryService> _logger;

    public ActiveDirectoryService(IOptions<ActiveDirectoryConfigOptions> options, ILogger<ActiveDirectoryService> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    //public string GetDepartment(string staffEmail)
    //{
    //    _logger.LogInformation("Retrieving company name for staff email: {StaffEmail}", staffEmail);

    //    try
    //    {
    //        var directoryEntry = new DirectoryEntry(GetCurrentDomainPath());
    //        using var directorySearcher = BuildUserSearcher(directoryEntry);

    //        // Set the filter to find the specific user by email
    //        directorySearcher.Filter = $"(&(objectCategory=User)(objectClass=person)(mail={staffEmail}))";

    //        var searchResult = directorySearcher.FindOne();

    //        if (searchResult != null)
    //        {
    //            // Fetch the "company" property
    //            string companyName = GetProperty(searchResult, "description");

    //            if (!string.IsNullOrEmpty(companyName))
    //            {
    //                _logger.LogInformation("Company name retrieved for {StaffEmail}: {CompanyName}", staffEmail, companyName);
    //                return companyName;
    //            }
    //            else
    //            {
    //                _logger.LogWarning("Company name not found for staff email: {StaffEmail}", staffEmail);
    //                return string.Empty;
    //            }
    //        }

    //        _logger.LogWarning("No staff record found with email: {StaffEmail}", staffEmail);
    //        return string.Empty;
    //    }
    //    catch (LdapException ex)
    //    {
    //        _logger.LogError(ex, "LDAP error occurred while retrieving company name for email: {StaffEmail}", staffEmail);
    //        throw new LdapException(ex.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "An error occurred while retrieving company name for email: {StaffEmail}", staffEmail);
    //        throw new Exception(ex.Message);
    //    }
    //}


    public string GetDepartment(string staffEmail)
    {
        _logger.LogInformation("Retrieving company name for staff email: {StaffEmail}", staffEmail);

        const string ldapPath = "LDAP://172.27.4.83:389/DC=wemabank,DC=local"; // Replace with your actual LDAP path

        try
        {
            using (DirectoryEntry ldapConnection = new DirectoryEntry(ldapPath))
            {
                ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

                using (DirectorySearcher search = new DirectorySearcher(ldapConnection))
                {
                    search.Filter = $"(mail={staffEmail})";
                    search.PropertiesToLoad.Add("description");

                    SearchResult result = search.FindOne();

                    if (result != null && result.Properties.Contains("description"))
                    {
                        // Return the first value of the description property
                        return result.Properties["description"][0]?.ToString() ?? "No description available";
                    }
                    else
                    {
                        return "Description not found for the user.";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
            return "An error occurred while fetching the description.";
        }
    }



    public string GetCompanyName(string staffEmail)
    {
        _logger.LogInformation("Retrieving company name for staff email: {StaffEmail}", staffEmail);

        try
        {
            var directoryEntry = new DirectoryEntry(GetCurrentDomainPath());
            using var directorySearcher = BuildUserSearcher(directoryEntry);

            // Set the filter to find the specific user by email
            directorySearcher.Filter = $"(&(objectCategory=User)(objectClass=person)(mail={staffEmail}))";

            var searchResult = directorySearcher.FindOne();

            if (searchResult != null)
            {
                // Fetch the "company" property
                string companyName = GetProperty(searchResult, "company");

                if (!string.IsNullOrEmpty(companyName))
                {
                    _logger.LogInformation("Company name retrieved for {StaffEmail}: {CompanyName}", staffEmail, companyName);
                    return companyName;
                }
                else
                {
                    _logger.LogWarning("Company name not found for staff email: {StaffEmail}", staffEmail);
                    return string.Empty;
                }
            }

            _logger.LogWarning("No staff record found with email: {StaffEmail}", staffEmail);
            return string.Empty;
        }
        catch (LdapException ex)
        {
            _logger.LogError(ex, "LDAP error occurred while retrieving company name for email: {StaffEmail}", staffEmail);
            throw new LdapException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving company name for email: {StaffEmail}", staffEmail);
            throw new Exception(ex.Message);
        }
    }



    public bool AuthenticateStaff(string StaffEmail, string StaffPassword)
    {
        if (!string.IsNullOrEmpty(StaffEmail) && !StaffEmail.Contains("@wemabank.com"))
        {
            StaffEmail += "@wemabank.com";
        }

        string LDapServerIP = _options.LDapServerIP;
        int LDapServerPort = _options.LDapServerPort;

        try
        {
            LdapDirectoryIdentifier ldi = new(LDapServerIP, LDapServerPort);
            LdapConnection ldapConnection = new(ldi)
            {
                AuthType = AuthType.Basic
            };

            ldapConnection.SessionOptions.ProtocolVersion = 3;

            NetworkCredential nc = new(StaffEmail, StaffPassword);

            ldapConnection.Bind(nc);

            return true;
        }
        catch (LdapException ex)
        {
            _logger.LogError($"An LdapException was thrown :: {ex.Message}\n");
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError($"An LdapException was thrown :: {ex.Message}\n");
            return false;
        }
    }

    public string GetCurrentDomainPath()
    {
        _logger.LogInformation("Retrieving current domain path from Active Directory");

        try
        {
            DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://RootDSE");
            string domainPath = "LDAP://" + directoryEntry.Properties["defaultNamingContext"][0].ToString();
            _logger.LogInformation("Current domain path: {DomainPath}", domainPath);
            return domainPath;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving the current domain path");
            throw;
        }
    }

    public bool DoesEmailExist(string staffEmail)
    {
        // _logger.LogInformation("Checking if email exists in Active Directory: {StaffEmail}", staffEmail);

        try
        {
             DirectoryEntry directoryEntry = new DirectoryEntry(GetCurrentDomainPath());
            using var directorySearcher = BuildUserSearcher(directoryEntry);
            directorySearcher.Filter = $"(&(objectCategory=User)(objectClass=person)(mail={staffEmail}))";

            _logger.LogInformation("Checking if email exists in Active Directory: {StaffEmail}", staffEmail);

            var searchResult = directorySearcher.FindOne();

            var result = JsonConvert.SerializeObject(searchResult);

            _logger.LogInformation("Search Result Serialized: {Result}", result);

            bool emailExists = searchResult != null;
            _logger.LogInformation("Email {StaffEmail} exists: {Exists}", staffEmail, emailExists);
            return emailExists;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while checking email existence in Active Directory: {StaffEmail}", staffEmail);
            return false;
        }
    }

   

    public StaffLookUpDto LookUpWemaStaff(string staffEmail)
    {
        _logger.LogInformation("Looking up Wema staff with email: {StaffEmail}", staffEmail);

        try
        {
             var directoryEntry = new DirectoryEntry(GetCurrentDomainPath());
            using var directorySearcher = BuildUserSearcher(directoryEntry);
            directorySearcher.Filter = $"(&(objectCategory=User)(objectClass=person)(mail={staffEmail}))";
            var searchResult = directorySearcher.FindOne();

            if (searchResult != null)
            {
                var staffLookUpDto = new StaffLookUpDto
                {
                    No = GetProperty(searchResult, "sn"),
                    Name = GetProperty(searchResult, "name"),
                    Email = GetProperty(searchResult, "mail"),
                    PrincipalName = GetProperty(searchResult, "userPrincipalName")
                };
                _logger.LogInformation("Wema staff found: {StaffLookUpDto}", staffLookUpDto);
                return staffLookUpDto;
            }

            _logger.LogWarning("No Wema staff found with email: {StaffEmail}", staffEmail);
            return null;
        }
        catch (LdapException ex)
        {
            _logger.LogError(ex, "LDAP error occurred while looking up Wema staff with email: {StaffEmail}", staffEmail);
            throw new LdapException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while looking up Wema staff with email: {StaffEmail}", staffEmail);
            throw new Exception(ex.Message);
        }
    }

    private static DirectorySearcher BuildUserSearcher(DirectoryEntry directoryEntry)
    {
        var directorySearcher = new DirectorySearcher(directoryEntry);
        directorySearcher.PropertiesToLoad.AddRange(new[]
        {
                "name",
                "mail",
                "givenname",
                "sn",
                "userPrincipalName",
                "distinguishedName",
                "staffno",
                "company"
            });
        return directorySearcher;
    }

    private string GetProperty(SearchResult searchResult, string propertyName)
    {
        var property = searchResult.Properties[propertyName];
        return property != null && property.Count > 0 ? property[0].ToString() : string.Empty;
    }


}
