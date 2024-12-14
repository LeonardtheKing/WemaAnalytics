using Microsoft.AspNetCore.Identity;
using System.Data;

namespace WemaAnalytics.Infrastructure.Persistence.Seeding;

public static class Seeder
{
    public static async Task SeedData(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<SqlDbContext>();

            if (!dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            List<string> roles = new List<string>
            {
                Roles.ROLE_ADMIN,
                Roles.ROLE_ACCOUNT_OFFICER,
                Roles.ROLE_BRANCH_MANAGER,
                Roles.ROLE_ZONE_HEAD,
                Roles.ROLE_REGION_HEAD,
                Roles.ROLE_DIRECTORATE_HEAD,
                Roles.ROLE_CLUSTER_HEAD
            };


            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }
            }

            var users = new List<ApplicationUser>
            {
            //Instantiating i User and it properties
                        new ApplicationUser{
                        Id = "36e318aa-6d02-46d9-8048-3e2a8182a6c3",
                        StaffId = "S05526",
                        FirstName = "Olubunmi",
                        LastName = "Ogunbo",
                        Email = "Olubunmi.Ogunbo@wemabank.com",
                        NormalizedEmail = "OLUBUNMI.OGUNBO@WEMABANK.COM",
                        UserName = "Olubunmi.Ogunbo@wemabank.com",
                        NormalizedUserName = "OLUBUNMI.OGUNBO@WEMABANK.COM",
                        PhoneNumber = "+2347082018781",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id ="126827cb-183f-42c0-9976-055a95000677",
                         StaffId = "S07099",
                        FirstName = "Ismaila",
                        LastName = "Sowunmi",
                        Email = "Ismaila.Sowunmi@wemabank.com",
                        NormalizedEmail = "ISMAILA.SOWUNMI@WEMABANK.COM",
                        UserName = "Ismaila.Sowunmi@wemabank.com",
                        NormalizedUserName = "ISMAILA.SOWUNMI@WEMABANK.COM",
                        PhoneNumber = "+234708201878",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },
                        new ApplicationUser
                        {
                        Id ="c3c8409d-98ee-4155-b7d3-cba3672817bf",
                        StaffId = "S09995",
                        FirstName = "Ayotunde",
                        LastName = "Badetan",
                        Email = "Ayotunde.Badetan@wemabank.com",
                        NormalizedEmail = "AYOTUNDE .BADETAN@WEMABANK.COM",
                        UserName = "Ayotunde.Badetan@wemabank.com",
                        NormalizedUserName = "AYOTUNDE .BADETAN@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "6d63d83e-a938-44e4-bf31-d65624dc85d0",
                        StaffId = "10000",
                        FirstName = "Praise",
                        LastName = "Omoniyi",
                        Email = "Praise.Omoniyi@wemabank.com",
                        NormalizedEmail = "PRAISE.OMONIYI@WEMABANK.COM",
                        UserName = "Praise.Omoniyi@wemabank.com",
                        NormalizedUserName = "PRAISE.OMONIYI@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        //new ApplicationUser
                        //{
                        //Id = "3d30875f-4ce8-4794-ae96-6b8d16df7d9a",
                        //StaffId = "S01158",
                        //FirstName = "Izuchukwu",
                        //LastName = "Okorie",
                        //Email = "Izuchukwu.Okorie@wemabank.com",
                        //NormalizedEmail = "IZUCHUKWU.OKORIE@WEMABANK.COM",
                        //UserName = "Izuchukwu.Okorie@wemabank.com",
                        //NormalizedUserName = "IZUCHUKWU.OKORIE@WEMABANK.COM",
                        //PhoneNumber = "+111111111111",
                        //EmailConfirmed = true,
                        //SecurityStamp = Guid.NewGuid().ToString("D")
                        //},

                        new ApplicationUser
                        {
                        Id = "1303a56g-9965-4b90-a6ed-034b84f8231f",
                        StaffId ="S09494",
                        FirstName = "Iroro",
                        LastName = "Osawota",
                        Email = "Iroro.Osawota@wemabank.com",
                        NormalizedEmail = "IRORO.OSAWOTA@WEMABANK.COM",
                        UserName = "Iroro.Osawota@wemabank.com",
                        NormalizedUserName = "IRORO.OSAWOTA@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "63fea3eh-b18e-43c2-889e-541b2fa1abf6",
                        StaffId ="S09433",
                        FirstName = "Nelson",
                        LastName = "chukwudebelu",
                        Email = "Nelson.chukwudebelu@wemabank.com",
                        NormalizedEmail = "NELSON.CHUKWUDEBELU@WEMABANK.COM",
                        UserName = "Nelson.chukwudebelu@wemabank.com",
                        NormalizedUserName = "NELSON.CHUKWUDEBELU@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "873f649i-1590-480b-a5f3-488c364485b9",
                        StaffId ="10004",
                        FirstName = "Ololade",
                        LastName = "Williams",
                        Email = "ololade.williams@wemabank.com",
                        NormalizedEmail = "OLOLADE.WILLIAMS@WEMABANK.COM",
                        UserName = "ololade.williams@wemabank.com",
                        NormalizedUserName = "OLOLADE.WILLIAMS@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "6c9fd36j-f1b9-4d86-a773-02461cbd3341",
                        StaffId ="S09405",
                        FirstName = "Christianah",
                        LastName = "Owoniyi",
                        Email = "owoniyi.christianah@wemabank.com",
                        NormalizedEmail = "OWONITI.CHRISTIANAH@WEMABANK.COM",
                        UserName = "owoniyi.christianah@wemabank.com",
                        NormalizedUserName = "CHRISTIANAH.OWONIYI@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "d554df9k-7f52-4279-80e9-3dbf79ca8c1a",
                        StaffId ="S010153",
                        FirstName = "Ololade",
                        LastName = "lawal",
                        Email = "Ololade.lawal@wemabank.com",
                        NormalizedEmail = "OLOLADE.LAWAL@WEMABANK.COM",
                        UserName = "Ololade.lawal@wemabank.com",
                        NormalizedUserName = "OLOLADE.LAWAL@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "126827cl-183f-42c0-9976-055a95000677",
                        StaffId ="S010142",
                        FirstName = "Yetunde",
                        LastName = "Adekola",
                        Email = "Yetunde.Adekola@wemabank.com",
                        NormalizedEmail = "YETUNDE.ADEKOLA@WEMABANK.COM",
                        UserName = "Yetunde.Adekola@wemabank.com",
                        NormalizedUserName = "YETUNDE .ADEKOLA@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                       
                           new ApplicationUser
                        {
                        Id = "j3f1d78e-49c5-4b7e-93e4-8a1b2d47f92d",
                        StaffId ="S010170",
                        FirstName = "Folabomi",
                        LastName = "Onasanya",
                        Email = "Folabomi.Onasanya@wemabank.com",
                        NormalizedEmail = "FOLABOMI.ONASANYA@WEMABANK.COM",
                        UserName = "folabomi.onasanya@wemabank.com",
                        NormalizedUserName = "FOLABOMI.ONASANYA@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        }
                            };

            foreach (var user in users)
            {
                var existingUser = await userManager.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    var result = await userManager.CreateAsync(user, "DefaultPassword123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roles[0]); // Add to the ADMIN role
                    }
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
