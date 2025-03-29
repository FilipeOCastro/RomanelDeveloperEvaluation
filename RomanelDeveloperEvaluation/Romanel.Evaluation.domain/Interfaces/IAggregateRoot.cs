using Romanel.Evaluation.domain.Events;

namespace Romanel.Evaluation.domain.Interfaces
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<DomainEvent> DomainEvents { get; }
        void AddDomainEvent(DomainEvent domainEvent);
        void ClearDomainEvents();
    }
}
