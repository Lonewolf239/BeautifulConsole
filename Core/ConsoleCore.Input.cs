using System;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class ConsoleCore
{
    public static int Read() => Console.Read();

    public static int Read(Message? message, bool resetColor)
    {
        if (message is not null) Write(message, resetColor);
        return Console.Read();
    }

    public static string? ReadLine(bool newLine)
    {
        if (newLine) Console.WriteLine();
        return Console.ReadLine();
    }

    public static string? ReadLine(Message? message, bool newLine, bool resetColor)
    {
        if (newLine) Console.WriteLine();
        if (message is not null) Write(message, resetColor);
        return Console.ReadLine();
    }

    public static ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);

    public static ConsoleKeyInfo ReadKey(bool intercept, Message? message, bool resetColor)
    {
        if (message is not null) Write(message, resetColor);
        return Console.ReadKey(intercept);
    }
}
