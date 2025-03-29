using Romanel.Evaluation.domain.Entities;

namespace Romanel.Evaluation.Application.Interfaces
{
    public interface IClienteReadRepository
    {
        Task<Cliente> GetByIdAsync(Guid id);
    }
}
