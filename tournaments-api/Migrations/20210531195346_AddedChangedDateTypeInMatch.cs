using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class AddedChangedDateTypeInMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WinnerId",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TournamentTeams_WinnerId",
                table: "Tournaments",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TournamentTeams_WinnerId",
                table: "Tournaments");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "Tournaments",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
