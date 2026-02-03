using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace umami.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class tabelaVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VENDA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA_VENDA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<bool>(type: "bit", nullable: false),
                    SEQUSUARIO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VENDA_USUARIO_SEQUSUARIO",
                        column: x => x.SEQUSUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VENDA_SEQUSUARIO",
                table: "VENDA",
                column: "SEQUSUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VENDA");
        }
    }
}
