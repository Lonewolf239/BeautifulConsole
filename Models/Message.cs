namespace BeautifulConsole.Models;

/// <summary>Represents a console message with optional foreground and background colors.</summary>
public sealed class Message
{
    /// <summary>Gets the message text.</summary>
    public string Text { get; }

    /// <summary>Gets the foreground color.</summary>
    public Color ForegroundColor { get; }

    /// <summary>Gets the background color.</summary>
    public Color BackgroundColor { get; }

    /// <summary>Initializes a new instance of the <see cref="Message"/> class.</summary>
    /// <param name="text">The message text. If <c>null</c>, an empty string is used.</param>
    /// <param name="foreground">The foreground color. If <c>null</c>, <see cref="Color.NoColor"/> is used.</param>
    /// <param name="background">The background color. If <c>null</c>, <see cref="Color.NoColor"/> is used.</param>
    public Message(string? text, Color? foreground = null, Color? background = null)
    {
        Text = text ?? string.Empty;
        ForegroundColor = foreground ?? Color.NoColor;
        BackgroundColor = background ?? Color.NoColor;
    }

    /// <summary>Initializes a new instance of the <see cref="Message"/> class from a character.</summary>
    /// <param name="text">The character to create the message from.</param>
    /// <param name="foreground">The foreground color. If <c>null</c>, <see cref="Color.NoColor"/> is used.</param>
    /// <param name="background">The background color. If <c>null</c>, <see cref="Color.NoColor"/> is used.</param>
    public Message(char text, Color? foreground = null, Color? background = null)
    {
        Text = text.ToString() ?? string.Empty;
        ForegroundColor = foreground ?? Color.NoColor;
        BackgroundColor = background ?? Color.NoColor;
    }
}
