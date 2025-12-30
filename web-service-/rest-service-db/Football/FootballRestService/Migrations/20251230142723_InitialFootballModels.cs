using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballRestService.Migrations
{
    public partial class InitialFootballModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    team_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.team_id);
                });

            migrationBuilder.CreateTable(
                name: "match",
                columns: table => new
                {
                    match_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    home_team_id = table.Column<int>(type: "int", nullable: false),
                    away_team_id = table.Column<int>(type: "int", nullable: false),
                    match_date = table.Column<DateTime>(type: "date", nullable: false),
                    home_score = table.Column<int>(type: "int", nullable: true),
                    away_score = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_match", x => x.match_id);
                    table.ForeignKey(
                        name: "FK_match_team_away_team_id",
                        column: x => x.away_team_id,
                        principalTable: "team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_match_team_home_team_id",
                        column: x => x.home_team_id,
                        principalTable: "team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    player_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false),
                    position = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    team_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.player_id);
                    table.ForeignKey(
                        name: "FK_player_team_team_id",
                        column: x => x.team_id,
                        principalTable: "team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_match_away_team_id",
                table: "match",
                column: "away_team_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_home_team_id",
                table: "match",
                column: "home_team_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_team_id",
                table: "player",
                column: "team_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "match");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "team");
        }
    }
}
