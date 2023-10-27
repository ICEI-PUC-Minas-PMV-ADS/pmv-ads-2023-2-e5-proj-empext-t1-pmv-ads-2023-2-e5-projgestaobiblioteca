using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibCorp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetalheOrgiem",
                table: "Patrimonios");

            migrationBuilder.DropColumn(
                name: "Origem",
                table: "Patrimonios");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Patrimonios",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Patrimonios",
                newName: "Ativo");

            migrationBuilder.AddColumn<string>(
                name: "DetalheOrgiem",
                table: "Patrimonios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origem",
                table: "Patrimonios",
                type: "TEXT",
                nullable: true);
        }
    }
}
