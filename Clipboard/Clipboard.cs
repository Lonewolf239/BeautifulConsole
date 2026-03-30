namespace BeautifulConsole.Clipboard;

/// <summary>Provides cross-platform clipboard operations with Windows support.</summary>
public static partial class Clipboard
{
    private const int MaxRetryAttempts = 3;
    private const int RetryDelayMs = 50;

    /// <summary>Copies text to the system clipboard.</summary>
    /// <param name="text">Text to copy. Cannot be null or empty.</param>
    /// <exception cref="System.ArgumentNullException">Text is null.</exception>
    /// <exception cref="System.ArgumentException">Text is empty.</exception>
    /// <exception cref="System.InvalidOperationException">Clipboard operation failed.</exception>
    public static void SetText(string? text) => SetTextInternal(text);

    /// <summary>Attempts to copy text to the clipboard without throwing exceptions.</summary>
    /// <param name="text">Text to copy. Cannot be null or empty.</param>
    /// <returns>True if copied successfully; otherwise false.</returns>
    public static bool TrySetText(string? text) => TrySetTextInternal(text);

    /// <summary>Retrieves text from the system clipboard.</summary>
    /// <returns>Clipboard text if available; otherwise null.</returns>
    public static string? GetText() => GetTextInternal();

    /// <summary>Checks if text data is available in the clipboard.</summary>
    /// <returns>True if text is available; otherwise false.</returns>
    public static bool IsTextAvailable() => IsTextAvailableInternal();

    /// <summary>Clears the clipboard content.</summary>
    /// <returns>True if cleared successfully; otherwise false.</returns>
    public static bool Clear() => ClearInternal();
}
