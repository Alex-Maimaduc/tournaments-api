using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class AddedUsersToSports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "SportUser",
                columns: table => new
                {
                    FavoriteSportsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportUser", x => new { x.FavoriteSportsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SportUser_Sports_FavoriteSportsId",
                        column: x => x.FavoriteSportsId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportUser_UsersId",
                table: "SportUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportUser");

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
    }
}
