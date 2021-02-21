using System;
using Serilog;

namespace CustomFormatter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                //.WriteTo.Console(formatter: new Serilog.Formatting.Compact.CompactJsonFormatter())
                //.WriteTo.Console(formatter: new Serilog.Formatting.Json.JsonFormatter())
                //.WriteTo.Console(formatter: new CsvTextFormatter())
                //.WriteTo.Console(formatter: new XmlTextFormatter())
                .WriteTo.Console(formatter: new XmlRenderedTextFormatter())
                .WriteTo.File(new XmlRenderedTextFormatter(), "log.xml")
                .WriteTo.Seq("http://localhost:5341/")
                .CreateLogger();

            Log.Verbose("Records found: {RecordCount}!", 42);
            Log.Debug("Records found: {RecordCount}!", 42);
            Log.Information("Records found: {RecordCount}!", 42);
            Log.Warning("Records found: {RecordCount}!", 42);
            Log.Error(new DivideByZeroException("oops"), "Records found: {RecordCount}!", 42);

            Log.CloseAndFlush();
        }
    }
}
