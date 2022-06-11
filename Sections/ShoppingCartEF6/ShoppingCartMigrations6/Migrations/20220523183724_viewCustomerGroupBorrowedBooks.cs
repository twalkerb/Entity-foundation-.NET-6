using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartMigrations.Migrations
{
    public partial class viewCustomerGroupBorrowedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" CREATE VIEW [dbo].[vwCustomerGroupBorrowedBooks]
AS
SELECT     TOP (100) PERCENT Shopping.CustomerBook.LoanDate, Shopping.CustomerBook.ReturnDate, Shopping.Customers.CustomerGroup, Shopping.LibaryBooks.PurchasePrice, 
                      Shopping.LibaryBooks.Name, Shopping.LibaryBooks.InternationStandardBookNumber
FROM         Shopping.Customers INNER JOIN
                      Shopping.CustomerBook ON Shopping.Customers.Id = Shopping.CustomerBook.CustomerId INNER JOIN
                      Shopping.LibaryBooks ON Shopping.CustomerBook.BookId = Shopping.LibaryBooks.Id
ORDER BY Shopping.Customers.CustomerGroup DESC");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [dbo].[vwCustomerGroupBorrowedBooks]");
        }
    }
}
