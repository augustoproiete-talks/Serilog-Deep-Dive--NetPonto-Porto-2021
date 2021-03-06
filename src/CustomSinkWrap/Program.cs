﻿using Serilog;

namespace CustomSinkWrap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TimeWarp(writeTo => writeTo.Console())
                .CreateLogger();

            Log.Information("Records found: {RecordCount}!", 42);
            Log.Warning("Records found: {RecordCount}!", 43);

            Log.CloseAndFlush();
        }
    }
}
