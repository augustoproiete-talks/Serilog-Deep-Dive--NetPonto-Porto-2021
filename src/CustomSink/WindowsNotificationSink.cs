using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Windows.UI.Notifications;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace CustomSink
{
    public class WindowsNotificationSink : ILogEventSink
    {
        private readonly string _appName;

        private readonly ITextFormatter _messageTemplateTextFormatter = new MessageTemplateTextFormatter("{Message}",
            CultureInfo.InvariantCulture);

        public WindowsNotificationSink(string appName)
        {
            if (string.IsNullOrWhiteSpace(appName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(appName));
            }

            _appName = appName;
        }

        public void Emit(LogEvent logEvent)
        {
            var renderedMessage = new StringBuilder();
            _messageTemplateTextFormatter.Format(logEvent, new StringWriter(renderedMessage));

            ShowToast(header: logEvent.Level.ToString(), text: renderedMessage.ToString(),
                imgSrc: $"file:///{Path.GetFullPath("serilog-sink.png")}");
        }

        #region ...

        private void ShowToast(string header, string text, string footer = null, string imgSrc = null)
        {
            Func<string, bool> empty = string.IsNullOrWhiteSpace;

            var chosenToastType = (header, footer, imgSrc) switch
            {
                var (hdr, ftr, img) when empty(img) => (hdr, ftr) switch
                {
                    var (h, f) when !empty(h) && empty(f) => ToastTemplateType.ToastText02,
                    var (h, f) when !empty(h) && !empty(f) => ToastTemplateType.ToastText04,
                    var (h, f) when !empty(h) && empty(f) && h.Length > text.Length => ToastTemplateType.ToastText03,
                    _ => ToastTemplateType.ToastText01
                },

                var (hdr, ftr, img) when !empty(img) => (hdr, ftr) switch
                {
                    var (h, f) when !empty(h) && empty(f) => ToastTemplateType.ToastImageAndText02,
                    var (h, f) when !empty(h) && !empty(f) => ToastTemplateType.ToastImageAndText04,
                    var (h, f) when !empty(h) && empty(f) && h.Length > text.Length => ToastTemplateType.ToastImageAndText03,
                    _ => ToastTemplateType.ToastImageAndText01,
                },

                _ => ToastTemplateType.ToastText01
            };

            var toastXml = ToastNotificationManager.GetTemplateContent(chosenToastType);
            var nodes = toastXml.GetElementsByTagName("text");

            switch (nodes.Length)
            {
                case 1:
                    nodes.ElementAt(0).InnerText = text;
                    break;
                case 2:
                case 3:
                {
                    nodes.ElementAt(0).InnerText = header ?? string.Empty;
                    nodes.ElementAt(1).InnerText = text;

                    if (nodes.Length == 3)
                    {
                        nodes.ElementAt(2).InnerText = footer ?? string.Empty;
                    }

                    break;
                }
            }

            var imgNodes = toastXml.GetElementsByTagName("image");
            if (imgNodes.Length > 0)
            {
                imgNodes[0].Attributes[1].NodeValue = imgSrc;
            }

            ToastNotificationManager.CreateToastNotifier(_appName).Show(new ToastNotification(toastXml));
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        #endregion
    }
}
