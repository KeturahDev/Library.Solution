using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class AddBookPropertyToCheckout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Checkouts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_BookId",
                table: "Checkouts",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Books_BookId",
                table: "Checkouts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Books_BookId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_BookId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Checkouts");
        }
    }
}
