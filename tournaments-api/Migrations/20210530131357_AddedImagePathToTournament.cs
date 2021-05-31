using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class AddedImagePathToTournament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Tournaments");
        }
    }
}
