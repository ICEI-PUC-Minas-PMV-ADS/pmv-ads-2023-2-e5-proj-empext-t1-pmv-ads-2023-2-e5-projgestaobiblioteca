using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibCorp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    AcervoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PatrimonioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Devolvido = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataEmprestimo = table.Column<string>(type: "TEXT", nullable: true),
                    DataPrevistaDevolucao = table.Column<string>(type: "TEXT", nullable: true),
                    QtdeDiasEmprestimo = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDevolucao = table.Column<string>(type: "TEXT", nullable: true),
                    QtdeDiasAtraso = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => new { x.AcervoId, x.PatrimonioId });
                });

            migrationBuilder.CreateTable(
                name: "Acervos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatrimonioId = table.Column<int>(type: "INTEGER", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    SubTitulo = table.Column<string>(type: "TEXT", nullable: true),
                    Resumo = table.Column<string>(type: "TEXT", nullable: true),
                    AnoPublicacao = table.Column<string>(type: "TEXT", nullable: true),
                    Editora = table.Column<string>(type: "TEXT", nullable: true),
                    Edicao = table.Column<string>(type: "TEXT", nullable: true),
                    CapaUrl = table.Column<string>(type: "TEXT", nullable: true),
                    QtdeDisponivel = table.Column<int>(type: "INTEGER", nullable: false),
                    QtdeEmTransito = table.Column<int>(type: "INTEGER", nullable: false),
                    QtdeEmprestada = table.Column<int>(type: "INTEGER", nullable: false),
                    EmprestimoAcervoId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmprestimoPatrimonioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acervos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acervos_Emprestimos_EmprestimoAcervoId_EmprestimoPatrimonioId",
                        columns: x => new { x.EmprestimoAcervoId, x.EmprestimoPatrimonioId },
                        principalTable: "Emprestimos",
                        principalColumns: new[] { "AcervoId", "PatrimonioId" });
                });

            migrationBuilder.CreateTable(
                name: "Patrimonios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Localizacao = table.Column<string>(type: "TEXT", nullable: true),
                    Sala = table.Column<string>(type: "TEXT", nullable: true),
                    Coluna = table.Column<string>(type: "TEXT", nullable: true),
                    Prateleira = table.Column<string>(type: "TEXT", nullable: true),
                    Posicao = table.Column<string>(type: "TEXT", nullable: true),
                    ISBN = table.Column<string>(type: "TEXT", nullable: true),
                    Origem = table.Column<string>(type: "TEXT", nullable: true),
                    DetalheOrgiem = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<string>(type: "TEXT", nullable: true),
                    DataAtualizacao = table.Column<string>(type: "TEXT", nullable: true),
                    DataIndisponibilidade = table.Column<string>(type: "TEXT", nullable: true),
                    AcervoId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmprestimoAcervoId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmprestimoPatrimonioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimonios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrimonios_Acervos_AcervoId",
                        column: x => x.AcervoId,
                        principalTable: "Acervos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patrimonios_Emprestimos_EmprestimoAcervoId_EmprestimoPatrimonioId",
                        columns: x => new { x.EmprestimoAcervoId, x.EmprestimoPatrimonioId },
                        principalTable: "Emprestimos",
                        principalColumns: new[] { "AcervoId", "PatrimonioId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acervos_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Acervos",
                columns: new[] { "EmprestimoAcervoId", "EmprestimoPatrimonioId" });

            migrationBuilder.CreateIndex(
                name: "IX_Acervos_ISBN",
                table: "Acervos",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Acervos_PatrimonioId",
                table: "Acervos",
                column: "PatrimonioId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_AcervoId",
                table: "Patrimonios",
                column: "AcervoId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Patrimonios",
                columns: new[] { "EmprestimoAcervoId", "EmprestimoPatrimonioId" });

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_ISBN",
                table: "Patrimonios",
                column: "ISBN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patrimonios");

            migrationBuilder.DropTable(
                name: "Acervos");

            migrationBuilder.DropTable(
                name: "Emprestimos");
        }
    }
}
