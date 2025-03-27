using Romanel.Evaluation.domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanel.Evaluation.domain.Interfaces
{
    public interface IEventStore
    {
        Task SaveEventsAsync(IReadOnlyCollection<DomainEvent> events);
    }
}
