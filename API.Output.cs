using BeautifulConsole.Core;
using BeautifulConsole.Models;

namespace BeautifulConsole;

/// <summary>
/// 
/// <br/>
/// Developer: <a href="https://github.com/Lonewolf239">Lonewolf239</a>
/// <br/>
/// <b>Target Frameworks: .NET 6+</b>
/// <br/>
/// <b>Version: 0.1</b>
/// <br/>
/// <b>Black Box Philosophy:</b> This class follows a strict "black box" design principle - users interact only through the public API without needing to understand internal implementation details. Input goes in, processed output comes out, internals remain hidden and abstracted.
/// </summary>
public static partial class BConsole
{
    public static void Clear() => BCCore.Clear();

    public static void Write(string? line) => BCCore.Write(line, Color.White);

    public static void Write(string? line, Color color) => BCCore.Write(line, color);

    public static void WriteLine() => BCCore.WriteLine(null, Color.White);

    public static void WriteLine(string? line) => BCCore.WriteLine(line, Color.White);

    public static void WriteLine(string? line, Color color) => BCCore.WriteLine(line, color);
}
