using Microsoft.EntityFrameworkCore.Migrations;

namespace champi.Migrations
{
    public partial class fixLeagueMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LeagueId",
                schema: "Competition",
                table: "LeagueMatch",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_LeagueMatch_LeagueId",
                schema: "Competition",
                table: "LeagueMatch",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueMatch_League_LeagueId",
                schema: "Competition",
                table: "LeagueMatch",
                column: "LeagueId",
                principalSchema: "Competition",
                principalTable: "League",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueMatch_League_LeagueId",
                schema: "Competition",
                table: "LeagueMatch");

            migrationBuilder.DropIndex(
                name: "IX_LeagueMatch_LeagueId",
                schema: "Competition",
                table: "LeagueMatch");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                schema: "Competition",
                table: "LeagueMatch");
        }
    }
}
