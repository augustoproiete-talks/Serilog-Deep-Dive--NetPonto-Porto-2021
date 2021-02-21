using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using Serilog.Sinks.PeriodicBatching;

namespace CustomSinkPeriodicBatching
{
    public class ConsolePeriodicBatchingSink : IBatchedLogEventSink
    {
        private readonly ITextFormatter _messageTemplateTextFormatter = new MessageTemplateTextFormatter("{Message}",
            CultureInfo.InvariantCulture);

        private int _batchId;

        public Task EmitBatchAsync(IEnumerable<LogEvent> batch)
        {
            Interlocked.Increment(ref _batchId);

            foreach (var logEvent in batch)
            {
                var buffer = new StringBuilder();
                buffer.Append($"Batch: {_batchId} | ");
                _messageTemplateTextFormatter.Format(logEvent, new StringWriter(buffer));

                Console.WriteLine(buffer.ToString());
            }

            return Task.CompletedTask;
        }

        public Task OnEmptyBatchAsync()
        {
            return Task.CompletedTask;
        }
    }
}
