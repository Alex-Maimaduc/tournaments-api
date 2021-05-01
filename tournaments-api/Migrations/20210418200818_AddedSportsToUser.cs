using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class AddedSportsToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Sports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sports_UserId",
                table: "Sports",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Users_UserId",
                table: "Sports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Users_UserId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sports_UserId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sports");
        }
    }
}
