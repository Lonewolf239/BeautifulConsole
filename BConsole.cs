using BeautifulConsole.Core;

namespace BeautifulConsole;

/// <summary>
/// A powerful .NET library for beautiful console applications with colored output, advanced input handling, clipboard support, and console window customization.
/// <br/>
/// Developer: <a href="https://github.com/Lonewolf239">Lonewolf239</a>
/// <br/>
/// <b>Target Frameworks: .NET 6+</b>
/// <br/>
/// <b>Version: 0.1.2</b>
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
}
