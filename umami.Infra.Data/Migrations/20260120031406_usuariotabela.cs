using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace umami.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class usuariotabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CELULAR = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NUMENDERECO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    COMPLEMENTO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SEQTIPOUSUARIO = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_TIPOUSUARIO_SEQTIPOUSUARIO",
                        column: x => x.SEQTIPOUSUARIO,
                        principalTable: "TIPOUSUARIO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_SEQTIPOUSUARIO",
                table: "USUARIO",
                column: "SEQTIPOUSUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
