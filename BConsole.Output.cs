using System.Text;
using BeautifulConsole.Core;
using BeautifulConsole.Models;

namespace BeautifulConsole;

public static partial class BConsole
{
    /// <summary>Writes the specified message to the standard output stream using the current reset color behavior.</summary>
    /// <param name="message">The message to write.</param>
    public static void Write(Message? message) => ConsoleCore.Write(message, AutoResetColor);

    /// <summary>Writes the specified message to the standard output stream using the current reset color behavior.</summary>
    /// <param name="message">The message to write. If null or empty, no action is performed.</param>
    public static void Write(string? message) => ConsoleCore.Write(message, AutoResetColor);

    /// <summary>Writes a line terminator to the standard output stream.</summary>
    public static void WriteLine() => ConsoleCore.WriteLine();

    /// <summary>Writes the specified message, followed by a line terminator, to the standard output stream using the current reset color behavior.</summary>
    /// <param name="message">The message to write.</param>
    public static void WriteLine(Message? message) => ConsoleCore.WriteLine(message, AutoResetColor);

    /// <summary>Writes the specified message, followed by a line terminator, to the standard output stream using the current reset color behavior.</summary>
    /// <param name="message">The message to write. If null or empty, no action is performed.</param>
    public static void WriteLine(string? message) => ConsoleCore.WriteLine(message, AutoResetColor);

    /// <summary>Writes a text with a gradient from startColor to endColor.</summary>
    /// <param name="text">The text to write.</param>
    /// <param name="startColor">Starting color of the gradient.</param>
    /// <param name="endColor">Ending color of the gradient.</param>
    /// <param name="resetAfter">If true, resets color after writing.</param>
    public static void WriteGradient(string text, Color startColor, Color endColor, bool resetAfter = true)
    {
        if (string.IsNullOrEmpty(text)) return;
        if (text.Length == 1)
        {
            Write(new Message(text, startColor, Color.NoColor));
            return;
        }
        var colors = Color.Gradient(startColor, endColor, text.Length);
        StringBuilder output = new();
        for (int i = 0; i < text.Length; i++)
        {
            var (_, symbol) = ConsoleCore.GetTextWithColor(new Message(text[i].ToString(), colors[i]));
            output.Append(symbol);
        }
        lock (ConsoleCore.ConsoleLock) System.Console.Write(output.ToString());
        if (resetAfter && AutoResetColor) ResetColor();
    }
}
