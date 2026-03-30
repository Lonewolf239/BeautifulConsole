using System;
using BeautifulConsole.Models;

namespace BeautifulConsole;

public static partial class BConsole
{
    /// <summary>
    /// Gets or sets a value indicating whether colors should automatically reset after each write operation.
    /// When true, colors are reset to the default console colors after each write. When false, colors persist.
    /// The default value is true.
    /// </summary>
    public static bool AutoResetColor { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the cursor is visible.
    /// </summary>
    public static bool CursorVisible
    {
#if WINDOWS
        get => Console.CursorVisible;
#endif
        set => Console.CursorVisible = value;
    }

    /// <summary>
    /// Gets or sets the default foreground color used for console output when colors are reset.
    /// The default value is <see cref="Color.White"/>.
    /// </summary>
    public static Color DefaultForegroundColor { get; set; } = Color.White;

    /// <summary>
    /// Gets or sets the default background color used for console output when colors are reset.
    /// The default value is <see cref="Color.Black"/>.
    /// </summary>
    public static Color DefaultBackgroundColor { get; set; } = Color.Black;

    /// <summary>
    /// Gets or sets the width of the console window measured in columns.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">The value is less than the current buffer width or greater than the largest possible window width.</exception>
    /// <exception cref="System.IO.IOException">An I/O error occurred.</exception>
    public static int WindowWidth
    {
        get => Console.WindowWidth;
#if WINDOWS
        set => Console.WindowWidth = value;
#endif
    }

    /// <summary>
    /// Gets or sets the height of the console window measured in rows.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">The value is less than the current buffer height or greater than the largest possible window height.</exception>
    /// <exception cref="System.IO.IOException">An I/O error occurred.</exception>
    public static int WindowHeight
    {
        get => Console.WindowHeight;
#if WINDOWS
        set => Console.WindowHeight = value;
#endif
    }

    /// <summary>
    /// Gets or sets the width of the console screen buffer measured in columns.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">The value is less than the current window width or greater than the maximum allowed buffer width.</exception>
    /// <exception cref="System.IO.IOException">An I/O error occurred.</exception>
    public static int BufferWidth
    {
        get => Console.BufferWidth;
#if WINDOWS
        set => Console.BufferWidth = value;
#endif
    }

    /// <summary>
    /// Gets or sets the height of the console screen buffer measured in rows.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">The value is less than the current window height or greater than the maximum allowed buffer height.</exception>
    /// <exception cref="System.IO.IOException">An I/O error occurred.</exception>
    public static int BufferHeight
    {
        get => Console.BufferHeight;
#if WINDOWS
        set => Console.BufferHeight = value;
#endif
    }

    /// <summary>
    /// Gets or sets the title to display in the console title bar.
    /// </summary>
    /// <exception cref="InvalidOperationException">The current platform does not support console window titles.</exception>
    /// <exception cref="System.IO.IOException">An I/O error occurred.</exception>
    public static string Title
    {
#if WINDOWS
        get => Console.Title;
#endif
        set => Console.Title = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the combination of the Ctrl modifier key and C console key (Ctrl+C)
    /// is treated as ordinary input rather than as an interrupt.
    /// </summary>
    public static bool TreatControlCAsInput
    {
        get => Console.TreatControlCAsInput;
        set => Console.TreatControlCAsInput = value;
    }

    /// <summary>
    /// Gets or sets the size of the cursor in a character cell (1 to 100).
    /// </summary>
    /// <value>The size of the cursor expressed as a percentage of the height of a character cell.</value>
    /// <exception cref="ArgumentOutOfRangeException">The value is less than 1 or greater than 100.</exception>
    /// <remarks>This property may not be supported on all platforms.</remarks>
    public static int CursorSize
    {
        get => Console.CursorSize;
#if WINDOWS
        set => Console.CursorSize = value;
#endif
    }

#if WINDOWS
    /// <summary>
    /// Gets a value indicating whether the NUM LOCK keyboard toggle is turned on or off.
    /// </summary>
    public static bool NumberLock => Console.NumberLock;

    /// <summary>
    /// Gets a value indicating whether the CAPS LOCK keyboard toggle is turned on or off.
    /// </summary>
    public static bool CapsLock => Console.CapsLock;
#endif

    /// <summary>
    /// Gets the largest possible number of columns for the console window based on the current font and screen resolution.
    /// </summary>
    public static int LargestWindowWidth => Console.LargestWindowWidth;

    /// <summary>
    /// Gets the largest possible number of rows for the console window based on the current font and screen resolution.
    /// </summary>
    public static int LargestWindowHeight => Console.LargestWindowHeight;

    /// <summary>
    /// Gets a value indicating whether the standard input has been redirected.
    /// </summary>
    public static bool IsInputRedirected => Console.IsInputRedirected;

    /// <summary>
    /// Gets a value indicating whether the standard output has been redirected.
    /// </summary>
    public static bool IsOutputRedirected => Console.IsOutputRedirected;

    /// <summary>
    /// Gets a value indicating whether the error output has been redirected.
    /// </summary>
    public static bool IsErrorRedirected => Console.IsErrorRedirected;

    /// <summary>
    /// Gets or sets the encoding used by the console for reading input.
    /// </summary>
    /// <exception cref="ArgumentNullException">The value is null.</exception>
    /// <exception cref="System.IO.IOException">An I/O error occurred.</exception>
    public static System.Text.Encoding InputEncoding
    {
        get => Console.InputEncoding;
        set => Console.InputEncoding = value;
    }

    /// <summary>
    /// Gets or sets the encoding used by the console for writing output.
    /// </summary>
    /// <exception cref="ArgumentNullException">The value is null.</exception>
    /// <exception cref="System.IO.IOException">An I/O error occurred.</exception>
    public static System.Text.Encoding OutputEncoding
    {
        get => Console.OutputEncoding;
        set => Console.OutputEncoding = value;
    }
}
