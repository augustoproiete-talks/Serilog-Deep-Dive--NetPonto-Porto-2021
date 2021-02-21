using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace CustomFormatter
{
    public class XmlRenderedTextFormatter : ITextFormatter
    {
        private readonly ITextFormatter _messageTemplateTextFormatter = new MessageTemplateTextFormatter("{Message}",
            CultureInfo.InvariantCulture);

        public void Format(LogEvent logEvent, TextWriter output)
        {
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };

            using var writer = XmlWriter.Create(output, settings);
            {
                var renderedMessage = new StringBuilder();
                _messageTemplateTextFormatter.Format(logEvent, new StringWriter(renderedMessage));

                writer.WriteStartElement("log");
                writer.WriteAttributeString("level", logEvent.Level.ToString());
                writer.WriteAttributeString("message", renderedMessage.ToString());

                if (!(logEvent.Exception is null))
                {
                    writer.WriteAttributeString("exception", logEvent.Exception.ToString());
                }

                writer.WriteEndElement();
                writer.Flush();
            }

            output.Write(Environment.NewLine);
        }
    }
}
