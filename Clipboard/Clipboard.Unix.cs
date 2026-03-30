#if !WINDOWS
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace BeautifulConsole.Clipboard;

public static partial class Clipboard
{
    private static void SetTextInternal(string? text)
    {
        if (text is null) throw new ArgumentNullException(nameof(text));
        if (text.Length == 0) throw new ArgumentException("Text cannot be empty.", nameof(text));
        int attempts = 0;
        Exception? lastException = null;
        while (attempts < MaxRetryAttempts)
        {
            try
            {
                ExecuteSetText(text);
                return;
            }
            catch (Exception ex) when (ex is InvalidOperationException)
            {
                lastException = ex;
                attempts++;
                if (attempts < MaxRetryAttempts) Thread.Sleep(RetryDelayMs);
            }
        }
        throw lastException ?? new InvalidOperationException("Failed to set clipboard text after multiple attempts.");
    }

    private static bool TrySetTextInternal(string? text)
    {
        try
        {
            SetText(text);
            return true;
        }
        catch { return false; }
    }

    private static string? GetTextInternal()
    {
        if (!IsTextAvailable()) return null;
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return RunProcessGetOutput("pbpaste");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (IsCommandAvailable("wl-paste")) return RunProcessGetOutput("wl-paste");
                if (IsCommandAvailable("xclip")) return RunProcessGetOutput("xclip", "-selection", "clipboard", "-o");
                if (IsCommandAvailable("xsel")) return RunProcessGetOutput("xsel", "--clipboard", "--output");
            }
            return null;
        }
        catch { return null; }
    }

    private static bool IsTextAvailableInternal()
    {
        try
        {
            string? text = GetTextInternal();
            return text is not null;
        }
        catch { return false; }
    }

    private static bool ClearInternal()
    {
        try
        {
            SetText(string.Empty);
            return true;
        }
        catch { return false; }
    }

    private static void ExecuteSetText(string text)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            RunProcess("pbcopy", text, true);
            return;
        }
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            if (IsCommandAvailable("wl-copy"))
            {
                RunProcess("wl-copy", text, true);
                return;
            }
            if (IsCommandAvailable("xclip"))
            {
                RunProcess("xclip", text, true, "-selection", "clipboard");
                return;
            }
            if (IsCommandAvailable("xsel"))
            {
                RunProcess("xsel", text, true, "--clipboard", "--input");
                return;
            }
            throw new InvalidOperationException("No clipboard tool found. Install xclip, xsel, or wl-clipboard.");
        }
        throw new PlatformNotSupportedException("Clipboard not supported on this platform.");
    }

    private static void RunProcess(string command, string input, bool throwOnError, params string[] args)
    {
        using var process = new Process();
        process.StartInfo.FileName = command;
        foreach (var arg in args) process.StartInfo.ArgumentList.Add(arg);
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        try
        {
            process.Start();
            using (var stdin = process.StandardInput)
            {
                stdin.Write(input);
                stdin.Close();
            }
            if (!process.WaitForExit(3000))
            {
                process.Kill();
                throw new InvalidOperationException($"Command '{command}' timed out.");
            }
            if (throwOnError && process.ExitCode != 0)
            {
                string error = process.StandardError.ReadToEnd();
                throw new InvalidOperationException($"Command '{command}' failed with exit code {process.ExitCode}: {error}");
            }
        }
        catch when (!throwOnError) { }
    }

    private static string? RunProcessGetOutput(string command, params string[] args)
    {
        using var process = new Process();
        process.StartInfo.FileName = command;
        foreach (var arg in args) process.StartInfo.ArgumentList.Add(arg);
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        try
        {
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return process.ExitCode == 0 ? output : null;
        }
        catch { return null; }
    }

    private static bool IsCommandAvailable(string command)
    {
        try
        {
            using var process = new Process();
            process.StartInfo.FileName = "command";
            process.StartInfo.Arguments = $"-v {command}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.WaitForExit();
            return process.ExitCode == 0;
        }
        catch
        {
            try
            {
                using var process = new Process();
                process.StartInfo.FileName = "which";
                process.StartInfo.Arguments = command;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();
                process.WaitForExit();
                return process.ExitCode == 0;
            }
            catch { return false; }
        }
    }
}
#endif
