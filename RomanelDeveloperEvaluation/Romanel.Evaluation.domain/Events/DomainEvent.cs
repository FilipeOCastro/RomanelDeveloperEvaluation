namespace Romanel.Evaluation.domain.Events
{
    public abstract class DomainEvent
    {
        public Guid EventId { get; } = Guid.NewGuid();
        public DateTime OccurredOn { get; } = DateTime.Now;
    }
}
