using System;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class ConsoleCore
{
    internal static int Read(bool newLine)
    {
        lock (ConsoleLock)
        {
            if (newLine) Console.WriteLine();
            return Console.Read();
        }
    }

    internal static int Read(Message? message, bool newLine, bool resetColor)
    {
        lock (ConsoleLock)
        {
            if (newLine) Console.WriteLine();
            if (message is not null) WriteCore(message, resetColor);
            return Console.Read();
        }
    }

    internal static int Read(string? message, bool newLine, bool resetColor) =>
        Read(new Message(message), newLine, resetColor);

    internal static string? ReadLine(bool newLine)
    {
        lock (ConsoleLock)
        {
            if (newLine) Console.WriteLine();
            return Console.ReadLine();
        }
    }

    internal static string? ReadLine(Message? message, bool newLine, bool resetColor)
    {
        lock (ConsoleLock)
        {
            if (newLine) Console.WriteLine();
            if (message is not null) WriteCore(message, resetColor);
            return Console.ReadLine();
        }
    }

    internal static string? ReadLine(string? message, bool newLine, bool resetColor) =>
        ReadLine(new Message(message), newLine, resetColor);

    internal static ConsoleKeyInfo ReadKey(bool intercept, bool newLine)
    {
        lock (ConsoleLock)
        {
            if (newLine) Console.WriteLine();
            return Console.ReadKey(intercept);
        }
    }

    internal static ConsoleKeyInfo ReadKey(bool intercept, Message? message, bool newLine, bool resetColor)
    {
        lock (ConsoleLock)
        {
            if (newLine) Console.WriteLine();
            if (message is not null) WriteCore(message, resetColor);
            return Console.ReadKey(intercept);
        }
    }


    internal static ConsoleKeyInfo ReadKey(bool intercept, string? message, bool newLine, bool resetColor) =>
        ReadKey(intercept, new Message(message), newLine, resetColor);
}
