using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class RevertModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_AspNetUsers_ApplicationUserId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_ApplicationUserId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Checkouts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_ApplicationUserId",
                table: "Checkouts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_AspNetUsers_ApplicationUserId",
                table: "Checkouts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
