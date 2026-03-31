using BeautifulConsole;
using BeautifulConsole.Clipboard;
using BeautifulConsole.Models;

class Program
{
    static void Main()
    {
        BConsole.SetupConsoleSettings(new BOptions
        {
            Title = "BeautifulConsole v0.2 Demo",
            Width = 100,
            Height = 30,
            Resizable = false,
            CenterWindow = true,
            CursorVisible = true,
            CursorSize = 100,
            DisableCloseButton = false
        });

        BConsole.WriteLine(new Message("=== BeautifulConsole Demo ===", Color.Cyan));
        BConsole.WriteLine();

        BConsole.WriteLine(new Message("1. Basic colored output:", Color.Yellow));
        BConsole.Write(new Message("  - Default foreground", Color.White));
        BConsole.WriteLine(new Message(" (AutoResetColor = true)", Color.Gray));
        BConsole.Write(new Message("  - Red text ", Color.Red));
        BConsole.Write(new Message("on green background", background: Color.Green));
        BConsole.WriteLine();

        BConsole.WriteLine(new Message("2. Gradient effect:", Color.Yellow));
        BConsole.WriteGradient("  BeautifulConsole", Color.Red, Color.Blue);
        BConsole.WriteGradient(" makes your console ", Color.Green, Color.Yellow);
        BConsole.WriteGradient("beautiful!", Color.Magenta, Color.Cyan);
        BConsole.WriteLine();
        BConsole.WriteLine();

        BConsole.WriteLine(new Message("3. Input with prompt:", Color.Yellow));
        string? name = BConsole.ReadLine(new Message("  Enter your name: ", Color.PastelGreen));
        BConsole.WriteLine(new Message($"  Hello, {name}!", Color.PastelBlue));

        BConsole.WriteLine(new Message("4. Clipboard operations:", Color.Yellow));
        if (!string.IsNullOrEmpty(name))
        {
            Clipboard.SetText(name);
            BConsole.WriteLine(new Message($"  Copied '{name}' to clipboard.", Color.PastelGreen));

            string? copied = Clipboard.GetText();
            BConsole.WriteLine(new Message($"  Retrieved from clipboard: {copied}", Color.PastelBlue));

            if (Clipboard.Clear())
                BConsole.WriteLine(new Message("  Clipboard cleared.", Color.Gray));
        }

        BConsole.WriteLine(new Message("5. Key input demo:", Color.Yellow));
        BConsole.WriteLine(new Message("  Press any key (intercept = true) ...", Color.PastelYellow));
        ConsoleKeyInfo key = BConsole.ReadKey(true);
        BConsole.WriteLine(new Message($"\n  You pressed: {key.Key} (Modifiers: {key.Modifiers})", Color.PastelOrange));

        BConsole.WriteLine(new Message("  Press any key (intercept = false, shows on screen) ...", Color.PastelYellow));
        key = BConsole.ReadKey();
        BConsole.WriteLine(new Message($"\n  You pressed: {key.Key}", Color.PastelOrange));

        BConsole.WriteLine(new Message("6. Console properties:", Color.Yellow));
        BConsole.WriteLine(new Message($"  Window size: {BConsole.WindowWidth} x {BConsole.WindowHeight}"));
        BConsole.WriteLine(new Message($"  Buffer size: {BConsole.BufferWidth} x {BConsole.BufferHeight}"));
        BConsole.WriteLine(new Message($"  Largest possible window: {BConsole.LargestWindowWidth} x {BConsole.LargestWindowHeight}"));
        BConsole.WriteLine(new Message($"  Input redirected: {BConsole.IsInputRedirected}"));
        BConsole.WriteLine(new Message($"  Output redirected: {BConsole.IsOutputRedirected}"));

        BConsole.WriteLine(new Message("7. AutoResetColor = false:", Color.Yellow));
        bool oldAuto = BConsole.AutoResetColor;
        BConsole.AutoResetColor = false;
        BConsole.Write(new Message("  This text is red", Color.Red));
        BConsole.Write(new Message(" and this continues red"));
        BConsole.Write(new Message(" but manually reset: "));
        BConsole.ResetColor();
        BConsole.WriteLine(new Message("back to default."));
        BConsole.AutoResetColor = oldAuto;

        BConsole.WriteLine(new Message("8. Gradient on your input:", Color.Yellow));
        string? phrase = BConsole.ReadLine(new Message("  Enter something for gradient: ", Color.PastelPurple));
        if (!string.IsNullOrEmpty(phrase))
        {
            BConsole.Write(new("  "));
            BConsole.WriteGradient(phrase, Color.Red, Color.Magenta);
            BConsole.WriteLine();
        }

        BConsole.WriteLine(new Message("\nDemo completed. Press any key to exit...", Color.Cyan));
        BConsole.ReadKey(true);
    }
}
