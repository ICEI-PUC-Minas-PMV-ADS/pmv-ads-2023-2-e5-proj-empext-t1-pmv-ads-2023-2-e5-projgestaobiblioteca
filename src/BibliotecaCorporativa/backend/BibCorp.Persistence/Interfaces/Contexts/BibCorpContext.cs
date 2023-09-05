using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Domain.Models.Acervos;
using BibCorp.Domain.Models.Patrimonios;
using BibCorp.Domain.Models.Emprestimos;
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
            modelBuilder.Entity<Emprestimo>()
                .HasKey(e => new {e.AcervoId, e.PatrimonioId});
        }
    }
}
