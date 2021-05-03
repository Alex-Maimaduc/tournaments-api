using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class AddedTeamImagePAth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportId",
                table: "Teams",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Sports_SportId",
                table: "Teams",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Sports_SportId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_SportId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Teams");
        }
    }
}
