using BibCorp.Domain.Enum;

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
        public Origem Origem { get; set; }
        public string DetalheOrgiem { get; set; }
        public bool Ativo { get; set; }
        public string DataCadastro { get; set; }
        public string DataAtualizacao { get; set; }
        public string DataIndisponibilidade { get; set; }
    }
}
