using Serilog;

namespace CustomEnricher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                .WriteTo.Seq("http://localhost:5341/")
                .Enrich.With<SequenceEnricher>()
                .CreateLogger();

            Log.Verbose("Hello Serilog Enrichers!");
            Log.Debug("Hello Serilog Enrichers!");
            Log.Information("Hello Serilog Enrichers!");
            Log.Warning("Hello Serilog Enrichers!");
            Log.Error("Hello Serilog Enrichers!");

            Log.CloseAndFlush();
        }
    }
}
