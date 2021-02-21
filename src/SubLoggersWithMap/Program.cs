using System;
using Serilog;

namespace SubLoggersWithMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.Map(logEvent => logEvent.Level, (level, writeTo) =>
                {
                    writeTo.File($"log-{level}.txt");
                }) 
                .WriteTo.Map("JobId", (jobId, writeTo) =>
                {
                    writeTo.File($"log-{jobId}.txt", outputTemplate: "{JobData}");
                }) 
                .Enrich.FromLogContext()
                .CreateLogger();

            Log.Verbose("Records found: {RecordCount}!", 42);
            Log.Debug("Records found: {RecordCount}!", 42);
            Log.Information("Records found: {RecordCount}!", 42);
            Log.Warning("Records found: {RecordCount}!", 42);
            Log.Error(new DivideByZeroException("oops"), "Records found: {RecordCount}!", 42);

            Log.ForContext("JobId", Guid.NewGuid())
                .Information("{JobData}", "(contents... Could be JSON/XML, etc)");
        }
    }
}
