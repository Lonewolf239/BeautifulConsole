using System;
using System.Text;
using BeautifulConsole.Models;

namespace BeautifulConsole.Core;

internal static partial class ConsoleCore
{
    internal static void SetupConsoleSettings(BOptions? options)
    {
        if (options is null) throw new ArgumentNullException(nameof(options));
        if (!string.IsNullOrEmpty(options.Title)) Console.Title = options.Title;
#if WINDOWS
        if (options.Width.HasValue && options.Height.HasValue)
        {
            try
            {
                int maxWidth = Console.LargestWindowWidth;
                int maxHeight = Console.LargestWindowHeight;
                int width = Math.Min(options.Width.Value, maxWidth);
                int height = Math.Min(options.Height.Value, maxHeight);
                Console.SetBufferSize(width, height);
                Console.SetWindowSize(width, height);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new InvalidOperationException(
                    $"Failed to set console size to {options.Width}x{options.Height}. " +
                    "Ensure the size is within the allowed range for your system.", ex);
            }
        }
#endif
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        if (options.CursorVisible.HasValue) Console.CursorVisible = options.CursorVisible.Value;
#if WINDOWS
        Console.CursorSize = options.CursorSize;
        ApplyWindowsSpecificSettings(options);
#endif
    }

#if WINDOWS
    private static void ApplyWindowsSpecificSettings(BOptions options)
    {
        var consoleWindow = NativeMethods.GetConsoleWindow();
        if (consoleWindow == IntPtr.Zero) return;
        if (options.CenterWindow.GetValueOrDefault()) CenterConsoleWindow(consoleWindow);
        int style = NativeMethods.GetWindowLong(consoleWindow, NativeMethods.GWL_STYLE);
        int originalStyle = style;
        if (options.Resizable.HasValue && !options.Resizable.Value) style &= ~NativeMethods.WS_SIZEBOX;
        if (options.Maximizable.HasValue && !options.Maximizable.Value) style &= ~NativeMethods.WS_MAXIMIZEBOX;
        if (options.Minimizable.HasValue && !options.Minimizable.Value) style &= ~NativeMethods.WS_MINIMIZEBOX;
        if (options.HideTitleBar.GetValueOrDefault()) style &= ~NativeMethods.WS_CAPTION;
        if (style != originalStyle)
        {
            NativeMethods.SetWindowLong(consoleWindow, NativeMethods.GWL_STYLE, style);
            NativeMethods.SetWindowPos(consoleWindow, IntPtr.Zero, 0, 0, 0, 0,
                NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOZORDER | NativeMethods.SWP_FRAMECHANGED);
        }
        if (options.DisableCloseButton.GetValueOrDefault())
        {
            var systemMenu = NativeMethods.GetSystemMenu(consoleWindow, false);
            if (systemMenu != IntPtr.Zero)
                NativeMethods.EnableMenuItem(systemMenu, (uint)NativeMethods.SC_CLOSE, NativeMethods.MF_BYCOMMAND | NativeMethods.MF_GRAYED);
        }
        ConfigureConsoleInput(options);
    }

    private static void CenterConsoleWindow(IntPtr consoleWindow)
    {
        int screenWidth = NativeMethods.GetSystemMetrics(NativeMethods.SM_CXSCREEN);
        int screenHeight = NativeMethods.GetSystemMetrics(NativeMethods.SM_CYSCREEN);
        if (NativeMethods.GetWindowRect(consoleWindow, out NativeMethods.RECT rect))
        {
            int consoleWidthPixels = rect.Right - rect.Left;
            int consoleHeightPixels = rect.Bottom - rect.Top;
            int posX = Math.Max(0, (screenWidth - consoleWidthPixels) / 2);
            int posY = Math.Max(0, (screenHeight - consoleHeightPixels) / 2);
            NativeMethods.MoveWindow(consoleWindow, posX, posY, consoleWidthPixels, consoleHeightPixels, true);
        }
    }

    private static void ConfigureConsoleInput(BOptions options)
    {
        var consoleHandle = NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE);
        if (consoleHandle == IntPtr.Zero) return;
        if (!NativeMethods.GetConsoleMode(consoleHandle, out uint consoleMode)) return;
        uint originalMode = consoleMode;
        if (options.DisableQuickEdit.GetValueOrDefault()) consoleMode &= ~(NativeMethods.ENABLE_QUICK_EDIT_MODE | NativeMethods.ENABLE_EXTENDED_FLAGS);
        if (options.EchoInput.HasValue && !options.EchoInput.Value) consoleMode &= ~NativeMethods.ENABLE_ECHO_INPUT;
        if (options.ProcessCtrlC.HasValue && !options.ProcessCtrlC.Value) consoleMode &= ~NativeMethods.ENABLE_PROCESSED_INPUT;
        if (options.EnableInputHistory.HasValue && !options.EnableInputHistory.Value) consoleMode &= ~NativeMethods.ENABLE_LINE_INPUT;
        if (consoleMode != originalMode) NativeMethods.SetConsoleMode(consoleHandle, consoleMode);
    }
#endif
}
