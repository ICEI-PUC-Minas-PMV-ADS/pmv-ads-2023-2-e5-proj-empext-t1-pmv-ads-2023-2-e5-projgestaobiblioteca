using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibCorp.Domain.Models.Emprestimos
{
  public class FiltroEmprestimo
  {
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public List<string> Usuarios { get; set; }


  }
}
