using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraktickaMaturita.Migrations
{
    public partial class DatumTed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vlozeni",
                table: "Poznamky",
                newName: "DatumVlozeni");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatumVlozeni",
                table: "Poznamky",
                newName: "Vlozeni");
        }
    }
}
