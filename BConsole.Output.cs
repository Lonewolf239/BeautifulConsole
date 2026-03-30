using BeautifulConsole.Core;
using BeautifulConsole.Models;

namespace BeautifulConsole;

/// <summary>
/// A powerful .NET library for beautiful console applications with colored output, advanced input handling, clipboard support, and console window customization.
/// <br/>
/// Developer: <a href="https://github.com/Lonewolf239">Lonewolf239</a>
/// <br/>
/// <b>Target Frameworks: .NET 6+</b>
/// <br/>
/// <b>Version: 0.1</b>
/// <br/>
/// <b>Black Box Philosophy:</b> This class follows a strict "black box" design principle - users interact only through the public API without needing to understand internal implementation details. Input goes in, processed output comes out, internals remain hidden and abstracted.
/// </summary>
public static partial class BConsole
{
    /// <summary>
    /// Clears the console buffer and corresponding console window of display information.
    /// </summary>
    public static void Clear() => ConsoleCore.Clear();

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

    /// <summary>
    /// Resets the console's foreground and background colors to their default values (typically white text on a black background).
    /// </summary>
    public static void ResetColor() => ConsoleCore.ResetColor();
}
