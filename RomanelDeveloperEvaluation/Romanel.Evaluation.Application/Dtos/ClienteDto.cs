using ClienteApp.Domain.Enums;

namespace Romanel.Evaluation.Application.Dtos
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }       

    }
}
