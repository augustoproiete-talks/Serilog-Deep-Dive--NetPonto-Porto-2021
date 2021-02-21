using System.Threading;
using Serilog.Core;
using Serilog.Events;

namespace CustomEnricher
{
    public class SequenceEnricher : ILogEventEnricher
    {
        private int _last;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var next = Interlocked.Increment(ref _last);
            var sequence = propertyFactory.CreateProperty("Sequence", next);

            logEvent.AddPropertyIfAbsent(sequence);
        }
    }
}
