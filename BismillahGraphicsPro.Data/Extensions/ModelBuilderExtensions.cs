using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BismillahGraphicsPro.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedRoleData(this ModelBuilder builder)
        {
            var authorityId = "A0456563-F978-4135-B563-97F23EA02FDA";
            // any guid, but nothing is against to use the same one
            var ids = new Dictionary<string, string>(){
                    { "25205E51-C7F6-43E5-927A-8074AF61B966",UserType.Authority.ToString()},
                    { "e202e807-4b4f-4c78-983a-2ad06e3f7012",UserType.AccountCreate.ToString()},
                    { "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4",UserType.Admin.ToString()},
                    { "4d4fb0a3-4734-4802-a027-9c9b2ad7dae7",UserType.SubAdmin.ToString()},
                    { "31f91532-c149-4248-a844-f7601c24b740",UserType.BalanceSheet.ToString()},
                    { "ae25c232-3435-4239-901d-0e2d3e4069c9",UserType.Deposit.ToString()},
                    { "446d16c5-000c-4099-b553-23696a5284ec",UserType.Expanse.ToString()},
                    { "b1280e80-8ec6-48fb-8580-6f2e57db8d58",UserType.ExpenseCategory.ToString()},
                    { "22b877e9-56c5-4281-92a7-d336cd4382a4",UserType.MeasurementUnit.ToString()},
                    { "3e0d4db7-80a0-49a9-8d8d-116cc5c9fc83",UserType.NetSummery.ToString()},
                    { "897ea03e-f328-4a9e-91bc-247d9dcc6aa9",UserType.PaymentSummery.ToString()},
                    { "5a52c2fc-6d6b-478f-9fce-ba46abaea1f2",UserType.Product.ToString()},
                    { "bbd6cebc-741d-4bfb-852b-204d5f623a86",UserType.ProductCategory.ToString()},
                    { "a9c6f8da-3e48-47a9-b355-6107b297ae10",UserType.ProductSummery.ToString()},
                    { "9d037f79-ec3e-481d-8e4f-acf86a3a2f5c",UserType.PurchaseRecord.ToString()},
                    { "bc6a04f9-6984-4755-8573-016047310f8e",UserType.ReportDailyCash.ToString()},
                    { "7210cd36-9476-4a49-ad86-f2bfb88c4e6d",UserType.ReportExpense.ToString()},
                    { "93c4b0d6-0d82-410f-adb1-fb4aba413a8e",UserType.ReportIncome.ToString()},
                    { "aceacd97-893e-464a-9f94-9e19d8984764",UserType.ReportSelling.ToString()},
                    { "5c8eda73-94a0-49e6-b4ad-63282d09e3a7",UserType.ReportVendor.ToString()},
                    { "27c3d924-cac0-4aae-8076-eb395964d547",UserType.SellingRecord.ToString()},
                    { "5d0106d1-8900-4630-aec2-0b016f55d092",UserType.Withdraw.ToString()},
                    { "60482875-1078-4F65-BBBE-5C68836045A6",UserType.TransactionLogs.ToString()},
                    { "D68419DF-4B85-4704-89F7-AC889C750493",UserType.Selling.ToString()},
                    { "9EB47A31-EFC6-43D4-B204-538FC3F280F3",UserType.Sms.ToString()},
                    { "D093C085-938C-4A7E-84B8-9CA5559850AE",UserType.SubAdminList.ToString()},
                    { "54DAEA5E-86D7-4EBE-9191-A170B37CD883",UserType.SubAdminPageAccess.ToString()},
                    { "86DD9E91-0928-497A-B226-FA346F7EA656",UserType.SubAdminSignUp.ToString()},
                    { "3DC9AC78-8A93-498A-8D04-D69C0294B4C4",UserType.Supplier.ToString()},
                    { "70453879-6A75-48B8-8ED2-8B86DEC40798",UserType.Vendor.ToString()},
            };
            builder.Entity<IdentityRole>().HasData(
                ids.Select(i=> 
                new IdentityRole
                {
                    Id = i.Key,
                    Name = i.Value,
                    NormalizedName = i.Value.ToUpper(),
                    ConcurrencyStamp = i.Key
                }).ToArray()
            );


            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = authorityId,
                UserName = UserType.Authority.ToString(),
                NormalizedUserName = UserType.Authority.ToString().ToUpper(),
                Email = "Authority@gmail.com",
                NormalizedEmail = "AUTHORITY@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDch3arYEB9dCAudNdsYEpVX7ryywa8f3ZIJSVUmEThAI50pLh9RyEu7NjGJccpOog==",
                SecurityStamp = string.Empty,
                LockoutEnabled = true,
                ConcurrencyStamp = authorityId
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ids.First().Key,
                UserId = authorityId
            });

            builder.Entity<Registration>().HasData(new Registration
            {
                RegistrationId = 1,
                UserName = "Authority",
                Type = UserType.Authority,
                Name = "Authority", 
                Ps = "Admin_121"
            });
        }
    }
}
