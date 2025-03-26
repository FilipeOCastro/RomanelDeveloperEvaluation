using Microsoft.AspNetCore.Mvc;

namespace Romanel.Evaluation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCliente")]
        public IEnumerable<String> Get()
        {
            List<String> nomes = new List<String>();

            nomes.Add("Teste1");
            nomes.Add("Teste2");
            nomes.Add("Teste3");

            return nomes;
        }
    }
}

