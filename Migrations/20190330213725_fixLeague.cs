using Microsoft.EntityFrameworkCore.Migrations;

namespace champi.Migrations
{
    public partial class fixLeague : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrawPoint",
                schema: "Competition",
                table: "League",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LostPoint",
                schema: "Competition",
                table: "League",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WonPoint",
                schema: "Competition",
                table: "League",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrawPoint",
                schema: "Competition",
                table: "League");

            migrationBuilder.DropColumn(
                name: "LostPoint",
                schema: "Competition",
                table: "League");

            migrationBuilder.DropColumn(
                name: "WonPoint",
                schema: "Competition",
                table: "League");
        }
    }
}
