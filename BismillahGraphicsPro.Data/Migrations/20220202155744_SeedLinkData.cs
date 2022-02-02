using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BismillahGraphicsPro.Data.Migrations
{
    public partial class SeedLinkData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PageLink",
                columns: new[] { "LinkId", "Action", "Controller", "IconClass", "LinkCategoryId", "RoleId", "Sn", "Title" },
                values: new object[,]
                {
                    { 1, "Index", "Account", null, 1, "fb76a482-3d73-4e28-9155-581a1a2cbea4", 1, "Account List" },
                    { 2, "balanceSheet", "Account", null, 1, "1d844081-a5fc-4674-a767-4e835e591740", 2, "Balance Sheet" },
                    { 3, "TransactionLog", "Account", null, 1, "4120700d-198a-4817-9987-37077ba86160", 3, "Transaction Logs" },
                    { 4, "measurementUnit", "Product", null, 2, "4b48934d-ef26-4289-a038-e7313736126f", 1, "Measurement Unit" },
                    { 5, "Category", "Product", null, 2, "d4d25cbe-c54b-4982-ac79-a45c562faf8d", 2, "Category" },
                    { 6, "Index", "Product", null, 2, "d4d25cbe-c54b-4982-ac79-a45c562faf8d", 3, "Products" },
                    { 7, "stockReport", "Product", null, 2, "bec93436-98fd-44fe-bcd3-00f3a9cf0b3a", 4, "Stock Report" },
                    { 8, "suppliers", "purchase", null, 3, "cb683688-df12-4127-979b-d6b1fd8eddda", 1, "Suppliers" },
                    { 9, "Index", "purchase", null, 3, "492d5817-5fd2-4342-8f84-4d5798aa5e01", 2, "Purchase" },
                    { 10, "records", "purchase", null, 3, "492d5817-5fd2-4342-8f84-4d5798aa5e01", 3, "Purchase Invoice" },
                    { 11, "paymentReport", "purchase", null, 3, "632f139d-4827-413e-8ede-45d3ba8f9724", 4, "Payment Report" },
                    { 12, "dueReport", "purchase", null, 3, "3eb3b3a9-51d9-4dd8-b9d9-7ed710ca6fce", 5, "Due Report" },
                    { 13, "vendors", "Selling", null, 4, "29a30973-7b5c-4a18-80ed-ab222e548f1e", 1, "Vendors" },
                    { 14, "Index", "Selling", null, 4, "d8a9c270-f027-4078-a71c-1d6c7372ff53", 2, "Selling" },
                    { 15, "records", "Selling", null, 4, "d8a9c270-f027-4078-a71c-1d6c7372ff53", 3, "Selling Invoice" },
                    { 16, "dueReport", "Selling", null, 4, "d28f2f6f-eea6-415e-afec-52cacafe7c7d", 4, "Due Report" },
                    { 17, "paymentReport", "Selling", null, 4, "48f381bf-e07a-4846-b336-b395d9e755ea", 5, "Payment Report" },
                    { 18, "sellingReport", "Selling", null, 4, "06f359fa-68bf-40f6-a112-fc599511b145", 6, "Selling Report" },
                    { 19, "category", "expense", null, 5, "f1fb596e-fc07-46f8-ae1d-ebbde38e5994", 1, "Category" },
                    { 20, "Index", "expense", null, 5, "f1fb596e-fc07-46f8-ae1d-ebbde38e5994", 2, "Expense" },
                    { 21, "report", "expense", null, 5, "cc64a971-f6e8-4811-8c3f-a9e2e944e21e", 3, "Expense Report" },
                    { 22, "DailyCash", "Report", null, 6, "293de564-7caf-4686-9aea-f2dbc69b9072", 1, "Daily Cash Report" },
                    { 23, "ProductSales", "Report", null, 6, "c5f489f6-6f53-473b-9c47-d087ce3e9cd5", 2, "Product Sales Report" },
                    { 24, "Net", "Report", null, 6, "878cad39-1257-44cb-9c2d-21da49e4e34d", 3, "Net Report" },
                    { 25, "vendor", "SMS", null, 7, "8382e629-ac39-46ed-816e-0fe9275e3554", 1, "Send to Vendor" },
                    { 26, "Single", "SMS", null, 7, "299dd7bc-f8f4-42e2-b129-607d774bf983", 2, "Single SMS" },
                    { 27, "sentRecord", "SMS", null, 7, "a3e4480c-f381-4b34-9ab8-b0f3db05b724", 3, "Sent Record" },
                    { 28, "signup", "subAdmin", null, 8, "415afdc1-04c0-4e7c-8a38-3daeab8f2e10", 1, "Sign Up" },
                    { 29, "Index", "subAdmin", null, 8, "058e2f01-67eb-4dcb-8eab-99402d0c3643", 2, "Sub-admin List" },
                    { 30, "pageAccess", "subAdmin", null, 8, "058e2f01-67eb-4dcb-8eab-99402d0c3643", 3, "Page Access" },
                    { 31, "Reset", "Admin", null, 9, "59adebcb-f095-45a4-bae0-cc574d810106", 1, "Reset" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PageLink",
                keyColumn: "LinkId",
                keyValue: 31);
        }
    }
}
