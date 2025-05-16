using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntrenosApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaEntramientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorVisual = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaEntramientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entrenamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Intensidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Completado = table.Column<bool>(type: "bit", nullable: false),
                    PuntosExperencia = table.Column<int>(type: "int", nullable: false),
                    CategoriaEntrenamientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrenamientos_CategoriaEntramientos_CategoriaEntrenamientoId",
                        column: x => x.CategoriaEntrenamientoId,
                        principalTable: "CategoriaEntramientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrenamientos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrenamientos_CategoriaEntrenamientoId",
                table: "Entrenamientos",
                column: "CategoriaEntrenamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenamientos_UsuarioId",
                table: "Entrenamientos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrenamientos");

            migrationBuilder.DropTable(
                name: "CategoriaEntramientos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
