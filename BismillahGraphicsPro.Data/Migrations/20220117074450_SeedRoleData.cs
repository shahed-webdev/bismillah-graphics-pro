using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BismillahGraphicsPro.Data.Migrations
{
    public partial class SeedRoleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22b877e9-56c5-4281-92a7-d336cd4382a4", "22b877e9-56c5-4281-92a7-d336cd4382a4", "MeasurementUnit", "MEASUREMENTUNIT" },
                    { "25205E51-C7F6-43E5-927A-8074AF61B966", "25205E51-C7F6-43E5-927A-8074AF61B966", "Authority", "AUTHORITY" },
                    { "27c3d924-cac0-4aae-8076-eb395964d547", "27c3d924-cac0-4aae-8076-eb395964d547", "SellingRecord", "SELLINGRECORD" },
                    { "31f91532-c149-4248-a844-f7601c24b740", "31f91532-c149-4248-a844-f7601c24b740", "BalanceSheet", "BALANCESHEET" },
                    { "3DC9AC78-8A93-498A-8D04-D69C0294B4C4", "3DC9AC78-8A93-498A-8D04-D69C0294B4C4", "Supplier", "SUPPLIER" },
                    { "3e0d4db7-80a0-49a9-8d8d-116cc5c9fc83", "3e0d4db7-80a0-49a9-8d8d-116cc5c9fc83", "NetSummery", "NETSUMMERY" },
                    { "446d16c5-000c-4099-b553-23696a5284ec", "446d16c5-000c-4099-b553-23696a5284ec", "Expanse", "EXPANSE" },
                    { "4d4fb0a3-4734-4802-a027-9c9b2ad7dae7", "4d4fb0a3-4734-4802-a027-9c9b2ad7dae7", "SubAdmin", "SUBADMIN" },
                    { "54DAEA5E-86D7-4EBE-9191-A170B37CD883", "54DAEA5E-86D7-4EBE-9191-A170B37CD883", "SubAdminPageAccess", "SUBADMINPAGEACCESS" },
                    { "5a52c2fc-6d6b-478f-9fce-ba46abaea1f2", "5a52c2fc-6d6b-478f-9fce-ba46abaea1f2", "Product", "PRODUCT" },
                    { "5c8eda73-94a0-49e6-b4ad-63282d09e3a7", "5c8eda73-94a0-49e6-b4ad-63282d09e3a7", "ReportVendor", "REPORTVENDOR" },
                    { "5d0106d1-8900-4630-aec2-0b016f55d092", "5d0106d1-8900-4630-aec2-0b016f55d092", "Withdraw", "WITHDRAW" },
                    { "60482875-1078-4F65-BBBE-5C68836045A6", "60482875-1078-4F65-BBBE-5C68836045A6", "TransactionLogs", "TRANSACTIONLOGS" },
                    { "70453879-6A75-48B8-8ED2-8B86DEC40798", "70453879-6A75-48B8-8ED2-8B86DEC40798", "Vendor", "VENDOR" },
                    { "7210cd36-9476-4a49-ad86-f2bfb88c4e6d", "7210cd36-9476-4a49-ad86-f2bfb88c4e6d", "ReportExpense", "REPORTEXPENSE" },
                    { "86DD9E91-0928-497A-B226-FA346F7EA656", "86DD9E91-0928-497A-B226-FA346F7EA656", "SubAdminSignUp", "SUBADMINSIGNUP" },
                    { "897ea03e-f328-4a9e-91bc-247d9dcc6aa9", "897ea03e-f328-4a9e-91bc-247d9dcc6aa9", "PaymentSummery", "PAYMENTSUMMERY" },
                    { "93c4b0d6-0d82-410f-adb1-fb4aba413a8e", "93c4b0d6-0d82-410f-adb1-fb4aba413a8e", "ReportIncome", "REPORTINCOME" },
                    { "9d037f79-ec3e-481d-8e4f-acf86a3a2f5c", "9d037f79-ec3e-481d-8e4f-acf86a3a2f5c", "PurchaseRecord", "PURCHASERECORD" },
                    { "9EB47A31-EFC6-43D4-B204-538FC3F280F3", "9EB47A31-EFC6-43D4-B204-538FC3F280F3", "Sms", "SMS" },
                    { "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4", "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4", "Admin", "ADMIN" },
                    { "a9c6f8da-3e48-47a9-b355-6107b297ae10", "a9c6f8da-3e48-47a9-b355-6107b297ae10", "ProductSummery", "PRODUCTSUMMERY" },
                    { "aceacd97-893e-464a-9f94-9e19d8984764", "aceacd97-893e-464a-9f94-9e19d8984764", "ReportSelling", "REPORTSELLING" },
                    { "ae25c232-3435-4239-901d-0e2d3e4069c9", "ae25c232-3435-4239-901d-0e2d3e4069c9", "Deposit", "DEPOSIT" },
                    { "b1280e80-8ec6-48fb-8580-6f2e57db8d58", "b1280e80-8ec6-48fb-8580-6f2e57db8d58", "ExpenseCategory", "EXPENSECATEGORY" },
                    { "bbd6cebc-741d-4bfb-852b-204d5f623a86", "bbd6cebc-741d-4bfb-852b-204d5f623a86", "ProductCategory", "PRODUCTCATEGORY" },
                    { "bc6a04f9-6984-4755-8573-016047310f8e", "bc6a04f9-6984-4755-8573-016047310f8e", "ReportDailyCash", "REPORTDAILYCASH" },
                    { "D093C085-938C-4A7E-84B8-9CA5559850AE", "D093C085-938C-4A7E-84B8-9CA5559850AE", "SubAdminList", "SUBADMINLIST" },
                    { "D68419DF-4B85-4704-89F7-AC889C750493", "D68419DF-4B85-4704-89F7-AC889C750493", "Selling", "SELLING" },
                    { "e202e807-4b4f-4c78-983a-2ad06e3f7012", "e202e807-4b4f-4c78-983a-2ad06e3f7012", "AccountCreate", "ACCOUNTCREATE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "A0456563-F978-4135-B563-97F23EA02FDA", 0, "A0456563-F978-4135-B563-97F23EA02FDA", "Authority@gmail.com", true, true, null, "AUTHORITY@GMAIL.COM", "AUTHORITY", "AQAAAAEAACcQAAAAEDch3arYEB9dCAudNdsYEpVX7ryywa8f3ZIJSVUmEThAI50pLh9RyEu7NjGJccpOog==", null, false, "", false, "Authority" });

            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "RegistrationId", "Address", "BranchId", "Email", "Image", "Name", "Phone", "PS", "Type", "UserName" },
                values: new object[] { 1, null, null, null, null, "Authority", null, "Admin_121", "Authority", "Authority" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "25205E51-C7F6-43E5-927A-8074AF61B966", "A0456563-F978-4135-B563-97F23EA02FDA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b877e9-56c5-4281-92a7-d336cd4382a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27c3d924-cac0-4aae-8076-eb395964d547");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31f91532-c149-4248-a844-f7601c24b740");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3DC9AC78-8A93-498A-8D04-D69C0294B4C4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e0d4db7-80a0-49a9-8d8d-116cc5c9fc83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "446d16c5-000c-4099-b553-23696a5284ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d4fb0a3-4734-4802-a027-9c9b2ad7dae7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54DAEA5E-86D7-4EBE-9191-A170B37CD883");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a52c2fc-6d6b-478f-9fce-ba46abaea1f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c8eda73-94a0-49e6-b4ad-63282d09e3a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d0106d1-8900-4630-aec2-0b016f55d092");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60482875-1078-4F65-BBBE-5C68836045A6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70453879-6A75-48B8-8ED2-8B86DEC40798");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7210cd36-9476-4a49-ad86-f2bfb88c4e6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86DD9E91-0928-497A-B226-FA346F7EA656");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "897ea03e-f328-4a9e-91bc-247d9dcc6aa9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93c4b0d6-0d82-410f-adb1-fb4aba413a8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d037f79-ec3e-481d-8e4f-acf86a3a2f5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9EB47A31-EFC6-43D4-B204-538FC3F280F3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9c6f8da-3e48-47a9-b355-6107b297ae10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aceacd97-893e-464a-9f94-9e19d8984764");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae25c232-3435-4239-901d-0e2d3e4069c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1280e80-8ec6-48fb-8580-6f2e57db8d58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbd6cebc-741d-4bfb-852b-204d5f623a86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc6a04f9-6984-4755-8573-016047310f8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D093C085-938C-4A7E-84B8-9CA5559850AE");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D68419DF-4B85-4704-89F7-AC889C750493");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e202e807-4b4f-4c78-983a-2ad06e3f7012");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "25205E51-C7F6-43E5-927A-8074AF61B966", "A0456563-F978-4135-B563-97F23EA02FDA" });

            migrationBuilder.DeleteData(
                table: "Registration",
                keyColumn: "RegistrationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25205E51-C7F6-43E5-927A-8074AF61B966");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA");
        }
    }
}
