using Romanel.Evaluation.domain.Events;
using Romanel.Evaluation.domain.Interfaces;
using System;
using System.Collections.Generic;
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

        //private Cliente() { }

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
