using System;
using System.IO;
using System.Xml;
using Serilog.Events;
using Serilog.Formatting;

namespace CustomFormatter
{
    public class XmlTextFormatter : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };

            using var writer = XmlWriter.Create(output, settings);
            {
                writer.WriteStartElement("log");
                writer.WriteAttributeString("level", logEvent.Level.ToString());
                writer.WriteAttributeString("message", logEvent.MessageTemplate.ToString());

                if (!(logEvent.Exception is null))
                {
                    writer.WriteAttributeString("exception", logEvent.Exception.ToString());
                }

                if (logEvent.Properties.Count > 0)
                {
                    writer.WriteStartElement("properties");

                    foreach (var p in logEvent.Properties)
                    {
                        writer.WriteStartElement("property");

                        writer.WriteStartElement("name");
                        writer.WriteString(p.Key);
                        writer.WriteEndElement();

                        writer.WriteStartElement("value");
                        writer.WriteString(p.Value.ToString()); // (*)
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.Flush();
            }

            output.Write(Environment.NewLine);

            // (*) We should be using p.Value.Render, and use an IFormatProvider to have full control
            // over how the property value gets rendered (e.g. No quotes)
        }
    }
}
