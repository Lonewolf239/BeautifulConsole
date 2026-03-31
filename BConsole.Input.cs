using System;
using BeautifulConsole.Core;
using BeautifulConsole.Models;

namespace BeautifulConsole;

public static partial class BConsole
{
    /// <summary>Reads the next character from the standard input stream.</summary>
	/// <param name="newLine">Specifies whether to write a new line before the input. Default is false.</param>
    /// <returns>The next character from the input stream, or -1 if no more characters are available.</returns>
    public static int Read(bool newLine = false) => ConsoleCore.Read(newLine);

    /// <summary>Reads the next character from the standard input stream with a prompt message using the current reset color behavior.</summary>
    /// <param name="message">The prompt message to display.</param>
	/// <param name="newLine">Specifies whether to write a new line before the input. Default is false.</param>
    /// <returns>The next character from the input stream, or -1 if no more characters are available.</returns>
    public static int Read(Message? message, bool newLine = false) => ConsoleCore.Read(message, newLine, AutoResetColor);

    /// <summary>Reads the next character from the standard input stream with a prompt message using the current reset color behavior.</summary>
    /// <param name="message">The prompt message to display. If null or empty, no prompt is shown.</param>
    /// <param name="newLine">Specifies whether to write a new line before the input. Default is false.</param>
    /// <returns>The next character from the input stream, or -1 if no more characters are available.</returns>
    public static int Read(string? message, bool newLine = false) => ConsoleCore.Read(message, newLine, AutoResetColor);

    /// <summary>Reads the next line of characters from the standard input stream.</summary>
	/// <param name="newLine">Specifies whether to write a new line before the input. Default is false.</param>
    /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
    public static string? ReadLine(bool newLine = false) => ConsoleCore.ReadLine(newLine);

    /// <summary>Reads the next line of characters from the standard input stream with a prompt message using the current reset color behavior.</summary>
    /// <param name="message">The prompt message to display.</param>
	/// <param name="newLine">Specifies whether to write a new line before the prompt. Default is false.</param>
    /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
    public static string? ReadLine(Message? message, bool newLine = false) => ConsoleCore.ReadLine(message, newLine, AutoResetColor);

    /// <summary>Reads the next line of characters from the standard input stream with a prompt message using the current reset color behavior.</summary>
    /// <param name="message">The prompt message to display. If null or empty, no prompt is shown.</param>
    /// <param name="newLine">Specifies whether to write a new line before the prompt. Default is false.</param>
    /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
    public static string? ReadLine(string? message, bool newLine = false) => ConsoleCore.ReadLine(message, newLine, AutoResetColor);

    /// <summary>Obtains the next character or function key pressed by the user with specified intercept behavior.</summary>
    /// <param name="intercept">true to prevent the key from being displayed; otherwise, false. Default is false.</param>
	/// <param name="newLine">Specifies whether to write a new line before the input. Default is false.</param>
    /// <returns>A <see cref="ConsoleKeyInfo"/> object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey(bool intercept = false, bool newLine = false) => ConsoleCore.ReadKey(intercept, newLine);

    /// <summary>Obtains the next character or function key pressed by the user with a prompt message and specified intercept behavior.</summary>
    /// <param name="intercept">true to prevent the key from being displayed; otherwise, false.</param>
    /// <param name="message">The prompt message to display.</param>
	/// <param name="newLine">Specifies whether to write a new line before the input. Default is false.</param>
    /// <returns>A <see cref="ConsoleKeyInfo"/> object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey(bool intercept, Message? message, bool newLine = false) =>
        ConsoleCore.ReadKey(intercept, message, newLine, AutoResetColor);

    /// <summary>Obtains the next character or function key pressed by the user with a prompt message and specified intercept behavior.</summary>
    /// <param name="intercept">Specifies whether to intercept the key press, preventing it from being displayed in the console window.</param>
    /// <param name="message">The prompt message to display. If null or empty, no prompt is shown.</param>
    /// <param name="newLine">Specifies whether to write a new line before the input. Default is false.</param>
    /// <returns>A <see cref="ConsoleKeyInfo"/> object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey(bool intercept, string? message, bool newLine = false) =>
            ConsoleCore.ReadKey(intercept, message, newLine, AutoResetColor);
}
