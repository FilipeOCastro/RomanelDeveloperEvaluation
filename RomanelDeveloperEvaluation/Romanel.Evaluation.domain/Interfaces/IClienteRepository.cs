using Romanel.Evaluation.domain.Entities;

namespace Romanel.Evaluation.domain.Interfaces
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task<bool> ExistsByCPFAsync(string cpf);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
