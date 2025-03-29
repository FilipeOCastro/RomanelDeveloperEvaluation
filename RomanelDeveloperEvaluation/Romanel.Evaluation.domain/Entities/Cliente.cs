using ClienteApp.Domain.Enums;
using Romanel.Evaluation.domain.Events;
using Romanel.Evaluation.domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Romanel.Evaluation.domain.Entities
{
    public class Cliente : IAggregateRoot
    {
        private Cliente() { }

        public Cliente(string nome, string cpf, string razaoSocial, string cnpj, TipoCliente tipoCliente, DateTime dataNascimento, string telefone, string email, Endereco endereco)
        {

            AddDomainEvent(new ClienteCriadoEvent(Id, CPF ?? CNPJ, Email));

            Id = Guid.NewGuid();
            Nome = ValidateNome(nome, tipoCliente);
            CPF = ValidateCPF(cpf, tipoCliente);
            RazaoSocial = ValidateRazaoSocial(razaoSocial, tipoCliente);
            CNPJ = ValidateCNPJ(cnpj, tipoCliente);
            DataNascimento = ValidateDataNascimento(dataNascimento, tipoCliente);
            Telefone = ValidateTelefone(telefone);
            Email = ValidateEmail(email);
            Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
        }

        private readonly List<DomainEvent> _domainEvents = new();
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }

        #region validacao
        private string ValidateNome(string nome, TipoCliente tipoCliente)
        {
            if (tipoCliente == TipoCliente.PessoaFisica &&
                (string.IsNullOrWhiteSpace(nome) || nome.Length > 100))
                throw new ArgumentException("Nome é obrigatório e deve ter até 100 caracteres.");
            return nome;
        }

        private string ValidateCPF(string cpf, TipoCliente tipoCliente)
        {
            if (tipoCliente == TipoCliente.PessoaFisica &&
                (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit)))
                throw new ArgumentException("CPF deve conter exatamente 11 dígitos numéricos.");
            return cpf;
        }

        private string ValidateRazaoSocial(string razao, TipoCliente tipoCliente)
        {
            if (tipoCliente == TipoCliente.PessoaJuridica &&
                (string.IsNullOrWhiteSpace(razao) || razao.Length > 100))
                throw new ArgumentException("Razão Social é obrigatório e deve ter até 100 caracteres.");
            return razao;
        }

        private string ValidateCNPJ(string cnpj, TipoCliente tipoCliente)
        {
            if (tipoCliente == TipoCliente.PessoaJuridica &&
                (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 18 || !cnpj.All(char.IsDigit)))
                throw new ArgumentException("CNPJ deve conter exatamente 18 dígitos numéricos.");
            return cnpj;
        }

        private DateTime ValidateDataNascimento(DateTime dataNascimento, TipoCliente tipoCliente)
        {
            if (tipoCliente == TipoCliente.PessoaFisica)
            {
                DateTime dataMinima = dataNascimento.AddYears(18);
                if (DateTime.Today < dataMinima)
                    throw new ArgumentException("É necessário ter 18 anos ou mais.");
            }
            return dataNascimento;
        }      

        private string ValidateTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone) || telefone.Length < 10 || telefone.Length > 11 || !telefone.All(char.IsDigit))
                throw new ArgumentException("Telefone deve conter 10 ou 11 dígitos numéricos.");
            return telefone;
        }

        private string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
                throw new ArgumentException("E-mail inválido.");
            return email;
        }

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        #endregion

    }
}
