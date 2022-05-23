using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartMigrations.Migrations
{
    public partial class RelationshipMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerTypeId",
                schema: "Shopping",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                schema: "Shopping",
                columns: table => new
                {
                    CustomerAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressOfCustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.CustomerAddressId);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Customers_AddressOfCustomerId",
                        column: x => x.AddressOfCustomerId,
                        principalSchema: "Shopping",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerBook",
                schema: "Shopping",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBook", x => new { x.CustomerId, x.BookId });
                    table.ForeignKey(
                        name: "FK_CustomerBook_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Shopping",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerBook_LibaryBooks_BookId",
                        column: x => x.BookId,
                        principalSchema: "Shopping",
                        principalTable: "LibaryBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerType",
                schema: "Shopping",
                columns: table => new
                {
                    CustomerTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.CustomerTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                schema: "Shopping",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_AddressOfCustomerId",
                schema: "Shopping",
                table: "CustomerAddress",
                column: "AddressOfCustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBook_BookId",
                schema: "Shopping",
                table: "CustomerBook",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerType_CustomerTypeId",
                schema: "Shopping",
                table: "Customers",
                column: "CustomerTypeId",
                principalSchema: "Shopping",
                principalTable: "CustomerType",
                principalColumn: "CustomerTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerType_CustomerTypeId",
                schema: "Shopping",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerAddress",
                schema: "Shopping");

            migrationBuilder.DropTable(
                name: "CustomerBook",
                schema: "Shopping");

            migrationBuilder.DropTable(
                name: "CustomerType",
                schema: "Shopping");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                schema: "Shopping",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerTypeId",
                schema: "Shopping",
                table: "Customers");
        }
    }
}
