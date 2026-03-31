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

    /// <summary>Initializes a new instance of the <see cref="Color"/> class with no color value.</summary>
    public Color() => Empty = true;

    /// <summary>Creates a new <see cref="Color"/> instance with RGB values clamped to the valid range of 0-255.</summary>
    /// <param name="r">The red component value to clamp and use (0-255).</param>
    /// <param name="g">The green component value to clamp and use (0-255).</param>
    /// <param name="b">The blue component value to clamp and use (0-255).</param>
    /// <returns>A new <see cref="Color"/> instance with the clamped RGB values.</returns>
    /// <remarks>
    /// Unlike the constructor, this method does not throw an exception when values are outside the 0-255 range.
    /// Instead, values are automatically clamped to the nearest valid boundary.
    /// </remarks>
    public static Color CreateClamped(int r, int g, int b) =>
        new(Math.Clamp(r, 0, 255), Math.Clamp(g, 0, 255), Math.Clamp(b, 0, 255));

    /// <summary>Determines whether the specified object is equal to the current color.</summary>
    /// <param name="obj">The object to compare with the current color.</param>
    /// <returns><see langword="true"/> if the specified object is equal to the current color; otherwise, <see langword="false"/>.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not Color other) return false;
        if (Empty && other.Empty) return true;
        return R == other.R && G == other.G && B == other.B;
    }

    /// <summary>Returns a hash code for the current color.</summary>
    /// <returns>A hash code for the current color.</returns>
    public override int GetHashCode()
    {
        if (Empty) return 0;
        return HashCode.Combine(R, G, B);
    }
}
