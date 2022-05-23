using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartMigrations.Migrations
{
    public partial class LibraryBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryLibraryId = table.Column<int>(type: "int", nullable: false),
                    OnLoanLibraryId = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Libaries_OnLoanLibraryId",
                        column: x => x.OnLoanLibraryId,
                        principalTable: "Libaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Books_Libaries_PrimaryLibraryId",
                        column: x => x.PrimaryLibraryId,
                        principalTable: "Libaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_OnLoanLibraryId",
                table: "Books",
                column: "OnLoanLibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PrimaryLibraryId",
                table: "Books",
                column: "PrimaryLibraryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Libaries");
        }
    }
}
