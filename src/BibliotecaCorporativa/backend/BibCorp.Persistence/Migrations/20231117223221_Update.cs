using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibCorp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acervos_Emprestimos_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Acervos");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrimonios_Emprestimos_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Patrimonios");

            migrationBuilder.DropIndex(
                name: "IX_Patrimonios_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Patrimonios");

            migrationBuilder.DropIndex(
                name: "IX_Acervos_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Acervos");

            migrationBuilder.DropColumn(
                name: "EmprestimoAcervoId",
                table: "Patrimonios");

            migrationBuilder.DropColumn(
                name: "EmprestimoPatrimonioId",
                table: "Patrimonios");

            migrationBuilder.DropColumn(
                name: "EmprestimoAcervoId",
                table: "Acervos");

            migrationBuilder.DropColumn(
                name: "EmprestimoPatrimonioId",
                table: "Acervos");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_PatrimonioId",
                table: "Emprestimos",
                column: "PatrimonioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Acervos_AcervoId",
                table: "Emprestimos",
                column: "AcervoId",
                principalTable: "Acervos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Patrimonios_PatrimonioId",
                table: "Emprestimos",
                column: "PatrimonioId",
                principalTable: "Patrimonios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Acervos_AcervoId",
                table: "Emprestimos");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Patrimonios_PatrimonioId",
                table: "Emprestimos");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimos_PatrimonioId",
                table: "Emprestimos");

            migrationBuilder.AddColumn<int>(
                name: "EmprestimoAcervoId",
                table: "Patrimonios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmprestimoPatrimonioId",
                table: "Patrimonios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmprestimoAcervoId",
                table: "Acervos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmprestimoPatrimonioId",
                table: "Acervos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Patrimonios",
                columns: new[] { "EmprestimoAcervoId", "EmprestimoPatrimonioId" });

            migrationBuilder.CreateIndex(
                name: "IX_Acervos_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Acervos",
                columns: new[] { "EmprestimoAcervoId", "EmprestimoPatrimonioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Acervos_Emprestimos_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Acervos",
                columns: new[] { "EmprestimoAcervoId", "EmprestimoPatrimonioId" },
                principalTable: "Emprestimos",
                principalColumns: new[] { "AcervoId", "PatrimonioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Patrimonios_Emprestimos_EmprestimoAcervoId_EmprestimoPatrimonioId",
                table: "Patrimonios",
                columns: new[] { "EmprestimoAcervoId", "EmprestimoPatrimonioId" },
                principalTable: "Emprestimos",
                principalColumns: new[] { "AcervoId", "PatrimonioId" });
        }
    }
}
