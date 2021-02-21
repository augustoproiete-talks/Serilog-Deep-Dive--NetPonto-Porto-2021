using System;
using Serilog;
using Serilog.Configuration;
using Serilog.Sinks.PeriodicBatching;

namespace CustomSinkPeriodicBatching
{
    public static class LoggerSinkConfigurationConsolePeriodicBatchingExtensions
    {
        public static LoggerConfiguration PeriodicBatchingConsole(this LoggerSinkConfiguration sinkConfiguration)
        {
            var options = new PeriodicBatchingSinkOptions()
            {
                BatchSizeLimit = 5,
                Period = TimeSpan.FromSeconds(5),
                QueueLimit = 1000,
                EagerlyEmitFirstEvent = false,
            };

            var periodicBatchingSink = new PeriodicBatchingSink(new ConsolePeriodicBatchingSink(), options);

            return sinkConfiguration.Sink(periodicBatchingSink);
        }
    }
}
