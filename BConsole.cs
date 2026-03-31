using BeautifulConsole.Core;

namespace BeautifulConsole;

/// <summary>
/// A powerful .NET library for beautiful console applications with colored output, advanced input handling, clipboard support, and console window customization.
/// <br/>
/// Developer: <a href="https://github.com/Lonewolf239">Lonewolf239</a>
/// <br/>
/// <b>Target Frameworks: .NET 6+</b>
/// <br/>
/// <b>Version: 0.2</b>
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
    /// Resets the console's foreground and background colors to their default values (typically white text on a black background).
    /// </summary>
    public static void ResetColor() => ConsoleCore.ResetColor();

    /// <summary>Enables mouse event reporting in the terminal.</summary>
    /// <remarks>
    /// This method sends ANSI escape sequences to enable mouse tracking modes (button events, movement, and SGR format).
    /// Currently, only the enabling of mouse reporting is implemented; reading and processing mouse events will be added in version 0.3.
    /// <br/>
    /// After calling this method, the terminal will send mouse event sequences, but they are not yet handled by the library.
    /// Use this method as a foundation for future mouse support.
    /// </remarks>
    public static void EnableMouse() => ConsoleCore.EnableMouse();

    /// <summary>Disables mouse event reporting in the terminal.</summary>
    /// <remarks>
    /// Sends ANSI escape sequences to disable all mouse tracking modes previously enabled by <see cref="EnableMouse"/>.
    /// This method is safe to call even if mouse reporting is not active.
    /// </remarks>
    public static void DisableMouse() => ConsoleCore.DisableMouse();
}
