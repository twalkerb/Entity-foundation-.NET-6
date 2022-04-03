using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartMigrations.Migrations
{
    public partial class EntityMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Libaries_OnLoanLibraryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Libaries_PrimaryLibraryId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Notes",
                table: "Customer_Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "Shopping");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "Shopping");

            migrationBuilder.RenameTable(
                name: "Libaries",
                newName: "Libaries",
                newSchema: "Shopping");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customers",
                newSchema: "Shopping");

            migrationBuilder.RenameTable(
                name: "Customer_Notes",
                newName: "CustomerNotes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "LibaryBooks",
                newSchema: "Shopping");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PrimaryLibraryId",
                schema: "Shopping",
                table: "LibaryBooks",
                newName: "IX_LibaryBooks_PrimaryLibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_OnLoanLibraryId",
                schema: "Shopping",
                table: "LibaryBooks",
                newName: "IX_LibaryBooks_OnLoanLibraryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Shopping",
                table: "LibaryBooks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                schema: "Shopping",
                table: "LibaryBooks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerNotes",
                schema: "dbo",
                table: "CustomerNotes",
                column: "Note_id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_LibaryBooks_ISBN",
                schema: "Shopping",
                table: "LibaryBooks",
                column: "ISBN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibaryBooks",
                schema: "Shopping",
                table: "LibaryBooks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LibaryBooks_Name",
                schema: "Shopping",
                table: "LibaryBooks",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_LibaryBooks_Libaries_OnLoanLibraryId",
                schema: "Shopping",
                table: "LibaryBooks",
                column: "OnLoanLibraryId",
                principalSchema: "Shopping",
                principalTable: "Libaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LibaryBooks_Libaries_PrimaryLibraryId",
                schema: "Shopping",
                table: "LibaryBooks",
                column: "PrimaryLibraryId",
                principalSchema: "Shopping",
                principalTable: "Libaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibaryBooks_Libaries_OnLoanLibraryId",
                schema: "Shopping",
                table: "LibaryBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_LibaryBooks_Libaries_PrimaryLibraryId",
                schema: "Shopping",
                table: "LibaryBooks");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_LibaryBooks_ISBN",
                schema: "Shopping",
                table: "LibaryBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibaryBooks",
                schema: "Shopping",
                table: "LibaryBooks");

            migrationBuilder.DropIndex(
                name: "IX_LibaryBooks_Name",
                schema: "Shopping",
                table: "LibaryBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerNotes",
                schema: "dbo",
                table: "CustomerNotes");

            migrationBuilder.DropColumn(
                name: "ISBN",
                schema: "Shopping",
                table: "LibaryBooks");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "Shopping",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Libaries",
                schema: "Shopping",
                newName: "Libaries");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "Shopping",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "LibaryBooks",
                schema: "Shopping",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "CustomerNotes",
                schema: "dbo",
                newName: "Customer_Notes");

            migrationBuilder.RenameIndex(
                name: "IX_LibaryBooks_PrimaryLibraryId",
                table: "Books",
                newName: "IX_Books_PrimaryLibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_LibaryBooks_OnLoanLibraryId",
                table: "Books",
                newName: "IX_Books_OnLoanLibraryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Notes",
                table: "Customer_Notes",
                column: "Note_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Libaries_OnLoanLibraryId",
                table: "Books",
                column: "OnLoanLibraryId",
                principalTable: "Libaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Libaries_PrimaryLibraryId",
                table: "Books",
                column: "PrimaryLibraryId",
                principalTable: "Libaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
