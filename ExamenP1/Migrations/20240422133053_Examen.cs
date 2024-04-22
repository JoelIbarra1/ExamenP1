using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenP1.Migrations
{
    /// <inheritdoc />
    public partial class Examen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JIbarra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Madrilista = table.Column<bool>(type: "bit", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JIbarra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NombreCarrera = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Campus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroSemestres = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrera_JIbarra_Id",
                        column: x => x.Id,
                        principalTable: "JIbarra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "JIbarra");
        }
    }
}
