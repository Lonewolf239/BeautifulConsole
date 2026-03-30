namespace BeautifulConsole.Models;

/// <summary>
/// Represents an RGB color with red, green, and blue components.
/// Provides predefined static colors and color manipulation functionality.
/// </summary>
public partial class Color
{
    /// <summary>Gets the red component of the color (0-255).</summary>
    public byte R { get; }

    /// <summary>Gets the green component of the color (0-255).</summary>
    public byte G { get; }

    /// <summary>Gets the blue component of the color (0-255).</summary>
    public byte B { get; }

    /// <summary>Initializes a new instance of the <see cref="Color"/> class with the specified RGB values.</summary>
    /// <param name="r">The red component value (0-255).</param>
    /// <param name="g">The green component value (0-255).</param>
    /// <param name="b">The blue component value (0-255).</param>
    /// <exception cref="ColorArgumentException">Thrown when any RGB value is outside the valid range of 0-255.</exception>
    public Color(int r, int g, int b)
    {
        if (r < 0 || r > 255) throw new ColorArgumentException(nameof(r), r, "Red value must be between 0 and 255.");
        if (g < 0 || g > 255) throw new ColorArgumentException(nameof(g), g, "Green value must be between 0 and 255.");
        if (b < 0 || b > 255) throw new ColorArgumentException(nameof(b), b, "Blue value must be between 0 and 255.");
        R = (byte)r;
        G = (byte)g;
        B = (byte)b;
    }
}
