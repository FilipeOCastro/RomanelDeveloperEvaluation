namespace Romanel.Evaluation.Infrastructure.EventStore
{
    public class StoredEvent
    {
        public Guid Id { get; set; }
        public string Data { get; set; } 
        public string Type { get; set; } 
        public DateTime OccurredOn { get; set; }
    }
}
