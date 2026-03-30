using System;
using BeautifulConsole.Core;
using BeautifulConsole.Models;

namespace BeautifulConsole;

public static partial class BConsole
{
    /// <summary>Reads the next character from the standard input stream.</summary>
    /// <returns>The next character from the input stream, or -1 if no more characters are available.</returns>
    public static int Read() => ConsoleCore.Read();

    /// <summary>Reads the next character from the standard input stream with a prompt message using default white text on black background.</summary>
    /// <param name="message">The prompt message to display before reading input.</param>
    /// <returns>The next character from the input stream, or -1 if no more characters are available.</returns>
    public static int Read(string? message) =>
        ConsoleCore.Read(message, DefaultForegroundColor, DefaultBackgroundColor, AutoResetColor);

    /// <summary>Reads the next character from the standard input stream with a prompt message and custom foreground color.</summary>
    /// <param name="message">The prompt message to display before reading input.</param>
    /// <param name="foregroundColor">The color of the prompt text.</param>
    /// <returns>The next character from the input stream, or -1 if no more characters are available.</returns>
    public static int Read(string? message, Color foregroundColor) =>
        ConsoleCore.Read(message, foregroundColor, DefaultBackgroundColor, AutoResetColor);

    /// <summary>Reads the next character from the standard input stream with a prompt message and custom foreground and background colors.</summary>
    /// <param name="message">The prompt message to display before reading input.</param>
    /// <param name="foregroundColor">The color of the prompt text.</param>
    /// <param name="backgroundColor">The background color of the prompt text.</param>
    /// <returns>The next character from the input stream, or -1 if no more characters are available.</returns>
    public static int Read(string? message, Color foregroundColor, Color backgroundColor) =>
        ConsoleCore.Read(message, foregroundColor, backgroundColor, AutoResetColor);

    /// <summary>Reads the next line of characters from the standard input stream.</summary>
    /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
    public static string? ReadLine() => ConsoleCore.ReadLine();

    /// <summary>Reads the next line of characters from the standard input stream with a prompt message using default white text on black background.</summary>
    /// <param name="message">The prompt message to display before reading input.</param>
    /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
    public static string? ReadLine(string? message) =>
        ConsoleCore.ReadLine(message, DefaultForegroundColor, DefaultBackgroundColor, AutoResetColor);

    /// <summary>Reads the next line of characters from the standard input stream with a prompt message and custom foreground color.</summary>
    /// <param name="message">The prompt message to display before reading input.</param>
    /// <param name="foregroundColor">The color of the prompt text.</param>
    /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
    public static string? ReadLine(string? message, Color foregroundColor) =>
        ConsoleCore.ReadLine(message, foregroundColor, DefaultBackgroundColor, AutoResetColor);

    /// <summary>Reads the next line of characters from the standard input stream with a prompt message and custom foreground and background colors.</summary>
    /// <param name="message">The prompt message to display before reading input.</param>
    /// <param name="foregroundColor">The color of the prompt text.</param>
    /// <param name="backgroundColor">The background color of the prompt text.</param>
    /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
    public static string? ReadLine(string? message, Color foregroundColor, Color backgroundColor) =>
        ConsoleCore.ReadLine(message, foregroundColor, backgroundColor, AutoResetColor);

    /// <summary>Obtains the next character or function key pressed by the user.</summary>
    /// <returns>A ConsoleKeyInfo object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey() => ConsoleCore.ReadKey(false);

    /// <summary>Obtains the next character or function key pressed by the user with specified intercept behavior.</summary>
    /// <param name="intercept">Determines whether to display the pressed key (false) or not (true).</param>
    /// <returns>A ConsoleKeyInfo object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey(bool intercept) => ConsoleCore.ReadKey(intercept);

    /// <summary>Obtains the next character or function key pressed by the user with a prompt message and specified intercept behavior.</summary>
    /// <param name="intercept">Determines whether to display the pressed key (false) or not (true).</param>
    /// <param name="message">The prompt message to display before reading the key.</param>
    /// <returns>A ConsoleKeyInfo object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey(bool intercept, string? message) =>
        ConsoleCore.ReadKey(intercept, message, DefaultForegroundColor, DefaultBackgroundColor, AutoResetColor);

    /// <summary>
    /// Obtains the next character or function key pressed by the user with a prompt message, custom foreground color, and specified intercept behavior.
    /// </summary>
    /// <param name="intercept">Determines whether to display the pressed key (false) or not (true).</param>
    /// <param name="message">The prompt message to display before reading the key.</param>
    /// <param name="foregroundColor">The color of the prompt text.</param>
    /// <returns>A ConsoleKeyInfo object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey(bool intercept, string? message, Color foregroundColor) =>
        ConsoleCore.ReadKey(intercept, message, foregroundColor, DefaultBackgroundColor, AutoResetColor);

    /// <summary>Obtains the next character or function key pressed by the user with a prompt message, custom colors, and specified intercept behavior.</summary>
    /// <param name="intercept">Determines whether to display the pressed key (false) or not (true).</param>
    /// <param name="message">The prompt message to display before reading the key.</param>
    /// <param name="foregroundColor">The color of the prompt text.</param>
    /// <param name="backgroundColor">The background color of the prompt text.</param>
    /// <returns>A ConsoleKeyInfo object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey(bool intercept, string? message, Color foregroundColor, Color backgroundColor) =>
        ConsoleCore.ReadKey(intercept, message, foregroundColor, backgroundColor, AutoResetColor);
}
