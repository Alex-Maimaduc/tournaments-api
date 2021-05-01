using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class CreatedSportUser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SportUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SportUsers_SportId",
                table: "SportUsers",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_SportUsers_UserId",
                table: "SportUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportUsers_Sports_SportId",
                table: "SportUsers",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportUsers_Users_UserId",
                table: "SportUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportUsers_Sports_SportId",
                table: "SportUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SportUsers_Users_UserId",
                table: "SportUsers");

            migrationBuilder.DropIndex(
                name: "IX_SportUsers_SportId",
                table: "SportUsers");

            migrationBuilder.DropIndex(
                name: "IX_SportUsers_UserId",
                table: "SportUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SportUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
