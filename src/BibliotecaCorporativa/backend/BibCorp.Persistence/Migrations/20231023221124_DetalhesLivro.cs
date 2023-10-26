using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibCorp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DetalhesLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "Acervos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QtdPaginas",
                table: "Acervos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Acervos");

            migrationBuilder.DropColumn(
                name: "QtdPaginas",
                table: "Acervos");
        }
    }
}
