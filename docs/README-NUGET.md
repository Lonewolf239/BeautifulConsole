# BeautifulConsole

A powerful .NET library for building beautiful console applications with **true‑color support**, **cross‑platform clipboard**, **advanced window customization**, and a clean, black‑box API.

```bash
dotnet add package BeautifulConsole
```

- **Package:** [nuget.org/packages/BeautifulConsole](https://www.nuget.org/packages/BeautifulConsole)
- **Version:** 0.2 | **.NET 6+**
- **Developer:** [Lonewolf239](https://github.com/Lonewolf239)

---

## Features

| | Feature | Details |
|---|---------|---------|
| 🎨 | **True color (24‑bit) output** | ANSI escape sequences for full RGB colors. Falls back to nearest `ConsoleColor` in legacy terminals. |
| 🌈 | **Gradient text** | Smooth color transitions using `WriteGradient`. |
| ⌨️ | **Rich input with prompts** | `Read`, `ReadLine`, `ReadKey` with colored `Message` objects. |
| 🖥️ | **Console window customization** | Set size, title, resizable, maximizable, center window, disable close button, hide title bar (Windows only). |
| 📋 | **Cross‑platform clipboard** | Copy/paste text on Windows (WinAPI), macOS (`pbcopy`/`pbpaste`), and Linux (`wl-copy`/`xclip`/`xsel`). |
| 🐭 | **Mouse support (experimental)** | Enable/disable mouse event reporting with `EnableMouse` / `DisableMouse`. |
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
using BeautifulConsole.Models; // For Message class

BConsole.WriteLine(new Message("Hello, BeautifulConsole!", Color.NeonGreen));
BConsole.WriteLine(new Message("This is red on cyan", Color.Red, Color.Cyan));
```

### Read input with a prompt

```csharp
string name = BConsole.ReadLine(new Message("What is your name? ", Color.Yellow));
BConsole.WriteLine($"Hello, {name}!", Color.Yellow);
```

### Gradient text

```csharp
BConsole.WriteGradient("This text flows from red to blue", Color.Red, Color.Blue);
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
BeautifulConsole.Clipboard.Clipboard.SetText("Hello from BeautifulConsole!");
string text = BeautifulConsole.Clipboard.Clipboard.GetText();
if (BeautifulConsole.Clipboard.Clipboard.IsTextAvailable())
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

All `Write` and `WriteLine` methods accept a `Message` object that can contain text and optional foreground/background colors:

- `Write(Message? message)`
- `WriteLine()`
- `WriteLine(Message? message)`

**Example:**

```csharp
BConsole.WriteLine(new Message("This is green text", Color.Green));
BConsole.WriteLine(new Message("White on blue", Color.White, Color.Blue));
```

The `AutoResetColor` property (default `true`) automatically returns to the default colors after each output. Set it to `false` if you want colors to persist:

```csharp
BConsole.AutoResetColor = false;
BConsole.Write(new Message("This stays ", Color.Red));
BConsole.WriteLine(new Message("red", Color.Red));
BConsole.ResetColor();   // manual reset
```

Default colors can be changed:

```csharp
BConsole.DefaultForegroundColor = Color.LightGray;
BConsole.DefaultBackgroundColor = Color.DarkBlue;
```

### Gradient Text

The `WriteGradient` method writes text with a smooth color transition:

```csharp
WriteGradient(string text, Color startColor, Color endColor, bool resetAfter = true);
```

**Example:**

```csharp
BConsole.WriteGradient("Rainbow effect", Color.Red, Color.Violet);
```

### Input with Prompts

All input methods have overloads that display a colored `Message` before reading:

- `Read(bool newLine)`
- `Read(Message? message, bool newLine)`
- `ReadLine(bool newLine)`
- `ReadLine(Message? message, bool newLine)`
- `ReadKey(bool intercept, bool newLine)`
- `ReadKey(bool intercept, Message? message, bool newLine)`

**Example:**

```csharp
var prompt = new Message("Enter your name: ", Color.Cyan);
string name = BConsole.ReadLine(prompt);
BConsole.WriteLine($"Hello, {name}!");
```

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

Additionally, many console properties are now directly accessible via `BConsole`:

- `CursorVisible`
- `WindowWidth`, `WindowHeight`
- `BufferWidth`, `BufferHeight`
- `Title`
- `TreatControlCAsInput`
- `CursorSize`
- `NumberLock`, `CapsLock` (Windows only)
- `LargestWindowWidth`, `LargestWindowHeight`
- `IsInputRedirected`, `IsOutputRedirected`, `IsErrorRedirected`
- `InputEncoding`, `OutputEncoding`

### Mouse Support (Experimental)

You can enable or disable mouse event reporting in terminals that support it:

```csharp
BConsole.EnableMouse();  // Start receiving mouse events
BConsole.DisableMouse(); // Stop receiving mouse events
```

**Note:** Mouse event handling is not yet fully implemented – only the enabling/disabling of reporting is supported. Future versions will add event reading and processing.

### Clipboard Operations

The `BeautifulConsole.Clipboard.Clipboard` static class provides a simple clipboard API:

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
BConsole.WriteLine(new Message("Custom color", custom));
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
- `Write(Message? message)`
- `WriteLine()`
- `WriteLine(Message? message)`
- `WriteGradient(string text, Color startColor, Color endColor, bool resetAfter = true)`
- `Clear()`
- `ResetColor()`

**Input**
- `Read(bool newLine = false)`
- `Read(Message? message, bool newLine = false)`
- `ReadLine(bool newLine = false)`
- `ReadLine(Message? message, bool newLine = false)`
- `ReadKey(bool intercept = false, bool newLine = false)`
- `ReadKey(bool intercept, Message? message, bool newLine = false)`

**Properties**
- `bool AutoResetColor { get; set; }`
- `Color DefaultForegroundColor { get; set; }`
- `Color DefaultBackgroundColor { get; set; }`
- `bool CursorVisible { get; set; }`
- `int WindowWidth { get; set; }` (Windows only for setter)
- `int WindowHeight { get; set; }` (Windows only for setter)
- `int BufferWidth { get; set; }` (Windows only for setter)
- `int BufferHeight { get; set; }` (Windows only for setter)
- `string Title { get; set; }`
- `bool TreatControlCAsInput { get; set; }`
- `int CursorSize { get; set; }`
- `bool NumberLock { get; }` (Windows only)
- `bool CapsLock { get; }` (Windows only)
- `int LargestWindowWidth { get; }`
- `int LargestWindowHeight { get; }`
- `bool IsInputRedirected { get; }`
- `bool IsOutputRedirected { get; }`
- `bool IsErrorRedirected { get; }`
- `Encoding InputEncoding { get; set; }`
- `Encoding OutputEncoding { get; set; }`

**Setup & Single Instance**
- `void SetupConsoleSettings(BOptions? options)`
- `bool SetMutex(string? mutexName)`
- `void ReleaseMutex()`

**Mouse**
- `void EnableMouse()`
- `void DisableMouse()`

### `BOptions` (class)

All properties are nullable or have sensible defaults. See the [Console Window Configuration](#console-window-configuration) section for a complete list.

### `Color` (class)

- Constructors: `Color(int r, int g, int b)`, `Color()` (empty color)
- Over 150 static predefined colors.
- Properties: `R`, `G`, `B` (bytes).
- Methods: `Blend`, `Gradient`, `ToHsl`, `FromHsl`, `ToHsv`, `FromHsv`, `ToXterm256Index`.

### `Message` (class)

- `Message(string? text, Color? foreground = null, Color? background = null)`
- `Message(char text, Color? foreground = null, Color? background = null)`
- Properties: `Text`, `ForegroundColor`, `BackgroundColor`.

### `Clipboard` (static class, accessible via `BeautifulConsole.Clipboard.Clipboard`)

- `void SetText(string? text)`
- `bool TrySetText(string? text)`
- `string? GetText()`
- `bool IsTextAvailable()`
- `bool Clear()`

---

## Philosophy

**Black Box Design** – all internal logic is hidden behind the simple, static `BConsole` API. You interact with clean methods and properties without worrying about ANSI escape sequences, platform differences, or internal state management. BeautifulConsole manages everything for you.
