using System;

namespace BeautifulConsole.Models;

/// <summary>
/// Represents an RGB color with red, green, and blue components.
/// Provides predefined static colors and color manipulation functionality.
/// </summary>
public partial class Color
{
    /// <summary>Gets a value indicating whether this color was created without RGB values.</summary>
    public bool Empty { get; private set; } = false;

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
    public Color(int r, int g, int b)
    {
        R = (byte)Math.Clamp(r, 0, 255);
        G = (byte)Math.Clamp(g, 0, 255);
        B = (byte)Math.Clamp(b, 0, 255);
    }

    /// <summary>Initializes a new instance of the <see cref="Color"/> class with no color value.</summary>
    public Color() => Empty = true;
}
