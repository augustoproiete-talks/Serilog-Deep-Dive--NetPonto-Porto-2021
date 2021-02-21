using System;
using System.Threading;
using Serilog;

namespace CustomTheme
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                //.WriteTo.Console(theme: Serilog.Sinks.SystemConsole.Themes.SystemConsoleTheme.Grayscale)
                .WriteTo.Console(theme: MyThemes.Portugal)
                .CreateLogger();

            Log.Debug("Getting started");

            Log.Information("Hello {Name} from thread {ThreadId}", Environment.UserName,
                Thread.CurrentThread.ManagedThreadId);

            Log.Warning("No coins remain at position {@Position}", new { Lat = 25, Long = 134 });

            try
            {
                Fail();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Oops... Something went wrong");
            }

            Log.CloseAndFlush();
        }

        private static void Fail()
        {
            throw new DivideByZeroException();
        }
    }
}
