using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain.Biblioteca
{
    public class Patrimonio
    {
        public int Id { get; set; }  
        public string? Local { get; set; }  
        public int? Sala { get; set; }
        public int? Coluna { get; set; }
        public int? Prateleira { get; set; }
        public int? Posicao { get; set; }
        public string? Titulo { get; set; }
        public string? ISBN { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? Cadastro { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
        public IEnumerable<Emprestimo>? Emprestimos { get; set; }
        }
}