using FluentAssertions;
using Moq;
using Romanel.Evaluation.Application.Commands;
using Romanel.Evaluation.domain.Entities;
using Romanel.Evaluation.domain.Events;
using Romanel.Evaluation.domain.Interfaces;

namespace Romanel.Evaluation.Tests.Application
{
    public class CriarClienteCommandHandlerTests
    {
        [Fact]
        public async Task Handle_DadosValidos_DeveCriarCliente()
        {
            // Arrange
            var repoMock = new Mock<IClienteRepository>();
            var eventStoreMock = new Mock<IEventStore>();
            var handler = new CriarClienteCommandHandler(repoMock.Object, eventStoreMock.Object);

            var command = new CriarClienteCommand
            {
                Nome = "João Silva",
                CPF = "12345678901",
                DataNascimento = new DateTime(1990, 1, 1),
                Telefone = "11987654321",
                Email = "joao@example.com",
                CEP = "12345678",
                Logradouro = "Rua Teste",
                Numero = "123",
                Bairro = "Centro",
                Cidade = "São Paulo",
                Estado = "SP"
            };

            repoMock.Setup(r => r.ExistsByCPFAsync(It.IsAny<string>())).ReturnsAsync(false);
            repoMock.Setup(r => r.ExistsByEmailAsync(It.IsAny<string>())).ReturnsAsync(false);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeEmpty();
            repoMock.Verify(r => r.AddAsync(It.IsAny<Cliente>()), Times.Once);
            eventStoreMock.Verify(e => e.SaveEventsAsync(It.IsAny<IReadOnlyCollection<DomainEvent>>()), Times.Once);
        }

        //[Fact]
        //public async Task Handle_CPFJaExistente_DeveLancarExcecao()
        //{
        //    // Arrange
        //    var repoMock = new Mock<IClienteRepository>();
        //    var eventStoreMock = new Mock<IEventStore>();
        //    var handler = new CriarClienteCommandHandler(repoMock.Object, eventStoreMock.Object);

        //    var command = new CriarClienteCommand { CPF = "12345678901" };
        //    repoMock.Setup(r => r.ExistsByCPFAsync("12345678901")).ReturnsAsync(true);

        //    // Act & Assert
        //    var exception = await Assert.ThrowsAsync<ApplicationException>(() =>
        //        handler.Handle(command, CancellationToken.None));
        //    exception.Message.Should().Be("CPF já cadastrado.");
        //}
    }
}
