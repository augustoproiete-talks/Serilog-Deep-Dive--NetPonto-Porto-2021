using System.Collections.Generic;
using Serilog.Sinks.RichTextBox.Themes;

namespace CustomThemeWpf
{
    public static class MyThemes
    {
        public static RichTextBoxTheme Portugal  { get; } = new RichTextBoxConsoleTheme
        (
            new Dictionary<RichTextBoxThemeStyle, RichTextBoxConsoleThemeStyle>
            {
                [RichTextBoxThemeStyle.Text] = new() { Background = ConsoleHtmlColor.Red, Foreground = ConsoleHtmlColor.Black },
                [RichTextBoxThemeStyle.SecondaryText] = new() { Background = ConsoleHtmlColor.Green, Foreground = ConsoleHtmlColor.Black },
                [RichTextBoxThemeStyle.TertiaryText] = new () { Background = ConsoleHtmlColor.Red, Foreground = ConsoleHtmlColor.Black },
                [RichTextBoxThemeStyle.Invalid] = new() { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black },
                [RichTextBoxThemeStyle.Null] = new() { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black },
                [RichTextBoxThemeStyle.Name] = new() { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black },
                [RichTextBoxThemeStyle.String] = new () { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black  },
                [RichTextBoxThemeStyle.Number] = new () { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black  },
                [RichTextBoxThemeStyle.Boolean] = new() { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black },
                [RichTextBoxThemeStyle.Scalar] = new() { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black },
                [RichTextBoxThemeStyle.Number] = new() { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black },
                [RichTextBoxThemeStyle.LevelVerbose] = new () { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black  },
                [RichTextBoxThemeStyle.LevelDebug] = new () { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black  },
                [RichTextBoxThemeStyle.LevelInformation] = new () { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black  },
                [RichTextBoxThemeStyle.LevelWarning] = new () { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black  },
                [RichTextBoxThemeStyle.LevelError] = new () { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black  },
                [RichTextBoxThemeStyle.LevelFatal] = new () { Background = ConsoleHtmlColor.Yellow, Foreground = ConsoleHtmlColor.Black  },
            }
        );
    }
}
