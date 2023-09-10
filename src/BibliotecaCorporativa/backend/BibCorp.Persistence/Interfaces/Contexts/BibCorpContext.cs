
using BibCorp.Domain.Models.Acervos;
using BibCorp.Domain.Models.Emprestimos;
using BibCorp.Domain.Models.Patrimonios;
using Microsoft.EntityFrameworkCore;

namespace BibCorp.Persistence.Interfaces.Contexts
{
  public class BibCorpContext : DbContext
  {
    public BibCorpContext(DbContextOptions<BibCorpContext> options) : base(options)
    {

    }
    public DbSet<Acervo> Acervos { get; set; }
    public DbSet<Patrimonio> Patrimonios { get; set; }
    public DbSet<Emprestimo> Emprestimos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Emprestimo>(empresa =>
      {
        empresa.HasKey(e => new { e.AcervoId, e.PatrimonioId });
      });

      modelBuilder.Entity<Acervo>( acervo =>
      {
        acervo.HasIndex(a => a.PatrimonioId);
        acervo.HasIndex(a => a.ISBN);
      });

      modelBuilder.Entity<Patrimonio>( patrimonio =>
      {
        patrimonio.HasIndex(p => p.ISBN);
      });
    }
  }
}
