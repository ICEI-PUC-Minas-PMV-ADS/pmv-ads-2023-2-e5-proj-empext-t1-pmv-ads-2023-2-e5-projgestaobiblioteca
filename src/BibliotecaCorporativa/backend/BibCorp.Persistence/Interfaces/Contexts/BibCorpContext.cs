
using BibCorp.Domain.Models.Acervos;
using BibCorp.Domain.Models.Emprestimos;
using BibCorp.Domain.Models.Patrimonios;
using BibCorp.Domain.Models.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BibCorp.Persistence.Interfaces.Contexts
{
  public class BibCorpContext : IdentityDbContext<Usuario,
                                                  Papel,
                                                  int,
                                                  IdentityUserClaim<int>,
                                                  UsuarioPapel,
                                                  IdentityUserLogin<int>,
                                                  IdentityRoleClaim<int>,
                                                  IdentityUserToken<int>>
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

// Identity Framework Core
      modelBuilder.Entity<UsuarioPapel>(
      usuarioPapel =>
      {
        usuarioPapel.HasKey(cf => new { cf.UserId, cf.RoleId });

        usuarioPapel.HasOne(cf => cf.Papel)
                        .WithMany(f => f.UsuariosPapeis)
                        .HasForeignKey(cf => cf.RoleId)
                        .IsRequired();

        usuarioPapel.HasOne(cf => cf.Usuario)
                        .WithMany(f => f.UsuariosPapeis)
                        .HasForeignKey(cf => cf.UserId)
                        .IsRequired();
      });
// Identity Framework Core

      modelBuilder.Entity<Emprestimo>(empresa =>
      {
        empresa.HasKey(e => new { e.AcervoId, e.PatrimonioId });
      });

      modelBuilder.Entity<Acervo>(acervo =>
      {
        acervo.HasIndex(a => a.PatrimonioId);
        acervo.HasIndex(a => a.ISBN);
      });

      modelBuilder.Entity<Patrimonio>(patrimonio =>
      {
        patrimonio.HasIndex(p => p.ISBN);
      });

      // modelBuilder.Entity<Emprestimo>()
      //           .HasKey(E => new {E.PatrimonioId, E.UsuarioId});
    }
  }
}
