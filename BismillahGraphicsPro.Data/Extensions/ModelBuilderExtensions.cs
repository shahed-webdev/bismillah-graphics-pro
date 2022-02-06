using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BismillahGraphicsPro.Data
{
    public static class ModelBuilderExtensions
    {
        public static Dictionary<string, string> Ids { get; set; } = new()
        {
            { UserType.Account.ToString(), "fb76a482-3d73-4e28-9155-581a1a2cbea4" },
            { UserType.Admin.ToString(), "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4" },
            { UserType.Authority.ToString(), "25205E51-C7F6-43E5-927A-8074AF61B966" },
            { UserType.BalanceSheet.ToString(), "1d844081-a5fc-4674-a767-4e835e591740" },
            { UserType.DailyCash.ToString(), "293de564-7caf-4686-9aea-f2dbc69b9072" },
            { UserType.Expense.ToString(), "f1fb596e-fc07-46f8-ae1d-ebbde38e5994" },
            { UserType.ExpenseReport.ToString(), "cc64a971-f6e8-4811-8c3f-a9e2e944e21e" },
            { UserType.MeasurementUnit.ToString(), "4b48934d-ef26-4289-a038-e7313736126f" },
            { UserType.Net.ToString(), "878cad39-1257-44cb-9c2d-21da49e4e34d" },
            { UserType.Products.ToString(), "d4d25cbe-c54b-4982-ac79-a45c562faf8d" },
            { UserType.ProductCategory.ToString(), "1c638e1e-597c-4814-94d2-49d8f81e775e" },
            { UserType.ProductSales.ToString(), "c5f489f6-6f53-473b-9c47-d087ce3e9cd5" },
            { UserType.Purchase.ToString(), "492d5817-5fd2-4342-8f84-4d5798aa5e01" },
            { UserType.PurchaseDueReport.ToString(), "3eb3b3a9-51d9-4dd8-b9d9-7ed710ca6fce" },
            { UserType.PurchasePaymentReport.ToString(), "632f139d-4827-413e-8ede-45d3ba8f9724" },
            { UserType.Reset.ToString(), "59adebcb-f095-45a4-bae0-cc574d810106" },
            { UserType.Selling.ToString(), "d8a9c270-f027-4078-a71c-1d6c7372ff53" },
            { UserType.SellingDueReport.ToString(), "d28f2f6f-eea6-415e-afec-52cacafe7c7d" },
            { UserType.SellingPaymentReport.ToString(), "48f381bf-e07a-4846-b336-b395d9e755ea" },
            { UserType.SellingReport.ToString(), "06f359fa-68bf-40f6-a112-fc599511b145" },
            { UserType.SentRecord.ToString(), "a3e4480c-f381-4b34-9ab8-b0f3db05b724" },
            { UserType.SmsSingle.ToString(), "299dd7bc-f8f4-42e2-b129-607d774bf983" },
            { UserType.SmsVendor.ToString(), "8382e629-ac39-46ed-816e-0fe9275e3554" },
            { UserType.StockReport.ToString(), "bec93436-98fd-44fe-bcd3-00f3a9cf0b3a" },
            { UserType.SubAdmin.ToString(), "4d4fb0a3-4734-4802-a027-9c9b2ad7dae7" },
            { UserType.SubAdminList.ToString(), "1bb0d758-5506-43f5-b6a0-a6b3b4ee8129" },
            { UserType.SubAdminPageAccess.ToString(), "058e2f01-67eb-4dcb-8eab-99402d0c3643" },
            { UserType.SubAdminSignUp.ToString(), "415afdc1-04c0-4e7c-8a38-3daeab8f2e10" },
            { UserType.Suppliers.ToString(), "cb683688-df12-4127-979b-d6b1fd8eddda" },
            { UserType.TransactionLog.ToString(), "4120700d-198a-4817-9987-37077ba86160" },
            { UserType.Vendors.ToString(), "29a30973-7b5c-4a18-80ed-ab222e548f1e" }
        };

        public static void SeedRoleData(this ModelBuilder builder)
        {
            var authorityId = "A0456563-F978-4135-B563-97F23EA02FDA";
            // any guid, but nothing is against to use the same one
            //  var ids = 

            builder.Entity<IdentityRole>().HasData(
                Ids.Select(i =>
                    new IdentityRole
                    {
                        Id = i.Value,
                        Name = i.Key,
                        NormalizedName = i.Key.ToUpper(),
                        ConcurrencyStamp = i.Value
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
                RoleId = Ids[UserType.Authority.ToString()],
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

        public static void SeedLinkCategoryData(this ModelBuilder builder)
        {
            builder.Entity<PageLinkCategory>().HasData(
                new PageLinkCategory
                {
                    LinkCategoryId = 1,
                    Category = "Account",
                    IconClass = "fas fa-file-invoice-dollar",
                    Sn = 1
                },
                new PageLinkCategory
                {
                    LinkCategoryId = 2,
                    Category = "Product",
                    IconClass = "fas fa-shopping-bag",
                    Sn = 2
                },
                new PageLinkCategory
                {
                    LinkCategoryId = 3,
                    Category = "Purchase",
                    IconClass = "fas fa-user-tie",
                    Sn = 3
                },
                new PageLinkCategory
                {
                    LinkCategoryId = 4,
                    Category = "Selling",
                    IconClass = "fas fa-shopping-bag",
                    Sn = 4
                },
                new PageLinkCategory
                {
                    LinkCategoryId = 5,
                    Category = "Expense",
                    IconClass = "fas fa-chart-pie",
                    Sn = 5
                },
                new PageLinkCategory
                {
                    LinkCategoryId = 6,
                    Category = "Report",
                    IconClass = "fas fa-file-alt",
                    Sn = 6
                },
                new PageLinkCategory
                {
                    LinkCategoryId = 7,
                    Category = "SMS",
                    IconClass = "fas fa-sms",
                    Sn = 7
                },
                new PageLinkCategory
                {
                    LinkCategoryId = 8,
                    Category = "Sub-Admin",
                    IconClass = "fas fa-user-shield",
                    Sn = 8
                },
                new PageLinkCategory
                {
                    LinkCategoryId = 9,
                    Category = "Reset",
                    IconClass = "fas fa-trash-restore",
                    Sn = 9
                }
            );
        }

        public static void SeedLinkData(this ModelBuilder builder)
        {
            builder.Entity<PageLink>().HasData(
                new PageLink
                {
                    LinkId = 1,
                    LinkCategoryId = 1,
                    RoleId = Ids[UserType.Account.ToString()],
                    Controller = "Account",
                    Action = "Index",
                    Title = "Account List",
                    Sn = 1
                },
                new PageLink
                {
                    LinkId = 2,
                    LinkCategoryId = 1,
                    RoleId = Ids[UserType.BalanceSheet.ToString()],
                    Controller = "Account",
                    Action = "balanceSheet",
                    Title = "Balance Sheet",
                    Sn = 2
                },
                new PageLink
                {
                    LinkId = 3,
                    LinkCategoryId = 1,
                    RoleId = Ids[UserType.TransactionLog.ToString()],
                    Controller = "Account",
                    Action = "TransactionLog",
                    Title = "Transaction Logs",
                    Sn = 3
                },
                new PageLink
                {
                    LinkId = 4,
                    LinkCategoryId = 2,
                    RoleId = Ids[UserType.MeasurementUnit.ToString()],
                    Controller = "Product",
                    Action = "measurementUnit",
                    Title = "Measurement Unit",
                    Sn = 1
                },
                new PageLink
                {
                    LinkId = 5,
                    LinkCategoryId = 2,
                    RoleId = Ids[UserType.ProductCategory.ToString()],
                    Controller = "Product",
                    Action = "Category",
                    Title = "Category",
                    Sn = 2
                },
                new PageLink
                {
                    LinkId = 6,
                    LinkCategoryId = 2,
                    RoleId = Ids[UserType.Products.ToString()],
                    Controller = "Product",
                    Action = "Index",
                    Title = "Products",
                    Sn = 3
                },
                new PageLink
                {
                    LinkId = 7,
                    LinkCategoryId = 2,
                    RoleId = Ids[UserType.StockReport.ToString()],
                    Controller = "Product",
                    Action = "stockReport",
                    Title = "Stock Report",
                    Sn = 4
                },
                new PageLink
                {
                    LinkId = 8,
                    LinkCategoryId = 3,
                    RoleId = Ids[UserType.Suppliers.ToString()],
                    Controller = "purchase",
                    Action = "suppliers",
                    Title = "Suppliers",
                    Sn = 1
                },
                new PageLink
                {
                    LinkId = 9,
                    LinkCategoryId = 3,
                    RoleId = Ids[UserType.Purchase.ToString()],
                    Controller = "purchase",
                    Action = "Index",
                    Title = "Purchase",
                    Sn = 2
                },
                new PageLink
                {
                    LinkId = 10,
                    LinkCategoryId = 3,
                    RoleId = Ids[UserType.Purchase.ToString()],
                    Controller = "purchase",
                    Action = "records",
                    Title = "Purchase Invoice",
                    Sn = 3
                },
                new PageLink
                {
                    LinkId = 11,
                    LinkCategoryId = 3,
                    RoleId = Ids[UserType.PurchasePaymentReport.ToString()],
                    Controller = "purchase",
                    Action = "paymentReport",
                    Title = "Payment Report",
                    Sn = 4
                },
                new PageLink
                {
                    LinkId = 12,
                    LinkCategoryId = 3,
                    RoleId = Ids[UserType.PurchaseDueReport.ToString()],
                    Controller = "purchase",
                    Action = "dueReport",
                    Title = "Due Report",
                    Sn = 5
                },
                new PageLink
                {
                    LinkId = 13,
                    LinkCategoryId = 4,
                    RoleId = Ids[UserType.Vendors.ToString()],
                    Controller = "Selling",
                    Action = "vendors",
                    Title = "Vendors",
                    Sn = 1
                },
                new PageLink
                {
                    LinkId = 14,
                    LinkCategoryId = 4,
                    RoleId = Ids[UserType.Selling.ToString()],
                    Controller = "Selling",
                    Action = "Index",
                    Title = "Selling",
                    Sn = 2
                },
                new PageLink
                {
                    LinkId = 15,
                    LinkCategoryId = 4,
                    RoleId = Ids[UserType.Selling.ToString()],
                    Controller = "Selling",
                    Action = "records",
                    Title = "Selling Invoice",
                    Sn = 3
                },
                new PageLink
                {
                    LinkId = 16,
                    LinkCategoryId = 4,
                    RoleId = Ids[UserType.SellingDueReport.ToString()],
                    Controller = "Selling",
                    Action = "dueReport",
                    Title = "Due Report",
                    Sn = 4
                },
                new PageLink
                {
                    LinkId = 17,
                    LinkCategoryId = 4,
                    RoleId = Ids[UserType.SellingPaymentReport.ToString()],
                    Controller = "Selling",
                    Action = "paymentReport",
                    Title = "Payment Report",
                    Sn = 5
                },
                new PageLink
                {
                    LinkId = 18,
                    LinkCategoryId = 4,
                    RoleId = Ids[UserType.SellingReport.ToString()],
                    Controller = "Selling",
                    Action = "sellingReport",
                    Title = "Selling Report",
                    Sn = 6
                },
                new PageLink
                {
                    LinkId = 19,
                    LinkCategoryId = 5,
                    RoleId = Ids[UserType.Expense.ToString()],
                    Controller = "expense",
                    Action = "category",
                    Title = "Category",
                    Sn = 1
                },
                new PageLink
                {
                    LinkId = 20,
                    LinkCategoryId = 5,
                    RoleId = Ids[UserType.Expense.ToString()],
                    Controller = "expense",
                    Action = "Index",
                    Title = "Expense",
                    Sn = 2
                },
                new PageLink
                {
                    LinkId = 21,
                    LinkCategoryId = 5,
                    RoleId = Ids[UserType.ExpenseReport.ToString()],
                    Controller = "expense",
                    Action = "report",
                    Title = "Expense Report",
                    Sn = 3
                },
                new PageLink
                {
                    LinkId = 22,
                    LinkCategoryId = 6,
                    RoleId = Ids[UserType.DailyCash.ToString()],
                    Controller = "Report",
                    Action = "DailyCash",
                    Title = "Daily Cash Report",
                    Sn = 1
                },
                new PageLink
                {
                    LinkId = 23,
                    LinkCategoryId = 6,
                    RoleId = Ids[UserType.ProductSales.ToString()],
                    Controller = "Report",
                    Action = "ProductSales",
                    Title = "Product Sales Report",
                    Sn = 2
                },
                new PageLink
                {
                    LinkId = 24,
                    LinkCategoryId = 6,
                    RoleId = Ids[UserType.Net.ToString()],
                    Controller = "Report",
                    Action = "Net",
                    Title = "Net Report",
                    Sn = 3
                },
                new PageLink
                {
                    LinkId = 25,
                    LinkCategoryId = 7,
                    RoleId = Ids[UserType.SmsVendor.ToString()],
                    Controller = "SMS",
                    Action = "vendor",
                    Title = "Send to Vendor",
                    Sn = 1
                },
                new PageLink
                {
                    LinkId = 26,
                    LinkCategoryId = 7,
                    RoleId = Ids[UserType.SmsSingle.ToString()],
                    Controller = "SMS",
                    Action = "Single",
                    Title = "Single SMS",
                    Sn = 2
                },
                new PageLink
                {
                    LinkId = 27,
                    LinkCategoryId = 7,
                    RoleId = Ids[UserType.SentRecord.ToString()],
                    Controller = "SMS",
                    Action = "sentRecord",
                    Title = "Sent Record",
                    Sn = 3
                },
                new PageLink
                {
                    LinkId = 28,
                    LinkCategoryId = 8,
                    RoleId = Ids[UserType.SubAdminSignUp.ToString()],
                    Controller = "subAdmin",
                    Action = "signup",
                    Title = "Sign Up",
                    Sn = 1
                },
                new PageLink
                {
                    LinkId = 29,
                    LinkCategoryId = 8,
                    RoleId = Ids[UserType.SubAdminList.ToString()],
                    Controller = "subAdmin",
                    Action = "Index",
                    Title = "Sub-admin List",
                    Sn = 2
                },
                new PageLink
                {
                    LinkId = 30,
                    LinkCategoryId = 8,
                    RoleId = Ids[UserType.SubAdminPageAccess.ToString()],
                    Controller = "subAdmin",
                    Action = "pageAccess",
                    Title = "Page Access",
                    Sn = 3
                },
                new PageLink
                {
                    LinkId = 31,
                    LinkCategoryId = 9,
                    RoleId = Ids[UserType.Reset.ToString()],
                    Controller = "Admin",
                    Action = "Reset",
                    Title = "Reset",
                    Sn = 1
                }
            );
        }
    }
}