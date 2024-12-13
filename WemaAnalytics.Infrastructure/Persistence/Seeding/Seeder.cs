﻿using Microsoft.AspNetCore.Identity;
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
                        StaffId = "",
                        FirstName = "Akinkunmi",
                        LastName = "Okunola",
                        Email = "Akinkunmi.Okunola@wemabank.com",
                        NormalizedEmail = "AKINKUNMI.OKUNOLA@WEMABANK.COM",
                        UserName = "Akinkunmi.Okunola@wemabank.com",
                        NormalizedUserName = "AKINKUNMI.OKUNOLA@WEMABANK.COM",
                        PhoneNumber = "+2347082018781",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id ="126827cb-183f-42c0-9976-055a95000677",
                         StaffId = "",
                        FirstName = "Abisola",
                        LastName = "Smith",
                        Email = "Abisola.Smith@wemabank.com",
                        NormalizedEmail = "ABISOLA.SMITH@WEMABANK.COM",
                        UserName = "Abisola.Smith@wemabank.com",
                        NormalizedUserName = "ABISOLA.SMITH@WEMABANK.COM",
                        PhoneNumber = "+234708201878",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },
                        new ApplicationUser
                        {
                        Id ="c3c8409d-98ee-4155-b7d3-cba3672817bf",
                        StaffId = "",
                        FirstName = "Folasade",
                        LastName = "Adeyemo",
                        Email = "Folasade.Adeyemo@wemabank.com",
                        NormalizedEmail = "FOLASADE.ADEYEMO@WEMABANK.COM",
                        UserName = "Folasade.Adeyemo@wemabank.com",
                        NormalizedUserName = "FOLASADE.ADEYEMO@WEMABANK.COM",
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
                        StaffId ="10002",
                        FirstName = "Evelyn",
                        LastName = "Ita",
                        Email = "Evelyn.Ita@wemabank.com",
                        NormalizedEmail = "EVELYN.ITA@WEMABANK.COM",
                        UserName = "Evelyn.Ita@wemabank.com",
                        NormalizedUserName = "EVELYN.ITA@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "63fea3eh-b18e-43c2-889e-541b2fa1abf6",
                        StaffId ="10003",
                        FirstName = "Deborah",
                        LastName = "Aladi",
                        Email = "Deborah.Aladi@wemabank.com",
                        NormalizedEmail = "DEBORAH.ALADI@WEMABANK.COM",
                        UserName = "Deborah.Aladi@wemabank.com",
                        NormalizedUserName = "DEBORAH.ALADI@WEMABANK.COM",
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
                        StaffId ="10005",
                        FirstName = "Oluwasayo",
                        LastName = "Oyenuga",
                        Email = "oluwasayo.oyenuga@wemabank.com",
                        NormalizedEmail = "OLUWASAYO.OYENUGA@WEMABANK.COM",
                        UserName = "oluwasayo.oyenuga@wemabank.com",
                        NormalizedUserName = "OLUWASAYO.OYENUGA@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "d554df9k-7f52-4279-80e9-3dbf79ca8c1a",
                        StaffId ="10006",
                        FirstName = "Stephen",
                        LastName = "Nathaniel",
                        Email = "stephen.nathaniel@wemabank.com",
                        NormalizedEmail = "STEPHEN.NATHANIEL@WEMABANK.COM",
                        UserName = "stephen.nathaniel@wemabank.com",
                        NormalizedUserName = "STEPHEN.NATHANIEL@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "126827cl-183f-42c0-9976-055a95000677",
                        StaffId ="10007",
                        FirstName = "Jennifer",
                        LastName = "Egwuatu",
                        Email = "Jennifer.Egwuatu@wemabank.com",
                        NormalizedEmail = "JENNIFER.EGWUATU@WEMABANK.COM",
                        UserName = "Jennifer.Egwuatu@wemabank.com",
                        NormalizedUserName = "JENNIFER.EGWUATU@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "dc95808m-bffb-462b-98ac-0f886887144d",
                        StaffId ="10008",
                        FirstName = "Christopher",
                        LastName = "Eneze",
                        Email = "Christopher.Eneze@wemabank.com",
                        NormalizedEmail = "CHRISTOPHER.ENEZE@WEMABANK.COM",
                        UserName = "Christopher.Eneze@wemabank.com",
                        NormalizedUserName = "CHRISTOPHER.ENEZE@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                        new ApplicationUser
                        {
                        Id = "dc95808m-bffb-462b-98ac-0f886887144c",
                        StaffId ="10009",
                        FirstName = "Christopher",
                        LastName = "Adekunle",
                        Email = "Christopher.Adekunle@wemabank.com",
                        NormalizedEmail = "CHRISTOPHER.ADEKUNLE@WEMABANK.COM",
                        UserName = "Christopher.Adekunle@wemabank.com",
                        NormalizedUserName = "CHRISTOPHER.ADEKUNLE@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },
                         new ApplicationUser
                        {
                        Id = "a3f1d78e-49c5-4b7e-93e4-8a1b2d47f92d",
                        StaffId ="10010",
                        FirstName = "Chikwado",
                        LastName = "Ezenwaka",
                        Email = "chikwado.ezenwaka@wemabank.com",
                        NormalizedEmail = "CHIKWADO.EZENWAKA@WEMABANK.COM",
                        UserName = "Chikwado.Ezenwaka@wemabank.com",
                        NormalizedUserName = "CHIKWADO.EZENWAKA@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },
                          new ApplicationUser
                        {
                        Id = "h4f1d78e-49c5-4b7e-93e4-8a1b2d47f92d",
                        StaffId ="10011",
                        FirstName = "Trust",
                        LastName = "Ayeni",
                        Email = "Trust.Ayeni@wemabank.com",
                        NormalizedEmail = "TRUST.AYENI@WEMABANK.COM",
                        UserName = "Trust.Ayeni@wemabank.com",
                        NormalizedUserName = "TRUST.AYENI@WEMABANK.COM",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                        },
                           new ApplicationUser
                        {
                        Id = "j3f1d78e-49c5-4b7e-93e4-8a1b2d47f92d",
                        StaffId ="10012",
                        FirstName = "Moyinoluwa",
                        LastName = "Abiodun",
                        Email = "Moyinoluwa.Abiodun@wemabank.com",
                        NormalizedEmail = "MOYINOLUWA.ABIODUN@WEMABANK.COM",
                        UserName = "Moyinoluwa.Abiodun@wemabank.com",
                        NormalizedUserName = "MOYINOLUWA.ABIODUN@WEMABANK.COM",
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
