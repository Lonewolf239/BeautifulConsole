using System;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class BCCore
{
    public static void Clear() { }

    public static void Write(string? line, Color color)
    {
        Console.Write(line);
    }

    public static void WriteLine(string? line, Color color)
    {
        Console.WriteLine(line);
    }
}
