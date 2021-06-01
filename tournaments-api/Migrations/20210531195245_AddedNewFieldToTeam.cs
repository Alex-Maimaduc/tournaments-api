using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class AddedNewFieldToTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstPlayerScore",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstTeamScore",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatchTeams_WinnerId",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondPlayerScore",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondTeamScore",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WinnerId",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "FirstPlayerScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "FirstTeamScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "MatchTeams_WinnerId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SecondPlayerScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SecondTeamScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Matches");
        }
    }
}
