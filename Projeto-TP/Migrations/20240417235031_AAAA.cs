using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_TP.Migrations
{
    /// <inheritdoc />
    public partial class AAAA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Extornado",
                table: "Venda",
                newName: "Estornado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estornado",
                table: "Venda",
                newName: "Extornado");
        }
    }
}
