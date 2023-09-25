using System;

namespace ProEventos.Domain.Biblioteca
{
    public class Acervo
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Subtitulo { get; set; }
        public string? Categoria { get; set; }
        public int? ISBN { get; set; }
        public string? Resumo { get; set; }
        public DateTime? AnoPublicacao { get; set; }
        public int? QuantidadeDisponivel { get; set; }
        public int? QuantidadeTransito { get; set; }
        public int? QuantidadeAlocada { get; set; }
        public string? Capa { get; set; }
        public int? PatrimonioId { get; set; }
        public Patrimonio? Patrimonio { get; set; }
    }
}