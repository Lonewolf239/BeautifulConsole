using System;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class ConsoleCore
{
    internal static void Clear()
    {
        lock (ConsoleLock)
        {
            Console.Clear();
            if (TerminalCapabilities.SupportsAnsi) Console.Write("\x1b[3J");
        }
    }

    private static void WriteCore(Message? message, bool resetColor)
    {
        if (message is null) return;
        if (string.IsNullOrEmpty(message.Text)) return;
        var (colorChanged, text) = GetTextWithColor(message);
        Console.Write(text);
        if (colorChanged && resetColor) ResetColorCore();
    }

    internal static void Write(Message? message, bool resetColor) { lock (ConsoleLock) WriteCore(message, resetColor); }

    internal static void Write(string? message, bool resetColor) => Write(new Message(message), resetColor);

    internal static void WriteLine() { lock (ConsoleLock) Console.WriteLine(); }

    private static void WriteLineCore(Message? message, bool resetColor)
    {
        if (message is null) return;
        if (string.IsNullOrEmpty(message.Text))
        {
            Console.WriteLine();
            return;
        }
        var (colorChanged, text) = GetTextWithColor(message);
        Console.WriteLine(text);
        if (colorChanged && resetColor) ResetColorCore();
    }

    internal static void WriteLine(Message? message, bool resetColor) { lock (ConsoleLock) WriteLineCore(message, resetColor); }

    internal static void WriteLine(string? message, bool resetColor) => WriteLine(new Message(message), resetColor);
}
