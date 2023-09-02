using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BibCorp.API.Data
{
    public class BibCorpContext : DbContext 
    {
        public BibCorpContext(DbContextOptions<BibCorpContext> options) : base(options)
        {
            
        }
         public DbSet<Acervo> Acervos { get; set; }
    }
}