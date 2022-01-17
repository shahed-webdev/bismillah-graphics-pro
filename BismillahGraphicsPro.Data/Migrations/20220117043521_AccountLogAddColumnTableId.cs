using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BismillahGraphicsPro.Data.Migrations
{
    public partial class AccountLogAddColumnTableId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "AccountLog",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "AccountLog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TableName",
                table: "AccountLog",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableId",
                table: "AccountLog");

            migrationBuilder.DropColumn(
                name: "TableName",
                table: "AccountLog");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "AccountLog",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }
    }
}
