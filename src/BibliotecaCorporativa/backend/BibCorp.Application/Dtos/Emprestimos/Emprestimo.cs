using BibCorp.Application.Dto.Acervos;
using BibCorp.Application.Dto.Patrimonios;

namespace BibCorp.Application.Dto.Emprestimos
{
  public class EmprestimoDto
  {
    public int Id { get; set; }
    public string UserName { get; set; }
    public StatusDto Status { get; set; }
    public string DataEmprestimo { get; set; }
    public string DataPrevistaDevolucao { get; set; }
    public int QtdeDiasEmprestimo { get; set; }
    public string DataDevolucao { get; set; }
    public int QtdeDiasAtraso { get; set; }
    public int AcervoId { get; set; }
    public AcervoDto Acervo { get; set; }
    public int PatrimonioId { get; set; }
    public PatrimonioDto Patrimonio { get; set; }
    public string LocalDeColeta { get; set; }
    public string LocalDeEntrega { get; set; }
  }

  public enum StatusDto
  {
    Reservado = 1,
    Emprestado = 2,
    Devolvido = 3,
    Renovado = 4
  }
}
