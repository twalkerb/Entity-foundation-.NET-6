using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartEF.Migrations
{
    public partial class splitPackageSerial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
              name: "PackageType",
              table: "Orders",
              nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "PackageSequence",
                table: "Orders",
                nullable: true);

            migrationBuilder.Sql(
            @"
    UPDATE Orders
    SET PackageType=SUBSTRING(PackageSerial, 1, 4);
");

            migrationBuilder.Sql(
            @"
    UPDATE Orders
    SET PackageSequence= SUBSTRING(PackageSerial, 5, LEN(PackageSerial) );
");
            migrationBuilder.DropColumn(
                name: "PackageSerial",
                table: "Orders");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "PackageSerial",
               table: "Orders",
               type: "nvarchar(max)",
               nullable: false,
               defaultValue: "");

            migrationBuilder.Sql(
            @"
    UPDATE Orders
    SET PackageSerial= PackageType + PackageSequence;
");

            migrationBuilder.DropColumn(
    name: "PackageType",
    table: "Orders");
            migrationBuilder.DropColumn(
                name: "PackageSequence",
                table: "Orders");

        }
    }
}
