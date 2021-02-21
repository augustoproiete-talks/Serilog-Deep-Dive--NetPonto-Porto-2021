using System;
using System.Collections.Generic;
using Serilog.Sinks.SystemConsole.Themes;

namespace CustomTheme
{
    public static class MyThemes
    {
        public static ConsoleTheme Portugal { get; } = new SystemConsoleTheme
        (
            new Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle>
            {
                [ConsoleThemeStyle.Text] = new() { Background = ConsoleColor.Red, Foreground = ConsoleColor.Black },
                [ConsoleThemeStyle.SecondaryText] = new() { Background = ConsoleColor.Green, Foreground = ConsoleColor.Black },
                [ConsoleThemeStyle.TertiaryText] = new () { Background = ConsoleColor.Red, Foreground = ConsoleColor.Black },
                [ConsoleThemeStyle.Name] = new() { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black },
                [ConsoleThemeStyle.Number] = new () { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black  },
                [ConsoleThemeStyle.String] = new () { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black  },
                [ConsoleThemeStyle.Boolean] = new() { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black },
                [ConsoleThemeStyle.Number] = new() { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black },
                [ConsoleThemeStyle.Invalid] = new() { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black },
                [ConsoleThemeStyle.Null] = new() { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black },
                [ConsoleThemeStyle.LevelVerbose] = new () { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black  },
                [ConsoleThemeStyle.LevelDebug] = new () { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black  },
                [ConsoleThemeStyle.LevelInformation] = new () { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black  },
                [ConsoleThemeStyle.LevelWarning] = new () { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black  },
                [ConsoleThemeStyle.LevelError] = new () { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black  },
                [ConsoleThemeStyle.LevelFatal] = new () { Background = ConsoleColor.Yellow, Foreground = ConsoleColor.Black  },
            }
        );
    }
}
