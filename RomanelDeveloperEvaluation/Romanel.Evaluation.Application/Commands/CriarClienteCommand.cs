using ClienteApp.Domain.Enums;
using MediatR;

namespace Romanel.Evaluation.Application.Commands
{
    public class CriarClienteCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        ///TODO: Mudar para classe Endereco
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
