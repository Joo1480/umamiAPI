using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace umami.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PAGAMENTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA_PAGAMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VALOR_PAGAMENTO = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    SEQTIPOPAGAMENTO = table.Column<int>(type: "int", nullable: false),
                    SEQVENDA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGAMENTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PAGAMENTO_TIPOPAGAMENTO_SEQTIPOPAGAMENTO",
                        column: x => x.SEQTIPOPAGAMENTO,
                        principalTable: "TIPOPAGAMENTO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PAGAMENTO_VENDA_SEQVENDA",
                        column: x => x.SEQVENDA,
                        principalTable: "VENDA",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PAGAMENTO_SEQTIPOPAGAMENTO",
                table: "PAGAMENTO",
                column: "SEQTIPOPAGAMENTO");

            migrationBuilder.CreateIndex(
                name: "IX_PAGAMENTO_SEQVENDA",
                table: "PAGAMENTO",
                column: "SEQVENDA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAGAMENTO");
        }
    }
}
