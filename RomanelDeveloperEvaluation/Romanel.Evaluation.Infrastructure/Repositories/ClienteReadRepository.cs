using Microsoft.EntityFrameworkCore;
using Romanel.Evaluation.Application.Interfaces;
using Romanel.Evaluation.domain.Entities;
using Romanel.Evaluation.Infrastructure.Data;

namespace Romanel.Evaluation.Infrastructure.Repositories
{
    public class ClienteReadRepository : IClienteReadRepository
    {
        private readonly AppDbContext _context;

        public ClienteReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            return await _context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
