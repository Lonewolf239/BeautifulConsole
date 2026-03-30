using System;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class ConsoleCore
{
    private static bool? _SupportsTrueColor;
    private static bool? _SupportsClearScreen;
    private static readonly (ConsoleColor Color, byte R, byte G, byte B)[] ConsoleColors = new (ConsoleColor Color, byte R, byte G, byte B)[]
    {
        (ConsoleColor.Black, 0, 0, 0),
        (ConsoleColor.DarkBlue, 0, 0, 128),
        (ConsoleColor.DarkGreen, 0, 128, 0),
        (ConsoleColor.DarkCyan, 0, 128, 128),
        (ConsoleColor.DarkRed, 128, 0, 0),
        (ConsoleColor.DarkMagenta, 128, 0, 128),
        (ConsoleColor.DarkYellow, 128, 128, 0),
        (ConsoleColor.Gray, 192, 192, 192),
        (ConsoleColor.DarkGray, 128, 128, 128),
        (ConsoleColor.Blue, 0, 0, 255),
        (ConsoleColor.Green, 0, 255, 0),
        (ConsoleColor.Cyan, 0, 255, 255),
        (ConsoleColor.Red, 255, 0, 0),
        (ConsoleColor.Magenta, 255, 0, 255),
        (ConsoleColor.Yellow, 255, 255, 0),
        (ConsoleColor.White, 255, 255, 255)
    };

    private static bool SupportsTrueColor()
    {
        if (_SupportsTrueColor.HasValue) return _SupportsTrueColor.Value;
        var term = Environment.GetEnvironmentVariable("TERM");
        var colorTerm = Environment.GetEnvironmentVariable("COLORTERM");
        bool supports = colorTerm == "truecolor" ||
                       colorTerm == "24bit" ||
                       term?.Contains("truecolor") == true ||
                       term?.Contains("24bit") == true ||
                       Environment.OSVersion.Platform == PlatformID.Win32NT &&
                       !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WT_SESSION"));
        _SupportsTrueColor = supports;
        return supports;
    }

    private static bool SupportsExtendedClear()
    {
        if (_SupportsClearScreen.HasValue) return _SupportsClearScreen.Value;
        bool supports = SupportsTrueColor() ||
                       Environment.OSVersion.Platform == PlatformID.Unix ||
                       Environment.OSVersion.Platform == PlatformID.MacOSX ||
                       (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WT_SESSION")));
        _SupportsClearScreen = supports;
        return supports;
    }

    private static ConsoleColor GetNearestConsoleColor(Color color)
    {
        int r = color.R;
        int g = color.G;
        int b = color.B;
        ConsoleColor nearestColor = ConsoleColor.Black;
        int minDistance = int.MaxValue;
        foreach (var consoleColor in ConsoleColors)
        {
            int dr = consoleColor.R - r;
            int dg = consoleColor.G - g;
            int db = consoleColor.B - b;
            int distance = dr * dr + dg * dg + db * db;
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestColor = consoleColor.Color;
                if (distance == 0) break;
            }
        }
        return nearestColor;
    }

    public static void SetForegroundColor(Color color)
    {
        if (SupportsTrueColor()) Console.Write($"\x1b[38;2;{color.R};{color.G};{color.B}m");
        else
        {
            var consoleColor = GetNearestConsoleColor(color);
            Console.ForegroundColor = consoleColor;
        }
    }

    public static void SetBackgroundColor(Color color)
    {
        if (SupportsTrueColor()) Console.Write($"\x1b[48;2;{color.R};{color.G};{color.B}m");
        else
        {
            var consoleColor = GetNearestConsoleColor(color);
            Console.BackgroundColor = consoleColor;
        }
    }

    public static void ResetColor()
    {
        if (SupportsTrueColor()) Console.Write("\x1b[0m");
        else Console.ResetColor();
    }
}
