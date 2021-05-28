using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class AddedGym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TournamentTeams_GymId",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchTeams_GymId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gyms_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_GymId",
                table: "Tournaments",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentTeams_GymId",
                table: "Tournaments",
                column: "TournamentTeams_GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GymId",
                table: "Matches",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchTeams_GymId",
                table: "Matches",
                column: "MatchTeams_GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_Id",
                table: "Gyms",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_OwnerId",
                table: "Gyms",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Gyms_GymId",
                table: "Matches",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Gyms_MatchTeams_GymId",
                table: "Matches",
                column: "MatchTeams_GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Gyms_GymId",
                table: "Tournaments",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Gyms_TournamentTeams_GymId",
                table: "Tournaments",
                column: "TournamentTeams_GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Gyms_GymId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Gyms_MatchTeams_GymId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Gyms_GymId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Gyms_TournamentTeams_GymId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_GymId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_TournamentTeams_GymId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Matches_GymId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_MatchTeams_GymId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "TournamentTeams_GymId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "MatchTeams_GymId",
                table: "Matches");
        }
    }
}
