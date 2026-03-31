[![EN](https://img.shields.io/badge/CHANGELOG-EN-2D2D2D?style=for-the-badge&logo=github&logoColor=FFFFFF)](./CHANGELOG.md)
[![RU](https://img.shields.io/badge/CHANGELOG-RU-2D2D2D?style=for-the-badge&logo=google-translate&logoColor=FFFFFF)](./CHANGELOG-RU.md)

## Changelog · BeautifulConsole

<details open>
<summary><strong>0.2</strong> — March 31, 2026</summary>

#### List of changes

- **Terminal capability detection**
  - Automatic detection of ANSI support, truecolor (24‑bit), 256‑color palette, mouse events, Kitty and iTerm2 protocols.
  - ANSI sequences are automatically disabled when output is redirected.
- **Color enhancements**
  - New `Color` methods: blending, gradients, HSL/HSV conversion, conversion to xterm‑256 color index.
  - Added `WriteGradient` method for smooth gradient output.
  - Extended predefined colors.
- **Performance optimizations**
  - ANSI sequences are cached for repeated use.
  - Thread‑safe output via `lock` synchronization.
  - Reduced number of `Console.Write` calls in gradient output.
- **Input improvements**
  - All `Read`, `ReadLine` and `ReadKey` methods now accept an optional `newLine` parameter (default `false`) to control whether a blank line is printed before the prompt.
- **Mouse foundation**
  - `EnableMouse()` and `DisableMouse()` methods to activate mouse tracking (full event handling will be added in version 0.3).
- **API additions**
  - `Color.CreateClamped()` for safe color creation with automatic clamping.
  - `WriteGradient()` for gradient text output.

</details>

<details>
<summary><strong>0.1.2</strong> — March 30, 2026</summary>

#### List of changes

- Expanded console control capabilities via the static `BConsole` class:
  - `WindowWidth` / `WindowHeight` – getting/setting the console window size.
  - `BufferWidth` / `BufferHeight` – managing the screen buffer size.
  - `Title` – getting/setting the window title.
  - `TreatControlCAsInput` – managing Ctrl+C handling.
  - `CursorSize` – changing the cursor size (1–100%).
  - `NumberLock` / `CapsLock` – the state of the toggle keys.
  - `LargestWindowWidth` / `LargestWindowHeight` – the maximum possible window size.
  - `IsInputRedirected` / `IsOutputRedirected` / `IsErrorRedirected` – checking for stream redirection.
  - `InputEncoding` / `OutputEncoding` – input/output encoding management.

</details>

<details>
<summary><strong>0.1.1</strong> — March 30, 2026</summary>

#### List of changes

- **Fixed clipboard functionality on Linux and macOS**
Previously, checking for the presence of utilities (xclip, xsel, wl-clipboard, pbpaste) always returned false due to an incorrect execution of command -v. Now, using /bin/sh -c "command -v <command>" with a fallback to which ensures that installed tools are correctly detected.
- **Increased timeout for clipboard commands**
The timeout for waiting for processes to complete has been increased from 3 to 10 seconds, allowing you to copy large amounts of text without false positives.

</details>

<details>
<summary><strong>0.1</strong> — March 30, 2026</summary>

#### List of changes

- First release

</details>
