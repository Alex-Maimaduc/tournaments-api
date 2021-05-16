using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class UpdatedTeams3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstPlayerId",
                table: "Matches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstTeamId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondPlyaerId",
                table: "Matches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondTeamId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FirstPlayerId",
                table: "Matches",
                column: "FirstPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FirstTeamId",
                table: "Matches",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SecondPlyaerId",
                table: "Matches",
                column: "SecondPlyaerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SecondTeamId",
                table: "Matches",
                column: "SecondTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_FirstTeamId",
                table: "Matches",
                column: "FirstTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_SecondTeamId",
                table: "Matches",
                column: "SecondTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_FirstPlayerId",
                table: "Matches",
                column: "FirstPlayerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_SecondPlyaerId",
                table: "Matches",
                column: "SecondPlyaerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_FirstTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_SecondTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_FirstPlayerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_SecondPlyaerId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_FirstPlayerId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_FirstTeamId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_SecondPlyaerId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_SecondTeamId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "FirstPlayerId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "FirstTeamId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SecondPlyaerId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SecondTeamId",
                table: "Matches");
        }
    }
}
