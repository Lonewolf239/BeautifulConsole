using System;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class ConsoleCore
{
    public static void Clear()
    {
        Console.Clear();
        if (SupportsExtendedClear()) Console.Write("\x1b[3J");
    }

    public static void Write(string? line, Color foregroundColor, Color backgroundColor, bool resetColor)
    {
        if (string.IsNullOrEmpty(line)) return;
        SetForegroundColor(foregroundColor);
        SetBackgroundColor(backgroundColor);
        Console.Write(line);
        if (resetColor) ResetColor();
    }

    public static void WriteLine() => Console.WriteLine();

    public static void WriteLine(string? line, Color foregroundColor, Color backgroundColor, bool resetColor)
    {
        if (string.IsNullOrEmpty(line))
        {
            Console.WriteLine();
            return;
        }
        SetForegroundColor(foregroundColor);
        SetBackgroundColor(backgroundColor);
        Console.WriteLine(line);
        if (resetColor) ResetColor();
    }
}
