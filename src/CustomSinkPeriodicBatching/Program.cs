using System;
using Serilog;

namespace CustomSinkPeriodicBatching
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.PeriodicBatchingConsole()
                .CreateLogger();

            Log.Information("Records found: {RecordCount}!", 42);
            Log.Information("Records found: {RecordCount}!", 43);

            //for (var i = 0; i < 50; i++)
            //{
            //    Log.Information("Records found: {RecordCount}!", i);
            //}

            Console.ReadLine();

            Log.CloseAndFlush();
        }
    }
}
