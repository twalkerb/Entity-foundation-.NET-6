using Microsoft.EntityFrameworkCore.Migrations;
using ShoppingCartEF2.Extensions;

#nullable disable

namespace ShoppingCartMigrations.Migrations
{
    public partial class createUserBob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateUser("Bob", "password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropUser("Bob");
        }
    }
}
