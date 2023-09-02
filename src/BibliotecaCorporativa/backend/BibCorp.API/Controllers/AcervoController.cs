using BibCorp.API.Data;
using BibCorp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcervoController : ControllerBase
    {
        private readonly BibCorpContext _context;
        public AcervoController(BibCorpContext context)
        {
           _context = context;
        }

        [HttpGet]
        public IEnumerable<Acervo> Get()
        {
            return _context.Acervos;
        }
    }
}