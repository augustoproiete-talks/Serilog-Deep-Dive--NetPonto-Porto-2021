using System;
using System.Threading;
using System.Windows;
using Serilog;

namespace CustomThemeWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                //.WriteTo.RichTextBox(LogRichTextBox)
                .WriteTo.RichTextBox(LogRichTextBox, theme: MyThemes.Portugal)
                .CreateLogger();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Log.Debug("Getting started");

            Log.Information("Hello {Name} from thread {ThreadId}", Environment.UserName,
                Thread.CurrentThread.ManagedThreadId);

            Log.Warning("No coins remain at position {@Position}", new { Lat = 25, Long = 134 });

            try
            {
                Fail();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Oops... Something went wrong");
            }
        }

        private static void Fail()
        {
            throw new DivideByZeroException();
        }

        private void LogVerbose_OnClick(object sender, RoutedEventArgs e)
        {
            Log.Verbose("Hello! Now => {Now}", DateTime.Now);
        }

        private void LogDebug_OnClick(object sender, RoutedEventArgs e)
        {
            Log.Debug("Hello! Now => {Now}", DateTime.Now);
        }

        private void LogInformation_OnClick(object sender, RoutedEventArgs e)
        {
            Log.Information("Hello! Now => {Now}", DateTime.Now);
        }

        private void LogWarning_OnClick(object sender, RoutedEventArgs e)
        {
            Log.Warning("Hello! Now => {Now}", DateTime.Now);
        }

        private void LogError_OnClick(object sender, RoutedEventArgs e)
        {
            Log.Error("Hello! Now => {Now}", DateTime.Now);
        }
    }
}
