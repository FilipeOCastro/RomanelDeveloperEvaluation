using Romanel.Evaluation.domain.Events;

namespace Romanel.Evaluation.domain.Interfaces
{
    public interface IEventStore
    {
        Task SaveEventsAsync(IReadOnlyCollection<DomainEvent> events);
    }
}
