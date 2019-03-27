using Microsoft.EntityFrameworkCore.Migrations;

namespace champi.Migrations
{
    public partial class LeagueResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Draw",
                schema: "Competition",
                table: "LeagueResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalDifference",
                schema: "Competition",
                table: "LeagueResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsAgainst",
                schema: "Competition",
                table: "LeagueResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsFor",
                schema: "Competition",
                table: "LeagueResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lost",
                schema: "Competition",
                table: "LeagueResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Played",
                schema: "Competition",
                table: "LeagueResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                schema: "Competition",
                table: "LeagueResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreviousPosition",
                schema: "Competition",
                table: "LeagueResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Won",
                schema: "Competition",
                table: "LeagueResult",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Draw",
                schema: "Competition",
                table: "LeagueResult");

            migrationBuilder.DropColumn(
                name: "GoalDifference",
                schema: "Competition",
                table: "LeagueResult");

            migrationBuilder.DropColumn(
                name: "GoalsAgainst",
                schema: "Competition",
                table: "LeagueResult");

            migrationBuilder.DropColumn(
                name: "GoalsFor",
                schema: "Competition",
                table: "LeagueResult");

            migrationBuilder.DropColumn(
                name: "Lost",
                schema: "Competition",
                table: "LeagueResult");

            migrationBuilder.DropColumn(
                name: "Played",
                schema: "Competition",
                table: "LeagueResult");

            migrationBuilder.DropColumn(
                name: "Points",
                schema: "Competition",
                table: "LeagueResult");

            migrationBuilder.DropColumn(
                name: "PreviousPosition",
                schema: "Competition",
                table: "LeagueResult");

            migrationBuilder.DropColumn(
                name: "Won",
                schema: "Competition",
                table: "LeagueResult");
        }
    }
}
