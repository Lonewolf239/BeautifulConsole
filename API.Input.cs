using System;
using BeautifulConsole.Core;
using BeautifulConsole.Models;

namespace BeautifulConsole;

public static partial class BConsole
{
    public static void Read() => BCCore.Read();

    public static string? ReadLine() => BCCore.ReadLine(null, Color.White);

    public static string? ReadLine(string? message) => BCCore.ReadLine(message, Color.White);

    public static string? ReadLine(string? message, Color color) => BCCore.ReadLine(message, color);

    public static ConsoleKeyInfo ReadKey() => BCCore.ReadKey(false, null, Color.White);

    public static ConsoleKeyInfo ReadKey(bool intercept) => BCCore.ReadKey(intercept, null, Color.White);

    public static ConsoleKeyInfo ReadKey(bool intercept, string? message) => BCCore.ReadKey(intercept, message, Color.White);

    public static ConsoleKeyInfo ReadKey(bool intercept, string? message, Color color) => BCCore.ReadKey(intercept, message, color);
}
