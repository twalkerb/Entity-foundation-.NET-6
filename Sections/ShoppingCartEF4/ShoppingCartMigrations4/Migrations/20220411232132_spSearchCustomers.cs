using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartMigrations.Migrations
{
    public partial class spSearchCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var sp = @"CREATE PROCEDURE [dbo].[spSearchCustomers]
                    @SearchName varchar(50)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Shopping.Customers where FirstName like @SearchName +'%' or LastName like @SearchName +'%'
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
