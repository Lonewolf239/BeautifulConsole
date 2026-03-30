#if WINDOWS
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace BeautifulConsole.Clipboard;

public static partial class Clipboard
{
    private const uint GMEM_MOVEABLE = 0x0002;
    private const uint CF_UNICODETEXT = 13;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool OpenClipboard(IntPtr hWndNewOwner);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool CloseClipboard();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool EmptyClipboard();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool IsClipboardFormatAvailable(uint format);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GlobalAlloc(uint uFlags, UIntPtr dwBytes);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GlobalLock(IntPtr hMem);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GlobalUnlock(IntPtr hMem);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GlobalFree(IntPtr hMem);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr GetClipboardData(uint uFormat);

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
            catch (Exception ex) when (ex is InvalidOperationException || ex is OutOfMemoryException)
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

    private static void ExecuteSetText(string text)
    {
        if (!OpenClipboard(IntPtr.Zero))
        {
            int error = Marshal.GetLastWin32Error();
            throw new InvalidOperationException($"Unable to open clipboard. Win32 error: {error}");
        }
        bool success = false;
        try
        {
            if (!EmptyClipboard())
            {
                int error = Marshal.GetLastWin32Error();
                throw new InvalidOperationException($"Unable to empty clipboard. Win32 error: {error}");
            }
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            int dataSize = bytes.Length + 2;
            IntPtr hGlobal = GlobalAlloc(GMEM_MOVEABLE, (UIntPtr)dataSize);
            if (hGlobal == IntPtr.Zero)
                throw new OutOfMemoryException("Unable to allocate memory for clipboard data.");
            try
            {
                IntPtr locked = GlobalLock(hGlobal);
                if (locked == IntPtr.Zero)
                    throw new InvalidOperationException("Unable to lock memory for clipboard data.");
                try
                {
                    Marshal.Copy(bytes, 0, locked, bytes.Length);
                    Marshal.WriteInt16(locked, bytes.Length, 0);
                }
                finally { GlobalUnlock(locked); }
                if (SetClipboardData(CF_UNICODETEXT, hGlobal) == IntPtr.Zero)
                {
                    int error = Marshal.GetLastWin32Error();
                    throw new InvalidOperationException($"Unable to set clipboard data. Win32 error: {error}");
                }
                hGlobal = IntPtr.Zero;
                success = true;
            }
            finally { if (hGlobal != IntPtr.Zero) GlobalFree(hGlobal); }
        }
        finally
        {
            CloseClipboard();
            if (!success)
            {
                try
                {
                    OpenClipboard(IntPtr.Zero);
                    EmptyClipboard();
                }
                catch { }
                finally { CloseClipboard(); }
            }
        }
    }

    private static string? GetTextInternal()
    {
        if (!IsTextAvailable()) return null;
        if (!OpenClipboard(IntPtr.Zero)) return null;
        try
        {
            IntPtr handle = GetClipboardData(CF_UNICODETEXT);
            if (handle == IntPtr.Zero) return null;
            IntPtr locked = GlobalLock(handle);
            if (locked == IntPtr.Zero) return null;
            try { return Marshal.PtrToStringUni(locked); }
            finally { GlobalUnlock(locked); }
        }
        catch { return null; }
        finally { CloseClipboard(); }
    }

    private static bool IsTextAvailableInternal()
    {
        if (!OpenClipboard(IntPtr.Zero)) return false;
        try { return IsClipboardFormatAvailable(CF_UNICODETEXT); }
        catch { return false; }
        finally { CloseClipboard(); }
    }

    private static bool ClearInternal()
    {
        if (!OpenClipboard(IntPtr.Zero)) return false;
        try { return EmptyClipboard(); }
        catch { return false; }
        finally { CloseClipboard(); }
    }
}
#endif
