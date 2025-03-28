using Romanel.Evaluation.domain.Events;
using Romanel.Evaluation.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanel.Evaluation.domain.Entities
{
    public class Cliente : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }

        private readonly List<DomainEvent> _domainEvents = new();
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Cliente() { }

        public Cliente(string nome, string cpf, DateTime dataNascimento, string telefone, string email, Endereco endereco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;

            AddDomainEvent(new ClienteCriadoEvent(Id, CPF, Email));

            //Id = Guid.NewGuid();
            //Nome = ValidateNome(nome);
            //CPF = ValidateCPF(cpf);
            //DataNascimento = ValidateDataNascimento(dataNascimento);
            //Telefone = ValidateTelefone(telefone);
            //Email = ValidateEmail(email);
            //Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
        }

        // Métodos de validação (regras de negócio)
        private string ValidateNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length > 100)
                throw new ArgumentException("Nome é obrigatório e deve ter até 100 caracteres.");
            return nome;
        }

        private string ValidateCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
                throw new ArgumentException("CPF deve conter exatamente 11 dígitos numéricos.");
            return cpf;
        }

        private DateTime ValidateDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento >= DateTime.Today)
                throw new ArgumentException("Data de nascimento deve ser anterior a hoje.");
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
    }
}
