using Serilog;
using Serilog.Configuration;

namespace CustomSink
{
    public static class WindowsNotificationsSinkExtensions
    {
        public static LoggerConfiguration ToastNotification(this LoggerSinkConfiguration configuration)
        {
            return configuration.Sink(new WindowsNotificationSink("NetPonto"));
        }
    }
}
