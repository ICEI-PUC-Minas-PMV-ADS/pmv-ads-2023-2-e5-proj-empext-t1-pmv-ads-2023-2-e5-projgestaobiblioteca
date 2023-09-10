using System.ComponentModel.DataAnnotations;

namespace BibCorp.Application.Dto.Patrimonios
{
    public class PatrimonioDto
    {
        public int Id { get; set; }
        [Display(Name = "Localização do Patrimônio")]
        public string Localizacao { get; set; }
        [Display(Name = "Código da Sala")]
        public string Sala { get; set; }
        [Display(Name = "Código da Coluna")]
        public string Coluna { get; set; }
        [Display(Name = "Código da Patreleira")]
        public string Prateleira { get; set; }
        [Display(Name = "Pposição")]
        public string Posicao { get; set; }
        public string ISBN { get; set; }
        [Display(Name = "Origem do Patrimônio")]
        public string Origem { get; set; }
        [Display(Name = "Detalhe")]
        public string DetalheOrgiem { get; set; }
        public bool Ativo { get; set; }
        public string DataCadastro { get; set; }
        public string DataAtualizacao { get; set; }
        public string DataIndisponibilidade { get; set; }
    }
}
