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
        public Status Status { get; set; }
        public string DataEmprestimo { get; set; }
        public string DataPrevistaDevolucao { get; set; }
        public int  QtdeDiasEmprestimo { get; set; }
        public string DataDevolucao { get; set; }
        public int QtdeDiasAtraso { get; set; }
        public int AcervoId { get; set; }
        public Acervo Acervo { get; set; }
        public int PatrimonioId { get; set; }
        public Patrimonio Patrimonio { get; set; }
        public string LocalDeColeta { get; set;}
        public string LocalDeEntrega { get; set;}
    }

    public enum Status
    {
        Reservado = 1,
        Emprestado = 2,
        Devolvido = 3,
        Renovado = 4
    }
}
