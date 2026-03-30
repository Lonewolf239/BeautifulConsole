using System;
using System.Threading;
using BeautifulConsole.Core;
using BeautifulConsole.Models;

namespace BeautifulConsole;

public static partial class BConsole
{
    private static Mutex? Mutex;
    private static bool MutexOwned;

    static BConsole() => AppDomain.CurrentDomain.ProcessExit += (sender, e) => ReleaseMutex();

    /// <summary>Sets up console settings based on the provided options.</summary>
    /// <param name="options">The console options to apply.</param>
    /// <exception cref="ArgumentNullException">Thrown when options is null.</exception>
    public static void SetupConsoleSettings(BOptions? options) => ConsoleCore.SetupConsoleSettings(options);

    /// <summary>
    /// Sets a mutex with the specified name for single-instance application.
    /// </summary>
    /// <param name="mutexName">The name of the mutex.</param>
    /// <returns>True if the mutex was acquired; false if another instance is already running.</returns>
    public static bool SetMutex(string? mutexName)
    {
        if (string.IsNullOrEmpty(mutexName)) return false;
        try
        {
            Mutex = new Mutex(true, @"Global\" + mutexName, out bool createdNew);
            MutexOwned = createdNew;
            return createdNew;
        }
        catch (UnauthorizedAccessException) { return false; }
    }

    /// <summary>Releases the mutex if it was acquired.</summary>
    public static void ReleaseMutex()
    {
        try
        {
            if (Mutex is not null && MutexOwned)
            {
                Mutex.ReleaseMutex();
                MutexOwned = false;
            }
            Mutex?.Dispose();
            Mutex = null;
        }
        catch (ApplicationException) { }
        catch (ObjectDisposedException) { }
    }
}
