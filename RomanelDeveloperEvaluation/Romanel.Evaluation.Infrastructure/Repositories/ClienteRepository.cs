using Microsoft.EntityFrameworkCore;
using Romanel.Evaluation.domain.Entities;
using Romanel.Evaluation.domain.Interfaces;
using Romanel.Evaluation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanel.Evaluation.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByCPFAsync(string cpf)
        {
            return await _context.Clientes.AnyAsync(c => c.CPF == cpf);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Clientes.AnyAsync(c => c.Email == email);
        }
    }
}
