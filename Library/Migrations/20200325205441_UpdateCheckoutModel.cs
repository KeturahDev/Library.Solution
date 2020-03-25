using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class UpdateCheckoutModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_CopyId",
                table: "Checkouts",
                column: "CopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Copies_CopyId",
                table: "Checkouts",
                column: "CopyId",
                principalTable: "Copies",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Copies_CopyId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_CopyId",
                table: "Checkouts");

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
    }
}
