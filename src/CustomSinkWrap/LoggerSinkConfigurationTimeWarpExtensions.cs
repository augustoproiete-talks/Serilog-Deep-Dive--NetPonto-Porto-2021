using System;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace CustomSinkWrap
{
    public static class LoggerSinkConfigurationTimeWarpExtensions
    {
        public static LoggerConfiguration TimeWarp(this LoggerSinkConfiguration loggerSinkConfiguation,
            Action<LoggerSinkConfiguration> configure)
        {
            return LoggerSinkConfiguration.Wrap(loggerSinkConfiguation, sink => new TimeWarpSink(sink), configure,
                restrictedToMinimumLevel: LogEventLevel.Verbose, levelSwitch: null);
        }
    }
}
