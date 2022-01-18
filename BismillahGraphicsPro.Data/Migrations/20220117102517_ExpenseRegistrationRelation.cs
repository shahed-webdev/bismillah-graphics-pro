using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BismillahGraphicsPro.Data.Migrations
{
    public partial class ExpenseRegistrationRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Expanse_RegistrationId",
                table: "Expanse",
                column: "RegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expanse_Registration",
                table: "Expanse",
                column: "RegistrationId",
                principalTable: "Registration",
                principalColumn: "RegistrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expanse_Registration",
                table: "Expanse");

            migrationBuilder.DropIndex(
                name: "IX_Expanse_RegistrationId",
                table: "Expanse");
        }
    }
}
