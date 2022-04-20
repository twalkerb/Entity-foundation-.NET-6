using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartMigrations.Migrations
{
    public partial class Notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_Notes",
                columns: table => new
                {
                    Note_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlSmall = table.Column<string>(type: "varchar(200)", nullable: false, comment: "The URL of the web page the note is about"),
                    NoteText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Score = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Notes", x => x.Note_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Notes");
        }
    }
}
