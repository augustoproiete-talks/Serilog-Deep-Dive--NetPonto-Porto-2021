<Query Kind="Program">
  <NuGetReference>Serilog</NuGetReference>
  <NuGetReference>Serilog.Sinks.LINQPad</NuGetReference>
  <Namespace>Serilog</Namespace>
  <Namespace>Serilog.Sinks.LINQPad.Themes</Namespace>
  <Namespace>System.Drawing</Namespace>
</Query>

void Main()
{
	Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Verbose()
	.WriteTo.LINQPad()
	//.WriteTo.LINQPad(theme: MyThemes.Portugal)
	.CreateLogger();

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

	Log.CloseAndFlush();
}

private static void Fail()
{
	throw new DivideByZeroException();
}

public static class MyThemes
{
	public static LINQPadTheme Portugal { get; } = new LINQPadTheme
	(
		new Dictionary<ConsoleThemeStyle, LINQPadThemeStyle>
		{
			[ConsoleThemeStyle.Text] = new() { Background = Color.Red, Foreground = Color.Black },
			[ConsoleThemeStyle.SecondaryText] = new() { Background = Color.Green, Foreground = Color.Black },
			[ConsoleThemeStyle.TertiaryText] = new() { Background = Color.Red, Foreground = Color.Black },
			[ConsoleThemeStyle.Name] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.Number] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.String] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.Boolean] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.Number] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.Invalid] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.Null] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.LevelVerbose] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.LevelDebug] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.LevelInformation] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.LevelWarning] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.LevelError] = new() { Background = Color.Yellow, Foreground = Color.Black },
			[ConsoleThemeStyle.LevelFatal] = new() { Background = Color.Yellow, Foreground = Color.Black },
		}
	);
}
