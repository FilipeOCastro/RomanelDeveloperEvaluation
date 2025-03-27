using MediatR;
using Romanel.Evaluation.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanel.Evaluation.Application.Queries
{
    public class ObterClienteQuery : IRequest<ClienteDto>
    {
        public Guid Id { get; set; }
    }
}
