using System;
using System.Runtime.InteropServices;

namespace BeautifulConsole.Core;

internal static class TerminalCapabilities
{
    private static bool? _SupportsAnsi;
    private static bool? _SupportsTrueColor;
    private static bool? _Supports256Colors;
    private static bool? _SupportsMouse;
    private static bool? _SupportsKitty;
    private static bool? _SupportsITerm2;
    private static bool? _IsWindowsVtSupported;

    public static bool SupportsAnsi
    {
        get
        {
            if (_SupportsAnsi.HasValue) return _SupportsAnsi.Value;
            if (Console.IsOutputRedirected)
            {
                _SupportsAnsi = false;
                return false;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) _SupportsAnsi = IsWindowsVtSupported;
            else _SupportsAnsi = true;
            return _SupportsAnsi.Value;
        }
    }

    public static bool SupportsTrueColor
    {
        get
        {
            if (!SupportsAnsi) return false;
            if (_SupportsTrueColor.HasValue) return _SupportsTrueColor.Value;
            var term = Environment.GetEnvironmentVariable("TERM");
            var colorTerm = Environment.GetEnvironmentVariable("COLORTERM");
            bool supports = colorTerm == "truecolor" ||
                            colorTerm == "24bit" ||
                            term?.Contains("truecolor") == true ||
                            term?.Contains("24bit") == true ||
                            (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                             !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WT_SESSION")));
            _SupportsTrueColor = supports;
            return supports;
        }
    }

    public static bool Supports256Colors
    {
        get
        {
            if (!SupportsAnsi) return false;
            if (_Supports256Colors.HasValue) return _Supports256Colors.Value;
            var term = Environment.GetEnvironmentVariable("TERM");
            bool supports = term?.Contains("256color") == true || (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && SupportsTrueColor);
            _Supports256Colors = supports;
            return supports;
        }
    }

    public static bool SupportsMouse
    {
        get
        {
            if (!SupportsAnsi) return false;
            if (_SupportsMouse.HasValue) return _SupportsMouse.Value;
            _SupportsMouse = Supports256Colors || Environment.GetEnvironmentVariable("TERM_PROGRAM") == "vscode";
            return _SupportsMouse.Value;
        }
    }

    public static bool SupportsKitty => _SupportsKitty ??= Environment.GetEnvironmentVariable("KITTY_WINDOW_ID") != null;

    public static bool SupportsITerm2 => _SupportsITerm2 ??= Environment.GetEnvironmentVariable("ITERM_SESSION_ID") != null;

    private static bool IsWindowsVtSupported
    {
        get
        {
            if (_IsWindowsVtSupported.HasValue) return _IsWindowsVtSupported.Value;
#if WINDOWS
            try
            {

                var handle = NativeMethods.GetStdHandle(NativeMethods.STD_OUTPUT_HANDLE);
                if (handle == IntPtr.Zero) return false;
                if (!NativeMethods.GetConsoleMode(handle, out uint mode)) return false;
                const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
                if ((mode & ENABLE_VIRTUAL_TERMINAL_PROCESSING) != 0) _isWindowsVtSupported = true;
                else
                {
                    uint newMode = mode | ENABLE_VIRTUAL_TERMINAL_PROCESSING;
                    _isWindowsVtSupported = NativeMethods.SetConsoleMode(handle, newMode);
                }
            }
            catch { _isWindowsVtSupported = false; }
#else
            _IsWindowsVtSupported = false;
#endif
            return _IsWindowsVtSupported.Value;
        }
    }
}
