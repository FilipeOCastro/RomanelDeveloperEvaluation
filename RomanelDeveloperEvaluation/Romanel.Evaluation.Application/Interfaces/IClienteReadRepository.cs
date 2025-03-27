using Romanel.Evaluation.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanel.Evaluation.Application.Interfaces
{
    public interface IClienteReadRepository
    {
        Task<Cliente> GetByIdAsync(Guid id);
    }
}
