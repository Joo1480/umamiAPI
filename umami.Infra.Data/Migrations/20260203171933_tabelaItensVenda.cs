using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace umami.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class tabelaItensVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ITENSVENDA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QUANT = table.Column<int>(type: "int", nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SEQPRODUTO = table.Column<int>(type: "int", nullable: false),
                    SEQVENDA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITENSVENDA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ITENSVENDA_PRODUTO_SEQPRODUTO",
                        column: x => x.SEQPRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ITENSVENDA_VENDA_SEQVENDA",
                        column: x => x.SEQVENDA,
                        principalTable: "VENDA",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITENSVENDA_SEQPRODUTO",
                table: "ITENSVENDA",
                column: "SEQPRODUTO");

            migrationBuilder.CreateIndex(
                name: "IX_ITENSVENDA_SEQVENDA",
                table: "ITENSVENDA",
                column: "SEQVENDA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITENSVENDA");
        }
    }
}
