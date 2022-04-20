using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartMigrations.Migrations
{
    public partial class PropertyMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_LibaryBooks_ISBN",
                schema: "Shopping",
                table: "LibaryBooks");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                schema: "Shopping",
                table: "LibaryBooks",
                newName: "InternationStandardBookNumber");

            migrationBuilder.AlterColumn<string>(
                name: "InternationStandardBookNumber",
                schema: "Shopping",
                table: "LibaryBooks",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CreditDays",
                schema: "Shopping",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 30);

            migrationBuilder.AddColumn<decimal>(
                name: "CreditLimit",
                schema: "Shopping",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CreditScore",
                schema: "Shopping",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreditScoreDate",
                schema: "Shopping",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_LibaryBooks_InternationStandardBookNumber",
                schema: "Shopping",
                table: "LibaryBooks",
                column: "InternationStandardBookNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_LibaryBooks_InternationStandardBookNumber",
                schema: "Shopping",
                table: "LibaryBooks");

            migrationBuilder.DropColumn(
                name: "CreditDays",
                schema: "Shopping",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditLimit",
                schema: "Shopping",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditScore",
                schema: "Shopping",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditScoreDate",
                schema: "Shopping",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "InternationStandardBookNumber",
                schema: "Shopping",
                table: "LibaryBooks",
                newName: "ISBN");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                schema: "Shopping",
                table: "LibaryBooks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_LibaryBooks_ISBN",
                schema: "Shopping",
                table: "LibaryBooks",
                column: "ISBN");
        }
    }
}
