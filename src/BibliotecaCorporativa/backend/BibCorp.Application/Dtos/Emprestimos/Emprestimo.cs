using BibCorp.Application.Dto.Acervos;
using BibCorp.Application.Dto.Patrimonios;

namespace BibCorp.Application.Dto.Emprestimos
{
    public class EmprestimoDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public bool Devolvido { get; set; }
        public string DataEmprestimo { get; set; }
        public string DataPrevistaDevolucao { get; set; }
        public int  QtdeDiasEmprestimo { get; set; }
        public string DataDevolucao { get; set; }
        public int QtdeDiasAtraso { get; set; }
        public int AcervoId { get; set; }
        public IEnumerable<AcervoDto> Acervos { get; set; }
        public int PatrimonioId { get; set; }
        public IEnumerable<PatrimonioDto> Patrimonios { get; set; }
    }
}
