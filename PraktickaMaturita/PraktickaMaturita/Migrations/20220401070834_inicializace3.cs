using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraktickaMaturita.Migrations
{
    public partial class inicializace3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uzivatele",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Heslo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzivatele", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poznamky",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nadpis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Popis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vlozeni = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poznamky", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poznamky_Uzivatele_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Uzivatele",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poznamky_AutorId",
                table: "Poznamky",
                column: "AutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poznamky");

            migrationBuilder.DropTable(
                name: "Uzivatele");
        }
    }
}
