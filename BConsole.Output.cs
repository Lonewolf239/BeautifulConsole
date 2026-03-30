using BeautifulConsole.Core;
using BeautifulConsole.Models;

namespace BeautifulConsole;

public static partial class BConsole
{
    /// <summary>
    /// Writes the specified string value to the standard output stream using default white text on black background.
    /// </summary>
    /// <param name="line">The value to write. If null, nothing is written.</param>
    public static void Write(string? line) =>
        ConsoleCore.Write(line, DefaultForegroundColor, DefaultBackgroundColor, AutoResetColor);

    /// <summary>
    /// Writes the specified string value to the standard output stream using a custom foreground color.
    /// </summary>
    /// <param name="line">The value to write. If null, nothing is written.</param>
    /// <param name="foregroundColor">The color of the text to write.</param>
    public static void Write(string? line, Color foregroundColor) =>
        ConsoleCore.Write(line, foregroundColor, DefaultBackgroundColor, AutoResetColor);

    /// <summary>
    /// Writes the specified string value to the standard output stream using custom foreground and background colors.
    /// </summary>
    /// <param name="line">The value to write. If null, nothing is written.</param>
    /// <param name="foregroundColor">The color of the text to write.</param>
    /// <param name="backgroundColor">The background color behind the text.</param>
    public static void Write(string? line, Color foregroundColor, Color backgroundColor) =>
        ConsoleCore.Write(line, foregroundColor, backgroundColor, AutoResetColor);

    /// <summary>
    /// Writes a line terminator to the standard output stream using default white text on black background.
    /// </summary>
    public static void WriteLine() => ConsoleCore.WriteLine();

    /// <summary>
    /// Writes the specified string value, followed by a line terminator, to the standard output stream using default white text on black background.
    /// </summary>
    /// <param name="line">The value to write. If null, only the line terminator is written.</param>
    public static void WriteLine(string? line) =>
        ConsoleCore.WriteLine(line, DefaultForegroundColor, DefaultBackgroundColor, AutoResetColor);

    /// <summary>
    /// Writes the specified string value, followed by a line terminator, to the standard output stream using a custom foreground color.
    /// </summary>
    /// <param name="line">The value to write. If null, only the line terminator is written.</param>
    /// <param name="foregroundColor">The color of the text to write.</param>
    public static void WriteLine(string? line, Color foregroundColor) =>
        ConsoleCore.WriteLine(line, foregroundColor, DefaultBackgroundColor, AutoResetColor);

    /// <summary>
    /// Writes the specified string value, followed by a line terminator, to the standard output stream using custom foreground and background colors.
    /// </summary>
    /// <param name="line">The value to write. If null, only the line terminator is written.</param>
    /// <param name="foregroundColor">The color of the text to write.</param>
    /// <param name="backgroundColor">The background color behind the text.</param>
    public static void WriteLine(string? line, Color foregroundColor, Color backgroundColor) =>
        ConsoleCore.WriteLine(line, foregroundColor, backgroundColor, AutoResetColor);
}
