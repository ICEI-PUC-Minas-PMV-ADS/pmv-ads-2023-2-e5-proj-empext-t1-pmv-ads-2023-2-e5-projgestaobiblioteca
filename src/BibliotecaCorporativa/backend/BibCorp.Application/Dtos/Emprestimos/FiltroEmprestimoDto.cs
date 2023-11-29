using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibCorp.Application.Dtos.Emprestimos
{
  public class FiltroEmprestimoDto
  {
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public List<string> Usuarios { get; set; }


  }
}
