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
                    AcervoId = table.Column<string>(type: "TEXT", nullable: false),
                    PatrimonioId = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Devolvido = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataEmprestimo = table.Column<string>(type: "TEXT", nullable: false),
                    DataPrevistaDevolucao = table.Column<string>(type: "TEXT", nullable: false),
                    QtdeDiasEmprestimo = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDevolucao = table.Column<string>(type: "TEXT", nullable: false),
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
                    PatrimonioId = table.Column<string>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    SubTitulo = table.Column<string>(type: "TEXT", nullable: false),
                    Resumo = table.Column<string>(type: "TEXT", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "TEXT", nullable: false),
                    Editora = table.Column<string>(type: "TEXT", nullable: false),
                    Edicao = table.Column<string>(type: "TEXT", nullable: false),
                    CapaUrl = table.Column<string>(type: "TEXT", nullable: false),
                    QtdeDisponivel = table.Column<int>(type: "INTEGER", nullable: false),
                    QtdeEmTransito = table.Column<int>(type: "INTEGER", nullable: false),
                    QtdeEmprestada = table.Column<int>(type: "INTEGER", nullable: false),
                    EmprestimoAcervoId = table.Column<string>(type: "TEXT", nullable: true),
                    EmprestimoPatrimonioId = table.Column<string>(type: "TEXT", nullable: true)
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
                    Localizacao = table.Column<string>(type: "TEXT", nullable: false),
                    Sala = table.Column<string>(type: "TEXT", nullable: false),
                    Coluna = table.Column<string>(type: "TEXT", nullable: false),
                    Prateleira = table.Column<string>(type: "TEXT", nullable: false),
                    Posicao = table.Column<string>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Origem = table.Column<string>(type: "TEXT", nullable: false),
                    DetalheOrgiem = table.Column<string>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<string>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<string>(type: "TEXT", nullable: false),
                    DataIndisponibilidade = table.Column<string>(type: "TEXT", nullable: false),
                    AcervoId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmprestimoAcervoId = table.Column<string>(type: "TEXT", nullable: true),
                    EmprestimoPatrimonioId = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "IX_Patrimonios_AcervoId",
                table: "Patrimonios",
                column: "AcervoId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Patrimonios",
                columns: new[] { "EmprestimoAcervoId", "EmprestimoPatrimonioId" });
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
