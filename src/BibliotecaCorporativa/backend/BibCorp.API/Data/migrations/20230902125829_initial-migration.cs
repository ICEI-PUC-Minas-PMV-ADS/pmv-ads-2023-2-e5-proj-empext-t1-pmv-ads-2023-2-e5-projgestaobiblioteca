using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibCorp.API.data.migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acervos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Patrimonio = table.Column<string>(type: "TEXT", nullable: true),
                    NomeLivro = table.Column<string>(type: "TEXT", nullable: true),
                    Autores = table.Column<string>(type: "TEXT", nullable: true),
                    Resumo = table.Column<string>(type: "TEXT", nullable: true),
                    ISBN = table.Column<string>(type: "TEXT", nullable: true),
                    AnoPublicacao = table.Column<string>(type: "TEXT", nullable: true),
                    AcervoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    DataCadastro = table.Column<string>(type: "TEXT", nullable: true),
                    DataSuspensão = table.Column<string>(type: "TEXT", nullable: true),
                    AcertoAtivo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acervos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acervos");
        }
    }
}
