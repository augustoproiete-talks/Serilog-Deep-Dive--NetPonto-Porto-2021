using System;
using Serilog;
using Serilog.Context;
using Serilog.Filters;

namespace SubLoggers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Seq("http://localhost:5341/")
                .WriteTo.Logger
                (c => c
                    .Filter.ByExcluding(Matching.WithProperty("Confidential"))
                    .WriteTo.Console(outputTemplate:
                        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                )
                .WriteTo.Logger
                (c => c
                    .Filter.ByIncludingOnly(Matching.WithProperty("Confidential"))
                    .WriteTo.File("Confidential.log")
                )
                .Enrich.FromLogContext()
                .CreateLogger();

            Log.Verbose("Records found: {RecordCount}!", 42);
            Log.Debug("Records found: {RecordCount}!", 42);
            Log.Information("Records found: {RecordCount}!", 42);
            Log.Warning("Records found: {RecordCount}!", 42);
            Log.Error(new DivideByZeroException("oops"), "Records found: {RecordCount}!", 42);

            Log.ForContext("Confidential", true)
                .Information("Only some loggers should see this #secret");

            using (LogContext.PushProperty("Priority", "Urgent"))
            {
                Log.Information("This is a super urgent message!!!!!");
                Log.Warning("And this is a super urgent warning!!!!!");
            }

            // Log.ForContext("LargeMessage", true)
            //     .Information("This is a very large message!!!!!");


            Log.CloseAndFlush();
        }
    }
}
