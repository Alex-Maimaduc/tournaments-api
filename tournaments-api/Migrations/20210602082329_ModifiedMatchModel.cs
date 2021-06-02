using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class ModifiedMatchModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstTeamScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SecondTeamScore",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "MatchTeams_WinnerId",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstScore",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondScore",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Matches",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SecondScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Matches");

            migrationBuilder.AlterColumn<string>(
                name: "MatchTeams_WinnerId",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstTeamScore",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondTeamScore",
                table: "Matches",
                type: "int",
                nullable: true);
        }
    }
}
