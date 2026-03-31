namespace BeautifulConsole.Models;

/// <summary>Represents a console message with optional foreground and background colors.</summary>
public sealed class Message
{
    /// <summary>Gets the message text.</summary>
    public string Text { get; }

    /// <summary>Gets the foreground color.</summary>
    public Color ForegroundColor { get; } = Color.NoColor;

    /// <summary>Gets the background color.</summary>
    public Color BackgroundColor { get; } = Color.NoColor;

    /// <summary>Initializes a new instance of the <see cref="Message"/> class with text only.</summary>
    /// <param name="text">The message text.</param>
    public Message(string? text) => Text = text ?? string.Empty;

    /// <summary>Initializes a new instance of the <see cref="Message"/> class with text and foreground color.</summary>
    /// <param name="text">The message text.</param>
    /// <param name="foregroundColor">The foreground color.</param>
    public Message(string? text, Color foregroundColor)
    {
        Text = text ?? string.Empty;
        ForegroundColor = foregroundColor;
    }

    /// <summary>Initializes a new instance of the <see cref="Message"/> class with text, foreground color, and background color.</summary>
    /// <param name="text">The message text.</param>
    /// <param name="foregroundColor">The foreground color.</param>
    /// <param name="backgroundColor">The background color.</param>
    public Message(string? text, Color foregroundColor, Color backgroundColor)
    {
        Text = text ?? string.Empty;
        ForegroundColor = foregroundColor;
        BackgroundColor = backgroundColor;
    }
}
