using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class ModifiedMatchModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstPlayerScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SecondPlayerScore",
                table: "Matches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirstPlayerScore",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondPlayerScore",
                table: "Matches",
                type: "int",
                nullable: true);
        }
    }
}
