using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BismillahGraphicsPro.Data.Migrations
{
    public partial class DepositAndWithdrawForeegnkeyError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposit_Account",
                table: "AccountDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountWithdraw_Account",
                table: "AccountWithdraw");


            migrationBuilder.CreateIndex(
                name: "IX_AccountWithdraw_AccountId",
                table: "AccountWithdraw",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposit_AccountId",
                table: "AccountDeposit",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposit_Account",
                table: "AccountDeposit",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountWithdraw_Account",
                table: "AccountWithdraw",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposit_Account",
                table: "AccountDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountWithdraw_Account",
                table: "AccountWithdraw");

            migrationBuilder.DropIndex(
                name: "IX_AccountWithdraw_AccountId",
                table: "AccountWithdraw");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposit_AccountId",
                table: "AccountDeposit");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposit_Account",
                table: "AccountDeposit",
                column: "AccountDepositId",
                principalTable: "Account",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountWithdraw_Account",
                table: "AccountWithdraw",
                column: "AccountWithdrawId",
                principalTable: "Account",
                principalColumn: "AccountId");
        }
    }
}
