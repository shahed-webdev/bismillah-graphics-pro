using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BismillahGraphicsPro.Data.Migrations
{
    public partial class SeedLinkCategoryData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PageLinkCategory",
                columns: new[] { "LinkCategoryId", "Category", "IconClass", "Sn" },
                values: new object[,]
                {
                    { 1, "Account", "fas fa-file-invoice-dollar", 1 },
                    { 2, "Product", "fas fa-shopping-bag", 2 },
                    { 3, "Purchase", "fas fa-user-tie", 3 },
                    { 4, "Selling", "fas fa-shopping-bag", 4 },
                    { 5, "Expense", "fas fa-chart-pie", 5 },
                    { 6, "Report", "fas fa-file-alt", 6 },
                    { 7, "SMS", "fas fa-sms", 7 },
                    { 8, "Sub-Admin", "fas fa-user-shield", 8 },
                    { 9, "Reset", "fas fa-trash-restore", 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PageLinkCategory",
                keyColumn: "LinkCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PageLinkCategory",
                keyColumn: "LinkCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PageLinkCategory",
                keyColumn: "LinkCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PageLinkCategory",
                keyColumn: "LinkCategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PageLinkCategory",
                keyColumn: "LinkCategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PageLinkCategory",
                keyColumn: "LinkCategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PageLinkCategory",
                keyColumn: "LinkCategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PageLinkCategory",
                keyColumn: "LinkCategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PageLinkCategory",
                keyColumn: "LinkCategoryId",
                keyValue: 9);
        }
    }
}
