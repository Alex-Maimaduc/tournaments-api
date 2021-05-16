using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tournaments_api.Migrations
{
    public partial class UpdatedTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchesPlayers");

            migrationBuilder.DropTable(
                name: "MatchTeams");

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Id",
                table: "Matches",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SportId",
                table: "Matches",
                column: "SportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.CreateTable(
                name: "MatchesPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstPlayerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SecondPlyaerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchesPlayers_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchesPlayers_Users_FirstPlayerId",
                        column: x => x.FirstPlayerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchesPlayers_Users_SecondPlyaerId",
                        column: x => x.SecondPlyaerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstTeamId = table.Column<int>(type: "int", nullable: true),
                    SecondTeamId = table.Column<int>(type: "int", nullable: true),
                    SportId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchTeams_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchTeams_Teams_FirstTeamId",
                        column: x => x.FirstTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchTeams_Teams_SecondTeamId",
                        column: x => x.SecondTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchesPlayers_FirstPlayerId",
                table: "MatchesPlayers",
                column: "FirstPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesPlayers_Id",
                table: "MatchesPlayers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchesPlayers_SecondPlyaerId",
                table: "MatchesPlayers",
                column: "SecondPlyaerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesPlayers_SportId",
                table: "MatchesPlayers",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchTeams_FirstTeamId",
                table: "MatchTeams",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchTeams_Id",
                table: "MatchTeams",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchTeams_SecondTeamId",
                table: "MatchTeams",
                column: "SecondTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchTeams_SportId",
                table: "MatchTeams",
                column: "SportId");
        }
    }
}
