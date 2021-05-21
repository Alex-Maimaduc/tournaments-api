using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class RenamedMatchField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_SecondPlyaerId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SecondPlyaerId",
                table: "Matches",
                newName: "SecondPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SecondPlyaerId",
                table: "Matches",
                newName: "IX_Matches_SecondPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_SecondPlayerId",
                table: "Matches",
                column: "SecondPlayerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_SecondPlayerId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SecondPlayerId",
                table: "Matches",
                newName: "SecondPlyaerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SecondPlayerId",
                table: "Matches",
                newName: "IX_Matches_SecondPlyaerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_SecondPlyaerId",
                table: "Matches",
                column: "SecondPlyaerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
