using ClienteApp.Domain.Enums;
using FluentAssertions;
using Romanel.Evaluation.domain.Entities;

namespace Romanel.Evaluation.Tests.Domain
{
    public class ClienteTests
    {
        [Fact]
        public void CriarCliente_ValoresValidos_DeveCriarComSucesso()
        {
            // Arrange
            var nome = "João Silva";
            var cpf = "12345678901";
            var dataNascimento = new DateTime(1990, 1, 1);
            var telefone = "11987654321";
            var email = "joao@gmail.com";
            var endereco = new Endereco("12345678", "Rua Teste", "123", "Centro", "São Paulo", "SP");

            // Act
            var cliente = new Cliente(nome, cpf, "", "", TipoCliente.PessoaFisica, dataNascimento, telefone, email, endereco);

            // Assert
            cliente.Id.Should().NotBeEmpty();
            cliente.Nome.Should().Be(nome);
            cliente.CPF.Should().Be(cpf);
            cliente.DomainEvents.Should().HaveCount(1); // Verifica o evento ClienteCriadoEvent
        }

        [Theory]
        [InlineData("João Silva", "12345678901", "E-mail inválido.")]
        [InlineData("João Silva", "123", "CPF deve conter exatamente 11 dígitos numéricos.")]
        public void CriarCliente_ValoresInvalidos_DeveLancarExcecao(string nome, string cpf, string mensagemEsperada)
        {
            // Arrange
            var dataNascimento = new DateTime(1990, 1, 1);
            var telefone = "11987654321";
            var email = "joao";
            var endereco = new Endereco("12345678", "Rua Teste", "123", "Centro", "São Paulo", "SP");

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                new Cliente(nome, cpf, "", "", TipoCliente.PessoaFisica, dataNascimento, telefone, email, endereco));
            exception.Message.Should().Be(mensagemEsperada);
        }
    }
}
