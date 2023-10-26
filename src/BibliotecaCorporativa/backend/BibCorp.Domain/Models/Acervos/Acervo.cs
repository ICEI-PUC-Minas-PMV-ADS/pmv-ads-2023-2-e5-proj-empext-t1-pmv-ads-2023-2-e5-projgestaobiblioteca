using System.Collections;
using BibCorp.Domain.Models.Patrimonios;


namespace BibCorp.Domain.Models.Acervos
{
    public class Acervo
    {
        public int Id { get; set; }
        public int PatrimonioId { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Resumo { get; set; }
        public string AnoPublicacao { get; set; }
        public string Editora { get; set; }
        public string Edicao { get; set; }
<<<<<<< Updated upstream
=======
        public int QtdPaginas { get; set; }
        public string Comentarios { get; set; }

        // Campo DataCriacao no forma AAAAMMDD
        public string DataCriacao { get; set; }
        public string Genero { get; set; }
>>>>>>> Stashed changes
        public string CapaUrl { get; set; }
        public int QtdeDisponivel { get; set; }
        public int QtdeEmTransito { get; set; }
        public int QtdeEmprestada { get; set; }
        public IEnumerable<Patrimonio> Patrimonios { get; set; }

    }
}
