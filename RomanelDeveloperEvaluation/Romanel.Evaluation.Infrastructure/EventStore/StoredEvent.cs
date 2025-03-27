using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanel.Evaluation.Infrastructure.EventStore
{
    public class StoredEvent
    {
        public Guid Id { get; set; }
        public string Data { get; set; } // JSON dos eventos
        public string Type { get; set; } // Tipo do evento (ex.: ClienteCriadoEvent)
        public DateTime OccurredOn { get; set; }
    }
}
