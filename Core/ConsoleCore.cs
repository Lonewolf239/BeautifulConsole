using System;
using System.Collections.Concurrent;
using System.Threading;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class ConsoleCore
{
    private static readonly ConcurrentDictionary<Color, string> ForegroundAnsiCache = new();
    private static readonly ConcurrentDictionary<Color, string> BackgroundAnsiCache = new();
    private static readonly ConcurrentDictionary<Color, ConsoleColor> ConsoleColorsCache = new();
    private static readonly ConcurrentDictionary<int, string> Foreground256Cache = new();
    private static readonly ConcurrentDictionary<int, string> Background256Cache = new();
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

    private static int MouseState = 0;
    private static bool MouseEnable => MouseState == 1;

    internal static readonly object ConsoleLock = new();

    private static ConsoleColor GetNearestConsoleColor(Color color) =>
        ConsoleColorsCache.GetOrAdd(color, c =>
        {
            int r = c.R;
            int g = c.G;
            int b = c.B;
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
        });

    private static string GetForegroundAnsi(Color color)
    {
        if (color.Empty) return string.Empty;
        if (TerminalCapabilities.SupportsTrueColor)
            return ForegroundAnsiCache.GetOrAdd(color, c => $"\x1b[38;2;{c.R};{c.G};{c.B}m");
        if (TerminalCapabilities.Supports256Colors)
        {
            int index = color.ToXterm256Index();
            return Foreground256Cache.GetOrAdd(index, i => $"\x1b[38;5;{i}m");
        }
        return string.Empty;
    }

    private static string GetBackgroundAnsi(Color color)
    {
        if (color.Empty) return string.Empty;
        if (TerminalCapabilities.SupportsTrueColor)
            return BackgroundAnsiCache.GetOrAdd(color, c => $"\x1b[48;2;{c.R};{c.G};{c.B}m");
        if (TerminalCapabilities.Supports256Colors)
        {
            int index = color.ToXterm256Index();
            return Background256Cache.GetOrAdd(index, i => $"\x1b[48;5;{i}m");
        }
        return string.Empty;
    }

    internal static string SetForegroundColor(string text, Color color)
    {
        if (color.Empty) return text;
        string ansi = GetForegroundAnsi(color);
        if (string.IsNullOrEmpty(ansi))
        {
            Console.ForegroundColor = GetNearestConsoleColor(color);
            return text;
        }
        return ansi + text;
    }

    internal static string SetBackgroundColor(string text, Color color)
    {
        if (color.Empty) return text;
        string ansi = GetBackgroundAnsi(color);
        if (string.IsNullOrEmpty(ansi))
        {
            Console.BackgroundColor = GetNearestConsoleColor(color);
            return text;
        }
        return ansi + text;
    }

    internal static (bool, string) GetTextWithColor(Message message)
    {
        string text = message.Text;
        bool colorChanged = !message.ForegroundColor.Empty || !message.BackgroundColor.Empty;
        text = SetForegroundColor(text, message.ForegroundColor);
        text = SetBackgroundColor(text, message.BackgroundColor);
        return (colorChanged, text);
    }

    private static void ResetColorCore()
    {
        if (TerminalCapabilities.SupportsAnsi) Console.Write("\x1b[0m");
        else Console.ResetColor();
    }

    internal static void ResetColor() { lock (ConsoleLock) ResetColorCore(); }

    internal static void EnableMouse()
    {
        if (!TerminalCapabilities.SupportsMouse) return;
        if (Interlocked.CompareExchange(ref MouseState, 1, 0) != 0) return;
        lock (ConsoleLock) Console.Write("\x1b[?1000h\x1b[?1002h\x1b[?1006h");
    }

    internal static void DisableMouse()
    {
        if (!TerminalCapabilities.SupportsMouse) return;
        if (Interlocked.CompareExchange(ref MouseState, 0, 1) != 1) return;
        lock (ConsoleLock) Console.Write("\x1b[?1000l\x1b[?1002l\x1b[?1006l");
    }
}
