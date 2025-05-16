using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntrenosApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPassToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pass",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pass",
                table: "Usuarios");
        }
    }
}
