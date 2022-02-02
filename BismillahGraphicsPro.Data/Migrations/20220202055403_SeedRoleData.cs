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
                    { "058e2f01-67eb-4dcb-8eab-99402d0c3643", "058e2f01-67eb-4dcb-8eab-99402d0c3643", "SubAdminPageAccess", "SUBADMINPAGEACCESS" },
                    { "06f359fa-68bf-40f6-a112-fc599511b145", "06f359fa-68bf-40f6-a112-fc599511b145", "SellingReport", "SELLINGREPORT" },
                    { "0c03d7ba-96df-46cd-97bb-328de8edebed", "0c03d7ba-96df-46cd-97bb-328de8edebed", "PurchasePayDueMultiple", "PURCHASEPAYDUEMULTIPLE" },
                    { "1bb0d758-5506-43f5-b6a0-a6b3b4ee8129", "1bb0d758-5506-43f5-b6a0-a6b3b4ee8129", "SubAdminList", "SUBADMINLIST" },
                    { "1d844081-a5fc-4674-a767-4e835e591740", "1d844081-a5fc-4674-a767-4e835e591740", "BalanceSheet", "BALANCESHEET" },
                    { "216787ad-3c2d-4756-9067-779321626951", "216787ad-3c2d-4756-9067-779321626951", "PurchasePayDueSingle", "PURCHASEPAYDUESINGLE" },
                    { "25205E51-C7F6-43E5-927A-8074AF61B966", "25205E51-C7F6-43E5-927A-8074AF61B966", "Authority", "AUTHORITY" },
                    { "293de564-7caf-4686-9aea-f2dbc69b9072", "293de564-7caf-4686-9aea-f2dbc69b9072", "DailyCash", "DAILYCASH" },
                    { "299dd7bc-f8f4-42e2-b129-607d774bf983", "299dd7bc-f8f4-42e2-b129-607d774bf983", "SmsSingle", "SMSSINGLE" },
                    { "29a30973-7b5c-4a18-80ed-ab222e548f1e", "29a30973-7b5c-4a18-80ed-ab222e548f1e", "Vendors", "VENDORS" },
                    { "3eb3b3a9-51d9-4dd8-b9d9-7ed710ca6fce", "3eb3b3a9-51d9-4dd8-b9d9-7ed710ca6fce", "PurchaseDueReport", "PURCHASEDUEREPORT" },
                    { "4120700d-198a-4817-9987-37077ba86160", "4120700d-198a-4817-9987-37077ba86160", "TransactionLog", "TRANSACTIONLOG" },
                    { "415afdc1-04c0-4e7c-8a38-3daeab8f2e10", "415afdc1-04c0-4e7c-8a38-3daeab8f2e10", "SubAdminSignUp", "SUBADMINSIGNUP" },
                    { "48f381bf-e07a-4846-b336-b395d9e755ea", "48f381bf-e07a-4846-b336-b395d9e755ea", "SellingPaymentReport", "SELLINGPAYMENTREPORT" },
                    { "492d5817-5fd2-4342-8f84-4d5798aa5e01", "492d5817-5fd2-4342-8f84-4d5798aa5e01", "Purchase", "PURCHASE" },
                    { "4b48934d-ef26-4289-a038-e7313736126f", "4b48934d-ef26-4289-a038-e7313736126f", "MeasurementUnit", "MEASUREMENTUNIT" },
                    { "4d4fb0a3-4734-4802-a027-9c9b2ad7dae7", "4d4fb0a3-4734-4802-a027-9c9b2ad7dae7", "SubAdmin", "SUBADMIN" },
                    { "59adebcb-f095-45a4-bae0-cc574d810106", "59adebcb-f095-45a4-bae0-cc574d810106", "Reset", "RESET" },
                    { "632f139d-4827-413e-8ede-45d3ba8f9724", "632f139d-4827-413e-8ede-45d3ba8f9724", "PurchasePaymentReport", "PURCHASEPAYMENTREPORT" },
                    { "726bc8ab-e678-4b7f-a9e6-636ae673bd63", "726bc8ab-e678-4b7f-a9e6-636ae673bd63", "SellingDueCollectionMultiple", "SELLINGDUECOLLECTIONMULTIPLE" },
                    { "8382e629-ac39-46ed-816e-0fe9275e3554", "8382e629-ac39-46ed-816e-0fe9275e3554", "SmsVendor", "SMSVENDOR" },
                    { "878cad39-1257-44cb-9c2d-21da49e4e34d", "878cad39-1257-44cb-9c2d-21da49e4e34d", "Net", "NET" },
                    { "a3e4480c-f381-4b34-9ab8-b0f3db05b724", "a3e4480c-f381-4b34-9ab8-b0f3db05b724", "SentRecord", "SENTRECORD" },
                    { "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4", "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4", "Admin", "ADMIN" },
                    { "bec93436-98fd-44fe-bcd3-00f3a9cf0b3a", "bec93436-98fd-44fe-bcd3-00f3a9cf0b3a", "StockReport", "STOCKREPORT" },
                    { "c5f489f6-6f53-473b-9c47-d087ce3e9cd5", "c5f489f6-6f53-473b-9c47-d087ce3e9cd5", "ProductSales", "PRODUCTSALES" },
                    { "cb683688-df12-4127-979b-d6b1fd8eddda", "cb683688-df12-4127-979b-d6b1fd8eddda", "Suppliers", "SUPPLIERS" },
                    { "cc64a971-f6e8-4811-8c3f-a9e2e944e21e", "cc64a971-f6e8-4811-8c3f-a9e2e944e21e", "ExpenseReport", "EXPENSEREPORT" },
                    { "d28f2f6f-eea6-415e-afec-52cacafe7c7d", "d28f2f6f-eea6-415e-afec-52cacafe7c7d", "SellingDueReport", "SELLINGDUEREPORT" },
                    { "d4d25cbe-c54b-4982-ac79-a45c562faf8d", "d4d25cbe-c54b-4982-ac79-a45c562faf8d", "Products", "PRODUCTS" },
                    { "d8a9c270-f027-4078-a71c-1d6c7372ff53", "d8a9c270-f027-4078-a71c-1d6c7372ff53", "Selling", "SELLING" },
                    { "f1fb596e-fc07-46f8-ae1d-ebbde38e5994", "f1fb596e-fc07-46f8-ae1d-ebbde38e5994", "Expense", "EXPENSE" },
                    { "fb76a482-3d73-4e28-9155-581a1a2cbea4", "fb76a482-3d73-4e28-9155-581a1a2cbea4", "Account", "ACCOUNT" },
                    { "fe0aa59a-d691-4bcb-bad4-07fba932e7ac", "fe0aa59a-d691-4bcb-bad4-07fba932e7ac", "SellingDueCollectionSingle", "SELLINGDUECOLLECTIONSINGLE" }
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
                keyValue: "058e2f01-67eb-4dcb-8eab-99402d0c3643");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06f359fa-68bf-40f6-a112-fc599511b145");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c03d7ba-96df-46cd-97bb-328de8edebed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bb0d758-5506-43f5-b6a0-a6b3b4ee8129");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d844081-a5fc-4674-a767-4e835e591740");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "216787ad-3c2d-4756-9067-779321626951");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "293de564-7caf-4686-9aea-f2dbc69b9072");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "299dd7bc-f8f4-42e2-b129-607d774bf983");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29a30973-7b5c-4a18-80ed-ab222e548f1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3eb3b3a9-51d9-4dd8-b9d9-7ed710ca6fce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4120700d-198a-4817-9987-37077ba86160");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "415afdc1-04c0-4e7c-8a38-3daeab8f2e10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48f381bf-e07a-4846-b336-b395d9e755ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492d5817-5fd2-4342-8f84-4d5798aa5e01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b48934d-ef26-4289-a038-e7313736126f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d4fb0a3-4734-4802-a027-9c9b2ad7dae7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59adebcb-f095-45a4-bae0-cc574d810106");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "632f139d-4827-413e-8ede-45d3ba8f9724");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "726bc8ab-e678-4b7f-a9e6-636ae673bd63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8382e629-ac39-46ed-816e-0fe9275e3554");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "878cad39-1257-44cb-9c2d-21da49e4e34d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3e4480c-f381-4b34-9ab8-b0f3db05b724");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bec93436-98fd-44fe-bcd3-00f3a9cf0b3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5f489f6-6f53-473b-9c47-d087ce3e9cd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb683688-df12-4127-979b-d6b1fd8eddda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc64a971-f6e8-4811-8c3f-a9e2e944e21e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d28f2f6f-eea6-415e-afec-52cacafe7c7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4d25cbe-c54b-4982-ac79-a45c562faf8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a9c270-f027-4078-a71c-1d6c7372ff53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1fb596e-fc07-46f8-ae1d-ebbde38e5994");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb76a482-3d73-4e28-9155-581a1a2cbea4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe0aa59a-d691-4bcb-bad4-07fba932e7ac");

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
