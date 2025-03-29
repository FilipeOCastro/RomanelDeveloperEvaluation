using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Romanel.Evaluation.domain.Entities;
using Romanel.Evaluation.Infrastructure.Data;
using Romanel.Evaluation.Infrastructure.Repositories;

namespace Romanel.Evaluation.Tests.Infrastructure
{
    public class ClienteRepositoryTests
    {
        [Fact]
        public async Task AddAsync_ClienteValido_DevePersistir()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            var context = new AppDbContext(options);
            var repository = new ClienteRepository(context);

            var cliente = new Cliente(
                "João Silva", "12345678901", new DateTime(1990, 1, 1),
                "11987654321", "joao@example.com",
                new Endereco("12345678", "Rua Teste", "123", "Centro", "São Paulo", "SP"));

            // Act
            await repository.AddAsync(cliente);

            // Assert
            var savedCliente = await context.Clientes.FirstOrDefaultAsync(c => c.Id == cliente.Id);
            savedCliente.Should().NotBeNull();
            savedCliente.Nome.Should().Be("João Silva");
        }
    }
}
