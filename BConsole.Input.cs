using System;
using BeautifulConsole.Core;
using BeautifulConsole.Models;

namespace BeautifulConsole;

public static partial class BConsole
{
    /// <summary>Reads the next character from the standard input stream.</summary>
    /// <returns>The next character from the input stream, or -1 if no more characters are available.</returns>
    public static int Read() => ConsoleCore.Read();

    /// <summary>Reads the next character from the standard input stream with a prompt message using the current reset color behavior.</summary>
    /// <param name="message">The prompt message to display.</param>
    /// <returns>The next character from the input stream, or -1 if no more characters are available.</returns>
    public static int Read(Message? message) => ConsoleCore.Read(message, AutoResetColor);

    /// <summary>Reads the next line of characters from the standard input stream.</summary>
	/// <param name="newLine">Specifies whether to write a new line before the input. Default is true.</param>
    /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
    public static string? ReadLine(bool newLine = true) => ConsoleCore.ReadLine(newLine);

    /// <summary>Reads the next line of characters from the standard input stream with a prompt message using the current reset color behavior.</summary>
    /// <param name="message">The prompt message to display.</param>
	/// <param name="newLine">Specifies whether to write a new line before the prompt. Default is true.</param>
    /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
    public static string? ReadLine(Message? message, bool newLine = true) => ConsoleCore.ReadLine(message, newLine, AutoResetColor);

    /// <summary>Obtains the next character or function key pressed by the user.</summary>
    /// <returns>A <see cref="ConsoleKeyInfo"/> object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey() => ConsoleCore.ReadKey(false);

    /// <summary>Obtains the next character or function key pressed by the user with specified intercept behavior.</summary>
    /// <param name="intercept">true to prevent the key from being displayed; otherwise, false.</param>
    /// <returns>A <see cref="ConsoleKeyInfo"/> object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey(bool intercept) => ConsoleCore.ReadKey(intercept);

    /// <summary>Obtains the next character or function key pressed by the user with a prompt message and specified intercept behavior.</summary>
    /// <param name="intercept">true to prevent the key from being displayed; otherwise, false.</param>
    /// <param name="message">The prompt message to display.</param>
    /// <returns>A <see cref="ConsoleKeyInfo"/> object that describes the console key that was pressed.</returns>
    public static ConsoleKeyInfo ReadKey(bool intercept, Message? message) => ConsoleCore.ReadKey(intercept, message, AutoResetColor);
}
