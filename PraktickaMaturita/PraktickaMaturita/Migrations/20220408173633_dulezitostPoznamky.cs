using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraktickaMaturita.Migrations
{
    public partial class dulezitostPoznamky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Dulezitost",
                table: "Poznamky",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dulezitost",
                table: "Poznamky");
        }
    }
}
