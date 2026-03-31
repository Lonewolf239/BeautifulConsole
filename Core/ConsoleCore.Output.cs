using System;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class ConsoleCore
{
    public static void Clear()
    {
        Console.Clear();
        if (TerminalCapabilities.SupportsAnsi) Console.Write("\x1b[3J");
    }

    public static void Write(Message? message, bool resetColor)
    {
        if (message is null) return;
        if (string.IsNullOrEmpty(message.Text)) return;
        string text = message.Text;
        bool colorChanged = !message.ForegroundColor.Empty || !message.BackgroundColor.Empty;
        text = SetForegroundColor(text, message.ForegroundColor);
        text = SetBackgroundColor(text, message.BackgroundColor);
        Console.Write(text.ToString());
        if (colorChanged && resetColor) ResetColor();
    }

    public static void WriteLine() => Console.WriteLine();

    public static void WriteLine(Message? message, bool resetColor)
    {
        if (message is null) return;
        if (string.IsNullOrEmpty(message.Text))
        {
            Console.WriteLine();
            return;
        }
        string text = message.Text;
        bool colorChanged = !message.ForegroundColor.Empty || !message.BackgroundColor.Empty;
        text = SetForegroundColor(text, message.ForegroundColor);
        text = SetBackgroundColor(text, message.BackgroundColor);
        Console.WriteLine(text.ToString());
        if (colorChanged && resetColor) ResetColor();
    }
}
