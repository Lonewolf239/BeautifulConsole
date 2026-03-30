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
    /// Gets or sets the default foreground color used for console output when colors are reset.
    /// The default value is <see cref="Color.White"/>.
    /// </summary>
    public static Color DefaultForegroundColor { get; set; } = Color.White;

    /// <summary>
    /// Gets or sets the default background color used for console output when colors are reset.
    /// The default value is <see cref="Color.Black"/>.
    /// </summary>
    public static Color DefaultBackgroundColor { get; set; } = Color.Black;
}
