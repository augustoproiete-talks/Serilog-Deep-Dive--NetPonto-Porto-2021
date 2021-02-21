using System;
using System.Linq;
using Serilog.Core;
using Serilog.Events;

namespace CustomSinkWrap
{
    /// <summary>
    /// Adapted from https://github.com/nblumhardt/serilog-sinks-timewarp/
    /// </summary>
    public class TimeWarpSink : ILogEventSink, IDisposable
    {
        private readonly ILogEventSink _targetSink;

        public TimeWarpSink(ILogEventSink targetSink)
        {
            _targetSink = targetSink ?? throw new ArgumentNullException(nameof(targetSink));
        }

        public void Emit(LogEvent logEvent)
        {
            // If you like this, you might like Serilog.Expressions even better :)
            // https://github.com/serilog/serilog-expressions

            var newTimestamp = logEvent.Timestamp.AddHours(-5);

            var newLogEvent = new LogEvent(newTimestamp, logEvent.Level, logEvent.Exception, logEvent.MessageTemplate,
                logEvent.Properties.Select(p => new LogEventProperty(p.Key, p.Value)));

            _targetSink.Emit(newLogEvent);
        }

        public void Dispose()
        {
            (_targetSink as IDisposable)?.Dispose();
        }
    }
}
