using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibCorp.API.Models
{
    public class Acervo
    {
        public int Id { get; set; }
        public string Patrimonio { get; set; }
        public string NomeLivro { get; set; }
        public string Autores { get; set; }
        public string Resumo { get; set; }
        public string ISBN { get; set; }
        public string  AnoPublicacao { get; set; }
        public string AcervoUrl { get; set; }
        public string DataCadastro { get; set; }
        public string DataSuspensão { get; set; }
        public bool AcertoAtivo { get; set; }
    }
}