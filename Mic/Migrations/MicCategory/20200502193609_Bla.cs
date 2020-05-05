using Microsoft.EntityFrameworkCore.Migrations;

namespace Mic.Migrations.MicCategory
{
    public partial class Bla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Castrated",
                table: "Cat",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Castrated",
                table: "Cat");
        }
    }
}
