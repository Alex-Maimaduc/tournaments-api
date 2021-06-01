using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class AddedNewFieldInUsersAndGym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GymId",
                table: "Users",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gyms_GymId",
                table: "Users",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gyms_GymId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GymId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Users");
        }
    }
}
