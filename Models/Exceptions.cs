using System;

namespace BeautifulConsole.Models;

/// <summary>
/// The exception that is thrown when an invalid RGB color value is provided.
/// </summary>
public class ColorArgumentException : ArgumentException
{
    /// <summary>
    /// Gets the invalid value that caused the exception.
    /// </summary>
    public int InvalidValue { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorArgumentException"/> class with the parameter name,
    /// invalid value, and error message.
    /// </summary>
    /// <param name="paramName">The name of the parameter that caused the exception.</param>
    /// <param name="invalidValue">The invalid value that was provided.</param>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public ColorArgumentException(string paramName, int invalidValue, string message)
        : base(message, paramName)
    {
        InvalidValue = invalidValue;
    }
}
