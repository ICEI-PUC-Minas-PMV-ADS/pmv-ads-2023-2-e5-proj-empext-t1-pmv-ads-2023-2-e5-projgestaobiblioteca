using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibCorp.Persistence.Migrations
{
  /// <inheritdoc />
  public partial class UpdateStatus : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.RenameColumn(
          name: "Devolvido",
          table: "Emprestimos",
          newName: "Status");

      migrationBuilder.AddColumn<string>(
          name: "LocalDeColeta",
          table: "Emprestimos",
          type: "TEXT",
          nullable: true);

      migrationBuilder.AddColumn<string>(
          name: "LocalDeEntrega",
          table: "Emprestimos",
          type: "TEXT",
          nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "LocalDeColeta",
          table: "Emprestimos");

      migrationBuilder.DropColumn(
          name: "LocalDeEntrega",
          table: "Emprestimos");

      migrationBuilder.RenameColumn(
          name: "Status",
          table: "Emprestimos",
          newName: "Devolvido");
    }
  }
}
