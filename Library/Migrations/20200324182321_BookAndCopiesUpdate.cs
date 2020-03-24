using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class BookAndCopiesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Copies_CopyId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CopyId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CopyId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Copies_BookId",
                table: "Copies",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Books_BookId",
                table: "Copies",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Books_BookId",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Copies_BookId",
                table: "Copies");

            migrationBuilder.AddColumn<int>(
                name: "CopyId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CopyId",
                table: "Books",
                column: "CopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Copies_CopyId",
                table: "Books",
                column: "CopyId",
                principalTable: "Copies",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
