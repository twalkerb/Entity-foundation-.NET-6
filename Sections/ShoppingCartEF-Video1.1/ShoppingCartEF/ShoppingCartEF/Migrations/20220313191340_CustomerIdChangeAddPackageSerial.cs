using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartEF.Data
{
    public partial class CustomerIdChangeAddPackageSerial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "PackageSerial");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PackageSerial",
                table: "Orders",
                newName: "CustomerId");
        }
    }
}
