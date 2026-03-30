using System;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class ConsoleCore
{
    public static int Read() => Console.Read();

    public static int Read(string? message, Color foregroundColor, Color backgroundColor, bool resetColor)
    {
        if (message is not null) Write(message, foregroundColor, backgroundColor, resetColor);
        return Console.Read();
    }

    public static string? ReadLine() => Console.ReadLine();

    public static string? ReadLine(string? message, Color foregroundColor, Color backgroundColor, bool resetColor)
    {
        if (message is not null) Write(message, foregroundColor, backgroundColor, resetColor);
        return Console.ReadLine();
    }

    public static ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);

    public static ConsoleKeyInfo ReadKey(bool intercept, string? message, Color foregroundColor, Color backgroundColor, bool resetColor)
    {
        if (message is not null) Write(message, foregroundColor, backgroundColor, resetColor);
        return Console.ReadKey(intercept);
    }
}
