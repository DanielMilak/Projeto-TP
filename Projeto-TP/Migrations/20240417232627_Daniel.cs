using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_TP.Migrations
{
    /// <inheritdoc />
    public partial class Daniel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comprador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sexo = table.Column<string>(type: "TEXT", nullable: false),
                    DtNasc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cancelado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Local = table.Column<string>(type: "TEXT", nullable: false),
                    Atracao = table.Column<string>(type: "TEXT", nullable: false),
                    ValorIngresso = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cancelado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompradorId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Extornado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Comprador_CompradorId",
                        column: x => x.CompradorId,
                        principalTable: "Comprador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Venda_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venda_CompradorId",
                table: "Venda",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_EventoId",
                table: "Venda",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Comprador");
        }
    }
}
