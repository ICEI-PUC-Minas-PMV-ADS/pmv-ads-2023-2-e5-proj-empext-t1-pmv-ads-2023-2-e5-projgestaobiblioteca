using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain.Biblioteca
{
    public class Emprestimo // PATRIMONIO/USUARIO
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int? AcervoId { get; set; }
        public Acervo? Acervo { get; set; }
        public int? PatrimonioId { get; set; }
        public Patrimonio? Patrimonio { get; set; }
        public bool? Devolvido { get; set; }
        public DateTime? DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int? DiasAtraso { get; set; }
        public int? DiasAlocacao { get; set; }
    }
}