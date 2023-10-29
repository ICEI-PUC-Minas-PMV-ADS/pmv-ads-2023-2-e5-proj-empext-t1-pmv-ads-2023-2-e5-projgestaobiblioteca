using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Domain.Models.Acervos;

namespace BibCorp.Domain.Models.Patrimonios
{
    public class Patrimonio
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public string Sala { get; set; }
        public string Coluna { get; set; }
        public string Prateleira { get; set; }
        public string Posicao { get; set; }
        public string ISBN { get; set; }
        public bool Status { get; set; }
        public string DataCadastro { get; set; }
        public string DataAtualizacao { get; set; }
        public string DataIndisponibilidade { get; set; }
        public int? AcervoId { get; set; }
        public Acervo Acervo { get; set; }
    }
}