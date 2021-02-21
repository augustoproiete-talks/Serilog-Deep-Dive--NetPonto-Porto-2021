using Serilog;

namespace CustomSink
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                //.WriteTo.Sink(new WindowsNotificationSink("NetPonto"))
                .WriteTo.ToastNotification()
                .CreateLogger();

            Log.Information("Records found: {RecordCount}!", 42);
            Log.Warning("Records found: {RecordCount}!", 43);

            Log.CloseAndFlush();
        }
    }
}
