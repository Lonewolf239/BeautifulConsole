[![EN](https://img.shields.io/badge/ROADMAP-EN-2D2D2D?style=for-the-badge&logo=github&logoColor=FFFFFF)](./ROADMAP.md)
[![RU](https://img.shields.io/badge/ROADMAP-RU-2D2D2D?style=for-the-badge&logo=google-translate&logoColor=FFFFFF)](./ROADMAP-RU.md)

## Roadmap · BeautifulConsole

### 0.1.x — Foundation (Released)

| Version | Status | Description |
|---------|--------|-------------|
| 0.1.0 | ✅ Released | Color output (TrueColor + fallback), reading lines and characters with colored prompts, cross‑platform clipboard. |
| 0.1.1 | ✅ Released | Improved detection of xclip/xsel/wl‑clipboard/pbpaste on Linux/macOS, increased copy timeout. |
| 0.1.2 | ✅ Released | Extended console management: window/buffer size, title, Ctrl+C handling, cursor size, encodings, NumLock/CapsLock indicators. Settings via `BOptions` (size, window styles, centering, button disabling, quick edit) and single‑instance mutex. |

---

### 0.2 — Core Strengthening (Planned)

| Version | Status | Description |
|---------|--------|-------------|
| 0.2.0 | ✅ Released | **Terminal capability detection** (additional): support for 256 colors, mouse, protocols (Kitty, iTerm2). Automatically disable ANSI codes when output is redirected. **Color operations**: gradients, blending, conversion to HSL/HSV, work with the 256‑color palette. Extend predefined colors. **Performance optimization**: caching ANSI sequences, reducing `Console.Write` calls, thread‑safe output methods. |

---

### 0.3 — Basic UI Elements (Planned)

| Version | Status | Description |
|---------|--------|-------------|
| 0.3.0 | 🟢 Planned | **Progress bars**: horizontal, vertical, custom characters, colors, percentage display, multithreaded animation. |
| 0.3.1 | 🟢 Planned | **Spinners**: various styles (dots, dashes, symbols), start/stop control. |
| 0.3.2 | 🟢 Planned | **Tables**: automatic column alignment, color support for rows/columns, sorting, row highlighting. |
| 0.3.3 | 🟢 Planned | **Menus**: arrow navigation, hotkeys, nested menus, selection indicator. |

---

### 0.4 — Interactive Widgets (Planned)

| Version | Status | Description |
|---------|--------|-------------|
| 0.4.0 | 🔵 Considering | **Buttons**: standard, focused, with hotkeys, color change on press. |
| 0.4.1 | 🔵 Considering | **Checkboxes and radio buttons**: standard and custom styles, radio button groups. |
| 0.4.2 | 🔵 Considering | **Sliders**: horizontal and vertical, value display, step size. |
| 0.4.3 | 🔵 Considering | **Text fields**: single‑line and multi‑line, cursor support, insertion, deletion, clipboard. |
| 0.4.4 | 🔵 Considering | **Lists**: dropdown lists, scrollable lists, multiple selection. |

---

### 0.5 — Rendering System and Layouts (Planned)

| Version | Status | Description |
|---------|--------|-------------|
| 0.5.0 | 🔵 Considering | **Virtual screen**: two‑dimensional buffer of characters with colors, independent of physical output. |
| 0.5.1 | 🔵 Considering | **Partial update**: compare virtual and physical buffers, output only changed regions. |
| 0.5.2 | 🔵 Considering | **Layers (Z‑index)**: ability to overlay elements, background transparency. |
| 0.5.3 | 🔵 Considering | **Layouts**: stack layout, grid, absolute positioning, adaptation to window size. |

---

### 0.6 — Advanced Widgets and Dialogs (Planned)

| Version | Status | Description |
|---------|--------|-------------|
| 0.6.0 | 🔵 Considering | **Dialog boxes**: modal windows with buttons (OK, Cancel, Yes/No), inputs, list selection. |
| 0.6.1 | 🔵 Considering | **Tabs**: switching between multiple contexts in the same area. |
| 0.6.2 | 🔵 Considering | **Trees**: hierarchical lists, collapsing/expanding nodes. |
| 0.6.3 | 🔵 Considering | **Calendar/date picker**: date, time selection. |

---

### 0.7 — Styling and Themes (Planned)

| Version | Status | Description |
|---------|--------|-------------|
| 0.7.0 | 🔵 Considering | **Style system**: ability to set colors, fonts (bold, italic), borders for each widget type. |
| 0.7.1 | 🔵 Considering | **Themes**: light/dark, customizable via JSON, runtime switching. |
| 0.7.2 | 🔵 Considering | **Fluent styling interface**: method chaining `.Foreground(Color.Red).Background(Color.Black).Bold()`. |

---

### 1.0 — Stable Release (Planned)

| Version | Status | Description |
|---------|--------|-------------|
| 1.0.0 | 🟢 Planned | **API stabilization**: freeze public interface, full documentation, usage examples. |
| 1.0.1 | 🟢 Planned | **Cross‑platform testing**: automated tests on Windows, Linux, macOS (GitHub Actions). |
| 1.0.2 | 🟢 Planned | **Performance optimization**: minimize allocations, support NativeAOT. |

---

### 1.x — Advanced Graphics and Animations (Future)

| Version | Status | Description |
|---------|--------|-------------|
| 1.1 | 🔵 Considering | **Animations**: smooth fade‑in/out, motion, color transitions, animation frames. |
| 1.2 | 🔵 Considering | **Graphic primitives**: drawing lines, rectangles, circles, color fills. |
| 1.3 | 🔵 Considering | **Image support**: display images via Kitty/iTerm2 protocols, conversion to ASCII/Unicode. |
| 1.4 | 🔵 Considering | **Advanced terminal protocols**: use Kitty Graphics Protocol, Sixel, iTerm2 Image Protocol. |

---

### 2.0 — Next Generation (Future)

| Version | Status | Description |
|---------|--------|-------------|
| 2.0.0 | 🔵 Considering | **Visual designer** (optional): interactive tool for interface design with code generation. |
| 2.0.1 | 🔵 Considering | **Widget plugins**: ability to register custom components without modifying the core. |
| 2.0.2 | 🔵 Considering | **Remote control**: send input/output events over the network (debugging, demonstration). |
