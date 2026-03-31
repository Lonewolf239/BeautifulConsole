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

    internal static bool SupportsAnsi
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

    internal static bool SupportsTrueColor
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

    internal static bool Supports256Colors
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

    internal static bool SupportsMouse
    {
        get
        {
            if (!SupportsAnsi) return false;
            if (_SupportsMouse.HasValue) return _SupportsMouse.Value;
            bool supported = false;
            string? termProgram = Environment.GetEnvironmentVariable("TERM_PROGRAM");
            string? term = Environment.GetEnvironmentVariable("TERM");
            string? wtSession = Environment.GetEnvironmentVariable("WT_SESSION");
            string? vteVersion = Environment.GetEnvironmentVariable("VTE_VERSION");
            string? alacritty = Environment.GetEnvironmentVariable("ALACRITTY_LOG");
            string? konsole = Environment.GetEnvironmentVariable("KONSOLE_VERSION");
            string? gnomeTerminal = Environment.GetEnvironmentVariable("GNOME_TERMINAL_SCREEN");
            string? termVersion = Environment.GetEnvironmentVariable("TERM_VERSION");
            if (!string.IsNullOrEmpty(wtSession) ||
                    termProgram == "vscode" ||
                    SupportsKitty ||
                    SupportsITerm2 ||
                    !string.IsNullOrEmpty(alacritty) ||
                    !string.IsNullOrEmpty(konsole) ||
                    !string.IsNullOrEmpty(gnomeTerminal) ||
                    termProgram == "Hyper" ||
                    termProgram == "Tabby" ||
                    termProgram == "WezTerm" ||
                    term?.Contains("xterm") == true && termVersion?.Contains("mouse") == true ||
                    vteVersion != null && int.TryParse(vteVersion, out int vte) && vte >= 500)
                supported = true;
            if (!supported && Supports256Colors)
                supported = true;
            _SupportsMouse = supported;
            return supported;
        }
    }

    internal static bool SupportsKitty => _SupportsKitty ??= Environment.GetEnvironmentVariable("KITTY_WINDOW_ID") != null;

    internal static bool SupportsITerm2 => _SupportsITerm2 ??= Environment.GetEnvironmentVariable("ITERM_SESSION_ID") != null;

    internal static bool IsWindowsVtSupported
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
                if ((mode & ENABLE_VIRTUAL_TERMINAL_PROCESSING) != 0) _IsWindowsVtSupported = true;
                else
                {
                    uint newMode = mode | ENABLE_VIRTUAL_TERMINAL_PROCESSING;
                    _IsWindowsVtSupported = NativeMethods.SetConsoleMode(handle, newMode);
                }
            }
            catch { _IsWindowsVtSupported = false; }
#else
            _IsWindowsVtSupported = false;
#endif
            return _IsWindowsVtSupported.Value;
        }
    }
}
