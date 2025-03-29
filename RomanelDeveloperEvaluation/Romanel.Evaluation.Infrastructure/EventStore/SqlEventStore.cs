using Romanel.Evaluation.domain.Events;
using Romanel.Evaluation.domain.Interfaces;
using Romanel.Evaluation.Infrastructure.Data;
using System.Text.Json;

namespace Romanel.Evaluation.Infrastructure.EventStore
{
    public class SqlEventStore : IEventStore
    {
        private readonly AppDbContext _context;

        public SqlEventStore(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveEventsAsync(IReadOnlyCollection<DomainEvent> events)
        {
            foreach (var @event in events)
            {
                var storedEvent = new StoredEvent
                {
                    Id = Guid.NewGuid(),
                    Data = JsonSerializer.Serialize(@event),
                    Type = @event.GetType().Name,
                    OccurredOn = @event.OccurredOn
                };
                await _context.StoredEvents.AddAsync(storedEvent);
            }
            await _context.SaveChangesAsync();
        }
    }
}
