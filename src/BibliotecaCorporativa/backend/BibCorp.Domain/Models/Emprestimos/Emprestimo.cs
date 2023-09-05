using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Domain.Models.Acervos;
using BibCorp.Domain.Models.Patrimonios;

namespace BibCorp.Domain.Models.Emprestimos
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool Devolvido { get; set; }
        public string DataEmprestimo { get; set; }
        public string DataPrevistaDevolucao { get; set; }
        public int  QtdeDiasEmprestimo { get; set; }
        public string DataDevolucao { get; set; }
        public int QtdeDiasAtraso { get; set; }
        public string AcervoId { get; set; }
        public IEnumerable<Acervo> Acervos { get; set; }
        public string PatrimonioId { get; set; }
        public IEnumerable<Patrimonio> Patrimonios { get; set; }
    }
}