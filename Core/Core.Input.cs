using System;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class BCCore
{
    public static int Read()
    {
        return Console.Read();
    }

    public static string? ReadLine(string? message, Color color)
    {
        if (message is not null) Write(message, color);
        return Console.ReadLine();
    }

    public static ConsoleKeyInfo ReadKey(bool intercept, string? message, Color color)
    {
        if (message is not null) Write(message, color);
        return Console.ReadKey(intercept);
    }
}
