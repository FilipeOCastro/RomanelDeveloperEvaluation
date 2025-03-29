namespace Romanel.Evaluation.domain.Events
{
    public class ClienteCriadoEvent : DomainEvent
    {
        public Guid ClienteId { get; }
        public string CPF { get; }
        public string Email { get; }

        public ClienteCriadoEvent(Guid clienteId, string cpf, string email)
        {
            ClienteId = clienteId;
            CPF = cpf;
            Email = email;
        }
    }
}