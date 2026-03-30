# BeautifulConsole

A powerful .NET library for building beautiful console applications with **true‑color support**, **cross‑platform clipboard**, **advanced window customization**, and a clean, black‑box API.

```bash
dotnet add package BeautifulConsole
```

- **Package:** [nuget.org/packages/BeautifulConsole](https://www.nuget.org/packages/BeautifulConsole)
- **Version:** 0.1 | **.NET 6+**
- **Developer:** [Lonewolf239](https://github.com/Lonewolf239)

---

## Features

| | Feature | Details |
|---|---------|---------|
| 🎨 | **True color (24‑bit) output** | ANSI escape sequences for full RGB colors. Falls back to nearest `ConsoleColor` in legacy terminals. |
| ⌨️ | **Rich input with prompts** | `Read`, `ReadLine`, `ReadKey` with colored messages. |
| 🖥️ | **Console window customization** | Set size, title, resizable, maximizable, center window, disable close button, hide title bar (Windows only). |
| 📋 | **Cross‑platform clipboard** | Copy/paste text on Windows (WinAPI), macOS (`pbcopy`/`pbpaste`), and Linux (`wl-copy`/`xclip`/`xsel`). |
| 🔒 | **Single‑instance enforcement** | Mutex‑based detection to allow only one running instance of your app. |
| ⚙️ | **Global color defaults** | Control default foreground/background colors and automatic reset after each write. |
| 🗺️ | **Rich color palette** | Over 150 predefined colors (web, pastel, neon, metallic, etc.) plus custom RGB. |
| 📦 | **Black‑box design** | Everything is accessed through the static `BConsole` class – no internal complexity exposed. |

---

## Installation

```bash
dotnet add package BeautifulConsole
```

---

## Quick Start

### Hello, World! with color

```csharp
using BeautifulConsole;

BConsole.WriteLine("Hello, BeautifulConsole!", Color.NeonGreen);
BConsole.WriteLine("This is red on cyan", Color.Red, Color.Cyan);
```

### Read input with a prompt

```csharp
string name = BConsole.ReadLine("What is your name? ");
BConsole.WriteLine($"Hello, {name}!", Color.Yellow);
```

### Configure the console window (Windows)

```csharp
var options = new BOptions
{
    Title = "My App",
    Width = 100,
    Height = 30,
    CenterWindow = true,
    DisableCloseButton = true,
    CursorSize = 50
};

BConsole.SetupConsoleSettings(options);
```

### Copy text to clipboard

```csharp
BConsole.Clipboard.SetText("Hello from BeautifulConsole!");
string text = BConsole.Clipboard.GetText();
if (BConsole.Clipboard.IsTextAvailable())
    Console.WriteLine($"Clipboard contains: {text}");
```

### Ensure single instance

```csharp
if (!BConsole.SetMutex("MyApp_Unique_Name"))
{
    Console.WriteLine("Another instance is already running.");
    return;
}
// Your app logic...
// When done, call BConsole.ReleaseMutex() or let the finalizer handle it.
```

---

## Detailed Usage

### Colored Output

All `Write` and `WriteLine` methods accept one or two colors:

- `Write(string? line)`, `Write(string? line, Color fg)`, `Write(string? line, Color fg, Color bg)`
- `WriteLine()`, `WriteLine(string? line)`, `WriteLine(string? line, Color fg)`, `WriteLine(string? line, Color fg, Color bg)`

The `AutoResetColor` property (default `true`) automatically returns to the default colors after each output. Set it to `false` if you want colors to persist:

```csharp
BConsole.AutoResetColor = false;
BConsole.Write("This stays ", Color.Red);
BConsole.WriteLine("red", Color.Red);
BConsole.ResetColor();   // manual reset
```

Default colors can be changed:

```csharp
BConsole.DefaultForegroundColor = Color.LightGray;
BConsole.DefaultBackgroundColor = Color.DarkBlue;
```

### Input with Prompts

All input methods have overloads that display a colored message before reading:

- `Read()`, `Read(string? message)`, `Read(string? message, Color fg)`, `Read(string? message, Color fg, Color bg)`
- `ReadLine()`, `ReadLine(string? message)`, `ReadLine(string? message, Color fg)`, `ReadLine(string? message, Color fg, Color bg)`
- `ReadKey(bool intercept)`, `ReadKey(bool intercept, string? message)`, `ReadKey(bool intercept, string? message, Color fg)`, `ReadKey(bool intercept, string? message, Color fg, Color bg)`

### Console Window Configuration

The `BOptions` class provides extensive control over the console window (Windows only for most features; some settings like size and title work cross‑platform).

| Property | Description | Platform |
|----------|-------------|----------|
| `Width`, `Height` | Window size | Windows |
| `Title` | Window title | Cross‑platform |
| `Resizable` | Allow resizing | Windows |
| `Maximizable` | Allow maximizing | Windows |
| `Minimizable` | Allow minimizing | Windows |
| `CenterWindow` | Center on screen | Windows |
| `HideTitleBar` | Hide title bar | Windows |
| `DisableCloseButton` | Disable close button | Windows |
| `DisableQuickEdit` | Disable quick‑edit mode | Windows |
| `EchoInput` | Show typed characters | Windows |
| `ProcessCtrlC` | Enable Ctrl+C handling | Windows |
| `EnableInputHistory` | Enable command history | Windows |
| `CursorVisible` | Show/hide cursor | Cross‑platform |
| `CursorSize` | Cursor size (1–100) | Windows |

### Clipboard Operations

The `BConsole.Clipboard` static class provides a simple clipboard API:

- `void SetText(string? text)`
- `bool TrySetText(string? text)` – returns success status without throwing.
- `string? GetText()`
- `bool IsTextAvailable()`
- `bool Clear()`

**Platform notes:**
- **Windows:** Uses WinAPI (`user32.dll`).
- **macOS:** Uses `pbcopy`/`pbpaste` (must be installed by default).
- **Linux:** Uses `wl-copy` (Wayland) or `xclip`/`xsel` (X11). The library automatically detects available tools.

### Color Utilities

The `Color` class provides over 150 predefined colors. You can also create custom RGB colors:

```csharp
Color custom = new Color(123, 45, 67);
BConsole.WriteLine("Custom color", custom);
```

Predefined colors include:
- Basic: `Color.Red`, `Color.Green`, `Color.Blue`, `Color.White`, `Color.Black`
- Web: `Color.AliceBlue`, `Color.AntiqueWhite`, `Color.Cornsilk`, etc.
- Pastel: `Color.PastelRed`, `Color.PastelGreen`, `Color.PastelBlue`
- Neon: `Color.NeonRed`, `Color.NeonGreen`, `Color.NeonBlue`
- Metallic: `Color.GoldMetallic`, `Color.SilverMetallic`, `Color.Bronze`
- Earth tones: `Color.Earth`, `Color.Clay`, `Color.Sand`, `Color.Moss`

All colors are immutable and thread‑safe.

---

## API Reference

A quick overview of the public API:

### `BConsole` (static class)

**Output**
- `Write(string? line)`, `Write(string? line, Color fg)`, `Write(string? line, Color fg, Color bg)`
- `WriteLine()`, `WriteLine(string? line)`, `WriteLine(string? line, Color fg)`, `WriteLine(string? line, Color fg, Color bg)`
- `Clear()`
- `ResetColor()`

**Input**
- `Read()`, `Read(string? message)`, `Read(string? message, Color fg)`, `Read(string? message, Color fg, Color bg)`
- `ReadLine()`, `ReadLine(string? message)`, `ReadLine(string? message, Color fg)`, `ReadLine(string? message, Color fg, Color bg)`
- `ReadKey(bool intercept)`, `ReadKey(bool intercept, string? message)`, `ReadKey(bool intercept, string? message, Color fg)`, `ReadKey(bool intercept, string? message, Color fg, Color bg)`

**Properties**
- `bool AutoResetColor { get; set; }`
- `Color DefaultForegroundColor { get; set; }`
- `Color DefaultBackgroundColor { get; set; }`

**Setup & Single Instance**
- `void SetupConsoleSettings(BOptions? options)`
- `bool SetMutex(string? mutexName)`
- `void ReleaseMutex()`

### `BOptions` (class)

All properties are nullable or have sensible defaults. See the [Console Window Configuration](#console-window-configuration) section for a complete list.

### `Color` (class)

- Constructors: `Color(int r, int g, int b)`
- Over 150 static predefined colors.
- Properties: `R`, `G`, `B` (bytes).

### `Clipboard` (static class, accessible via `BConsole.Clipboard`)

- `void SetText(string? text)`
- `bool TrySetText(string? text)`
- `string? GetText()`
- `bool IsTextAvailable()`
- `bool Clear()`

---

## Philosophy

**Black Box Design** – all internal logic is hidden behind the simple, static `BConsole` API. You interact with clean methods and properties without worrying about ANSI escape sequences, platform differences, or internal state management. BeautifulConsole manages everything for you.
