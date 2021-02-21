using System.Globalization;
using System.IO;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace CustomFormatter
{
    public class CsvTextFormatter : ITextFormatter
    {
        private readonly ITextFormatter _messageTemplateTextFormatter = new MessageTemplateTextFormatter("{Message}",
            CultureInfo.InvariantCulture);

        public void Format(LogEvent logEvent, TextWriter output)
        {
            output.Write(logEvent.Timestamp);

            output.Write(",");
            output.Write(logEvent.Level);

            output.Write(",");
            output.Write("\"");
            _messageTemplateTextFormatter.Format(logEvent, output);
            output.Write("\"");

            output.WriteLine();
        }
    }
}
