using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class AddedGetSports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Sports");
        }
    }
}
