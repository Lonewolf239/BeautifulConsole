using System;

namespace BeautifulConsole.Models;

public partial class Color
{
    /// <summary>Blends this color with another color.</summary>
    /// <param name="other">The other color to blend with.</param>
    /// <param name="ratio">Blend ratio (0 = this color, 1 = other color).</param>
    /// <returns>Blended color.</returns>
    public Color Blend(Color other, double ratio)
    {
        ratio = Math.Clamp(ratio, 0, 1);
        int r = (int)(R * (1 - ratio) + other.R * ratio);
        int g = (int)(G * (1 - ratio) + other.G * ratio);
        int b = (int)(B * (1 - ratio) + other.B * ratio);
        return new Color(r, g, b);
    }

    /// <summary>Generates a gradient between two colors.</summary>
    /// <param name="start">Start color.</param>
    /// <param name="end">End color.</param>
    /// <param name="steps">Number of colors in the gradient (must be >= 2).</param>
    /// <returns>Array of colors representing the gradient.</returns>
    /// <exception cref="ArgumentException">Thrown when steps is less than 2.</exception>
    public static Color[] Gradient(Color start, Color end, int steps)
    {
        if (steps < 2) throw new ArgumentException("Steps must be at least 2.", nameof(steps));
        var colors = new Color[steps];
        for (int i = 0; i < steps; i++)
        {
            double t = i / (double)(steps - 1);
            colors[i] = start.Blend(end, t);
        }
        return colors;
    }

    /// <summary>Converts the color to HSL (Hue, Saturation, Lightness).</summary>
    /// <returns>Tuple with H (0-360), S (0-1), L (0-1).</returns>
    public (double H, double S, double L) ToHsl()
    {
        double r = R / 255.0;
        double g = G / 255.0;
        double b = B / 255.0;
        double max = Math.Max(r, Math.Max(g, b));
        double min = Math.Min(r, Math.Min(g, b));
        double h = 0, s, l = (max + min) / 2;
        if (Math.Abs(max - min) < 1e-9) h = s = 0;
        else
        {
            double d = max - min;
            s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
            if (Math.Abs(max - r) < 1e-9) h = (g - b) / d + (g < b ? 6 : 0);
            else if (Math.Abs(max - g) < 1e-9) h = (b - r) / d + 2;
            else h = (r - g) / d + 4;
            h *= 60;
        }
        return (h, s, l);
    }

    /// <summary>Creates a color from HSL values.</summary>
    /// <param name="h">Hue (0-360).</param>
    /// <param name="s">Saturation (0-1).</param>
    /// <param name="l">Lightness (0-1).</param>
    /// <returns>New Color instance.</returns>
    public static Color FromHsl(double h, double s, double l)
    {
        h = ((h % 360) + 360) % 360;
        s = Math.Clamp(s, 0, 1);
        l = Math.Clamp(l, 0, 1);
        double c = (1 - Math.Abs(2 * l - 1)) * s;
        double x = c * (1 - Math.Abs((h / 60) % 2 - 1));
        double m = l - c / 2;
        double r, g, b;
        if (h < 60) { r = c; g = x; b = 0; }
        else if (h < 120) { r = x; g = c; b = 0; }
        else if (h < 180) { r = 0; g = c; b = x; }
        else if (h < 240) { r = 0; g = x; b = c; }
        else if (h < 300) { r = x; g = 0; b = c; }
        else { r = c; g = 0; b = x; }
        return new Color((int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));
    }

    /// <summary>Converts the color to HSV (Hue, Saturation, Value).</summary>
    /// <returns>Tuple with H (0-360), S (0-1), V (0-1).</returns>
    public (double H, double S, double V) ToHsv()
    {
        double r = R / 255.0;
        double g = G / 255.0;
        double b = B / 255.0;
        double max = Math.Max(r, Math.Max(g, b));
        double min = Math.Min(r, Math.Min(g, b));
        double h = 0, s, v = max;
        double d = max - min;
        s = max == 0 ? 0 : d / max;
        if (Math.Abs(max - min) < 1e-9) h = 0;
        else
        {
            if (Math.Abs(max - r) < 1e-9) h = (g - b) / d + (g < b ? 6 : 0);
            else if (Math.Abs(max - g) < 1e-9) h = (b - r) / d + 2;
            else h = (r - g) / d + 4;
            h *= 60;
        }
        return (h, s, v);
    }

    /// <summary>Creates a color from HSV values.</summary>
    /// <param name="h">Hue (0-360).</param>
    /// <param name="s">Saturation (0-1).</param>
    /// <param name="v">Value (0-1).</param>
    /// <returns>New Color instance.</returns>
    public static Color FromHsv(double h, double s, double v)
    {
        h = ((h % 360) + 360) % 360;
        s = Math.Clamp(s, 0, 1);
        v = Math.Clamp(v, 0, 1);
        double c = v * s;
        double x = c * (1 - Math.Abs((h / 60) % 2 - 1));
        double m = v - c;
        double r, g, b;
        if (h < 60) { r = c; g = x; b = 0; }
        else if (h < 120) { r = x; g = c; b = 0; }
        else if (h < 180) { r = 0; g = c; b = x; }
        else if (h < 240) { r = 0; g = x; b = c; }
        else if (h < 300) { r = x; g = 0; b = c; }
        else { r = c; g = 0; b = x; }
        return new Color((int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));
    }

    /// <summary>Gets the closest xterm-256 color index for this color.</summary>
    /// <returns>Index between 0 and 255.</returns>
    public int ToXterm256Index()
    {
        if (R == G && G == B)
        {
            if (R == 0) return 16;
            if (R == 255) return 231;
            int gray = (int)Math.Round((R / 255.0) * 23);
            return 232 + gray;
        }
        int r = (int)Math.Round(R / 51.0);
        int g = (int)Math.Round(G / 51.0);
        int b = (int)Math.Round(B / 51.0);
        return 16 + (r * 36) + (g * 6) + b;
    }
}
