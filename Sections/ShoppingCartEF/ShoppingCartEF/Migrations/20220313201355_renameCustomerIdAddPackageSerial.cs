using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartEF.Migrations
{
    public partial class renameCustomerIdAddPackageSerial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "CustomerName");

            migrationBuilder.AddColumn<string>(
                name: "PackageSerial",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageSerial",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Orders",
                newName: "CustomerId");
        }
    }
}
