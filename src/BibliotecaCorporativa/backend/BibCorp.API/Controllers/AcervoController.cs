using BibCorp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcervoController : ControllerBase
    {
        public IEnumerable<Acervo> _acervo = new Acervo[] {
            new Acervo() {
                Id = 1,
                Patrimonio = "PREVENIR00001",
                NomeLivro = "XING LING",
                Autores = "Abre Lima; Luiz Goulart",
                Resumo = "História da Xing Ling",
                ISBN = "1",
                AnoPublicacao = "1945",
                DataCadastro = DateTime.Now.ToString(),
                AcertoAtivo = true
            },
            new Acervo() {
                Id = 2,
                Patrimonio = "PREVENIR00002",
                NomeLivro = "XING LING 2",
                Autores = "Abreu Lima; Luiz Goulart",
                Resumo = "História da Xing Ling cap. 2",
                ISBN = "2",
                AnoPublicacao = "1947",
                DataCadastro = DateTime.Now.ToString(),
                AcertoAtivo = true
            }
        };
        public AcervoController()
        {
        }

        [HttpGet]
        public IEnumerable<Acervo> Get()
        {
            return _acervo;
        }
    }
}