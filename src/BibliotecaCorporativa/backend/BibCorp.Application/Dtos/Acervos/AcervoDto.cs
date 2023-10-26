using System.ComponentModel.DataAnnotations;
using BibCorp.Application.Dto.Patrimonios;


namespace BibCorp.Application.Dto.Acervos
{
  public class AcervoDto
<<<<<<< Updated upstream
    {
        public int Id { get; set; }
        public int PatrimonioId { get; set; }
        public string ISBN { get; set; }
        [Display(Name = "Título do Acervo"),
          Required(ErrorMessage = "Campo {0} deverá ser informado!")]
        public string Titulo { get; set; }
        [Display(Name = "Sub-título do Acervo"),
        Required(ErrorMessage = "Campo {0} deverá ser informado!")]
        public string SubTitulo { get; set; }
        [Required(ErrorMessage = "Campo {0} deverá ser informado!")]
        public string Resumo { get; set; }
        [Display(Name = "Ano de Publicação"),
        Required(ErrorMessage = "Campo {0} deverá ser informado!")]
        public string AnoPublicacao { get; set; }
        [Display(Name = "Nome da Editora"),
        Required(ErrorMessage = "Campo {0} deverá ser informado!")]
        public string Editora { get; set; }
        [Display(Name = "Título do Edição"),
        Required(ErrorMessage = "Campo {0} deverá ser informado!")]
        public string Edicao { get; set; }
        public string CapaUrl { get; set; }
        public int QtdeDisponivel { get; set; }
        public int QtdeEmTransito { get; set; }
        public int QtdeEmprestada { get; set; }
        public IEnumerable<PatrimonioDto> Patrimonios { get; set; }
=======
  {
    public int Id { get; set; }
    public int PatrimonioId { get; set; }
    public string ISBN { get; set; }
    [Display(Name = "Título do Acervo"),
      Required(ErrorMessage = "Campo {0} deverá ser informado!")]
    public string Titulo { get; set; }
    [Display(Name = "Sub-título do Acervo"),
    Required(ErrorMessage = "Campo {0} deverá ser informado!")]
    public string SubTitulo { get; set; }
    [Required(ErrorMessage = "Campo {0} deverá ser informado!")]
    public string Autor { get; set; }
    [Required(ErrorMessage = "Campo {0} deverá ser informado!")]
    public string Resumo { get; set; }
    [Display(Name = "Ano de Publicação"),
    Required(ErrorMessage = "Campo {0} deverá ser informado!")]
    public string AnoPublicacao { get; set; }
    [Display(Name = "Nome da Editora"),
    Required(ErrorMessage = "Campo {0} deverá ser informado!")]
    public string Editora { get; set; }
    [Display(Name = "Data de Criação / Cadastro do livro"),
    Required(ErrorMessage = "Campo {0} deverá ser informado no formato AAAAMMDD!")]
    public string DataCriacao { get; set; }
    [Display(Name = "Título da Edição"),
    Required(ErrorMessage = "Campo {0} deverá ser informado!")]
    public string Edicao { get; set; }
    [Display(Name = "Gênero"),
    Required(ErrorMessage = "Campo {0} deverá ser informado!")]
    public string Genero { get; set; }
    public int QtdPaginas { get; set; }
    public string Comentarios { get; set; }
    public string CapaUrl { get; set; }
    public int QtdeDisponivel { get; set; }
    public int QtdeEmTransito { get; set; }
    public int QtdeEmprestada { get; set; }
    public IEnumerable<PatrimonioDto> Patrimonios { get; set; }
>>>>>>> Stashed changes

    }
}
