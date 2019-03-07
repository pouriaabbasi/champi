using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace champi.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Competition");

            migrationBuilder.CreateTable(
                name: "GameType",
                schema: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ParentGameTypeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameType_GameType_ParentGameTypeId",
                        column: x => x.ParentGameTypeId,
                        principalSchema: "Competition",
                        principalTable: "GameType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    AbbreviationName = table.Column<string>(maxLength: 10, nullable: true),
                    Logo = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                schema: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameTypeId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Iteration = table.Column<int>(nullable: false),
                    TeamCount = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsStarted = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    ChampionTeamId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competition_Team_ChampionTeamId",
                        column: x => x.ChampionTeamId,
                        principalSchema: "Competition",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competition_GameType_GameTypeId",
                        column: x => x.GameTypeId,
                        principalSchema: "Competition",
                        principalTable: "GameType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionStep",
                schema: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompetitionId = table.Column<long>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    CompetitionType = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsStarted = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionStep_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalSchema: "Competition",
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionTeam",
                schema: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompetitionId = table.Column<long>(nullable: false),
                    TeamId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalSchema: "Competition",
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "Competition",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "League",
                schema: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompetitionStepId = table.Column<long>(nullable: false),
                    TeamCount = table.Column<int>(nullable: false),
                    IsHomeAway = table.Column<bool>(nullable: false),
                    PeerToPeerPlayCount = table.Column<int>(nullable: false),
                    RiseTeamCount = table.Column<int>(nullable: false),
                    FallTeamCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.Id);
                    table.ForeignKey(
                        name: "FK_League_CompetitionStep_CompetitionStepId",
                        column: x => x.CompetitionStepId,
                        principalSchema: "Competition",
                        principalTable: "CompetitionStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeagueTeam",
                schema: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeagueId = table.Column<long>(nullable: false),
                    CompetitionTeamId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeagueTeam_CompetitionTeam_CompetitionTeamId",
                        column: x => x.CompetitionTeamId,
                        principalSchema: "Competition",
                        principalTable: "CompetitionTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeagueTeam_League_LeagueId",
                        column: x => x.LeagueId,
                        principalSchema: "Competition",
                        principalTable: "League",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeagueMatch",
                schema: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstTeamId = table.Column<long>(nullable: false),
                    SecondTeamId = table.Column<long>(nullable: false),
                    FirstTeamScore = table.Column<int>(nullable: true),
                    SecondTeamScore = table.Column<int>(nullable: true),
                    WinnerTeamId = table.Column<long>(nullable: true),
                    MatchDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueMatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeagueMatch_LeagueTeam_FirstTeamId",
                        column: x => x.FirstTeamId,
                        principalSchema: "Competition",
                        principalTable: "LeagueTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeagueMatch_LeagueTeam_SecondTeamId",
                        column: x => x.SecondTeamId,
                        principalSchema: "Competition",
                        principalTable: "LeagueTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeagueMatch_LeagueTeam_WinnerTeamId",
                        column: x => x.WinnerTeamId,
                        principalSchema: "Competition",
                        principalTable: "LeagueTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeagueResult",
                schema: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeagueId = table.Column<long>(nullable: false),
                    LeagueTeamId = table.Column<long>(nullable: false),
                    LeagueResultType = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeagueResult_League_LeagueId",
                        column: x => x.LeagueId,
                        principalSchema: "Competition",
                        principalTable: "League",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeagueResult_LeagueTeam_LeagueTeamId",
                        column: x => x.LeagueTeamId,
                        principalSchema: "Competition",
                        principalTable: "LeagueTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competition_ChampionTeamId",
                schema: "Competition",
                table: "Competition",
                column: "ChampionTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_GameTypeId",
                schema: "Competition",
                table: "Competition",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionStep_CompetitionId",
                schema: "Competition",
                table: "CompetitionStep",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTeam_CompetitionId",
                schema: "Competition",
                table: "CompetitionTeam",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTeam_TeamId",
                schema: "Competition",
                table: "CompetitionTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_GameType_ParentGameTypeId",
                schema: "Competition",
                table: "GameType",
                column: "ParentGameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_League_CompetitionStepId",
                schema: "Competition",
                table: "League",
                column: "CompetitionStepId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueMatch_FirstTeamId",
                schema: "Competition",
                table: "LeagueMatch",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueMatch_SecondTeamId",
                schema: "Competition",
                table: "LeagueMatch",
                column: "SecondTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueMatch_WinnerTeamId",
                schema: "Competition",
                table: "LeagueMatch",
                column: "WinnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueResult_LeagueId",
                schema: "Competition",
                table: "LeagueResult",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueResult_LeagueTeamId",
                schema: "Competition",
                table: "LeagueResult",
                column: "LeagueTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueTeam_CompetitionTeamId",
                schema: "Competition",
                table: "LeagueTeam",
                column: "CompetitionTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueTeam_LeagueId",
                schema: "Competition",
                table: "LeagueTeam",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueMatch",
                schema: "Competition");

            migrationBuilder.DropTable(
                name: "LeagueResult",
                schema: "Competition");

            migrationBuilder.DropTable(
                name: "LeagueTeam",
                schema: "Competition");

            migrationBuilder.DropTable(
                name: "CompetitionTeam",
                schema: "Competition");

            migrationBuilder.DropTable(
                name: "League",
                schema: "Competition");

            migrationBuilder.DropTable(
                name: "CompetitionStep",
                schema: "Competition");

            migrationBuilder.DropTable(
                name: "Competition",
                schema: "Competition");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "Competition");

            migrationBuilder.DropTable(
                name: "GameType",
                schema: "Competition");
        }
    }
}
