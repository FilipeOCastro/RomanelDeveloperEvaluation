using MediatR;
using Romanel.Evaluation.Application.Dtos;

namespace Romanel.Evaluation.Application.Queries
{
    public class ObterClienteQuery : IRequest<ClienteDto>
    {
        public Guid Id { get; set; }
    }
}
