using MediatR;
using Microsoft.AspNetCore.Mvc;
using Romanel.Evaluation.Application.Commands;
using Romanel.Evaluation.Application.Queries;

namespace Romanel.Evaluation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] CriarClienteCommand command)
        {
            var clienteId = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObterCliente), new { id = clienteId }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCliente(Guid id)
        {
            var query = new ObterClienteQuery { Id = id };
            var cliente = await _mediator.Send(query);
            return cliente == null ? NotFound() : Ok(cliente);
        }
    }
}

