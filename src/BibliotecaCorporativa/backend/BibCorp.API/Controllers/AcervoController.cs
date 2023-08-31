using Microsoft.AspNetCore.Mvc;

namespace BibCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcervoController : ControllerBase
    {

        public AcervoController()
        {
        }

        [HttpGet]
        public string Get()
        {
            return "value";
        }
    }
}