using Microsoft.EntityFrameworkCore.Migrations;

namespace champi.Migrations
{
    public partial class deleteUserToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Security",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Security",
                table: "User");
        }
    }
}
