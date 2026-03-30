[![NuGet](https://img.shields.io/nuget/v/BeautifulConsole?style=for-the-badge&logo=nuget&logoColor=FFFFFF)](https://www.nuget.org/packages/BeautifulConsole)
[![Downloads](https://img.shields.io/nuget/dt/BeautifulConsole?style=for-the-badge&logo=download&logoColor=FFFFFF)](https://www.nuget.org/packages/BeautifulConsole)
[![.NET 6+](https://img.shields.io/badge/.NET-6+-2D2D2D?style=for-the-badge&logo=dotnet&logoColor=FFFFFF)](https://dotnet.microsoft.com/)
[![MIT License](https://img.shields.io/badge/License-MIT-2D2D2D?style=for-the-badge&logo=opensourceinitiative&logoColor=FFFFFF)](https://github.com/Lonewolf239/BeautifulConsole/blob/main/LICENSE)

[![Roadmap](https://img.shields.io/badge/ROADMAP-2D2D2D?style=for-the-badge&logo=map&logoColor=FFFFFF)](./ROADMAP-RU.md)
[![Changelog](https://img.shields.io/badge/CHANGELOG-2D2D2D?style=for-the-badge&logo=history&logoColor=FFFFFF)](./CHANGELOG-RU.md)

### Languages
[![EN](https://img.shields.io/badge/README-EN-2D2D2D?style=for-the-badge&logo=github&logoColor=FFFFFF)](./README.md)
[![RU](https://img.shields.io/badge/README-RU-2D2D2D?style=for-the-badge&logo=google-translate&logoColor=FFFFFF)](./README-RU.md)

# BeautifulConsole

Мощная .NET-библиотека для создания красивых консольных приложений с **поддержкой настоящего цвета (true‑color)**, **кроссплатформенным буфером обмена**, **расширенной настройкой окна** и чистым API в стиле «чёрного ящика».

```bash
dotnet add package BeautifulConsole
```

- **Пакет:** [nuget.org/packages/BeautifulConsole](https://www.nuget.org/packages/BeautifulConsole)
- **Версия:** 0.1.2 | **.NET 6+**
- **Разработчик:** [Lonewolf239](https://github.com/Lonewolf239)

---

## Features

| | Функция | Описание |
|---|---------|----------|
| 🎨 | **Вывод в true color (24‑бит)** | ANSI-escape последовательности для полноценных RGB-цветов. При работе в устаревших терминалах автоматически подбирает ближайший цвет из `ConsoleColor`. |
| ⌨️ | **Богатый ввод с подсказками** | `Read`, `ReadLine`, `ReadKey` с цветными сообщениями. |
| 🖥️ | **Настройка окна консоли** | Установка размера, заголовка, возможность изменять размер, разворачивать на весь экран, центрировать окно, отключать кнопку закрытия, скрывать заголовок (только Windows). |
| 📋 | **Кроссплатформенный буфер обмена** | Копирование/вставка текста в Windows (WinAPI), macOS (`pbcopy`/`pbpaste`) и Linux (`wl-copy`/`xclip`/`xsel`). |
| 🔒 | **Контроль единственного экземпляра** | Обнаружение запущенных экземпляров через мьютекс — разрешён только один экземпляр приложения. |
| ⚙️ | **Глобальные цвета по умолчанию** | Управление цветом текста и фона по умолчанию, автоматический сброс после каждого вывода. |
| 🗺️ | **Богатая цветовая палитра** | Более 150 предопределённых цветов (web, пастельные, неоновые, металлические и др.), а также создание собственных RGB-цветов. |
| 📦 | **Дизайн «чёрный ящик»** | Всё взаимодействие происходит через статический класс `BConsole` — внутренняя сложность полностью скрыта. |

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

BConsole.WriteLine("Привет, BeautifulConsole!", Color.NeonGreen);
BConsole.WriteLine("Это красный текст на синем фоне", Color.Red, Color.Cyan);
```

### Read input with a prompt

```csharp
string name = BConsole.ReadLine("Как вас зовут? ");
BConsole.WriteLine($"Привет, {name}!", Color.Yellow);
```

### Configure the console window (Windows)

```csharp
var options = new BOptions
{
    Title = "Моё приложение",
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
BConsole.Clipboard.SetText("Привет из BeautifulConsole!");
string text = BConsole.Clipboard.GetText();
if (BConsole.Clipboard.IsTextAvailable())
    Console.WriteLine($"Буфер обмена содержит: {text}");
```

### Ensure single instance

```csharp
if (!BConsole.SetMutex("MyApp_Unique_Name"))
{
    Console.WriteLine("Другой экземпляр уже запущен.");
    return;
}
// Логика приложения...
// По окончании работы вызовите BConsole.ReleaseMutex() или положитесь на финализатор.
```

---

## Detailed Usage

### Colored Output

Все методы `Write` и `WriteLine` принимают один или два цвета:

- `Write(string? line)`, `Write(string? line, Color fg)`, `Write(string? line, Color fg, Color bg)`
- `WriteLine()`, `WriteLine(string? line)`, `WriteLine(string? line, Color fg)`, `WriteLine(string? line, Color fg, Color bg)`

Свойство `AutoResetColor` (по умолчанию `true`) автоматически возвращает цвета по умолчанию после каждого вывода. Если установить его в `false`, цвета будут сохраняться:

```csharp
BConsole.AutoResetColor = false;
BConsole.Write("Этот текст остаётся ", Color.Red);
BConsole.WriteLine("красным", Color.Red);
BConsole.ResetColor();   // ручной сброс
```

Цвета по умолчанию можно изменить:

```csharp
BConsole.DefaultForegroundColor = Color.LightGray;
BConsole.DefaultBackgroundColor = Color.DarkBlue;
```

### Input with Prompts

Все методы ввода имеют перегрузки, которые выводят цветное сообщение перед чтением:

- `Read()`, `Read(string? message)`, `Read(string? message, Color fg)`, `Read(string? message, Color fg, Color bg)`
- `ReadLine()`, `ReadLine(string? message)`, `ReadLine(string? message, Color fg)`, `ReadLine(string? message, Color fg, Color bg)`
- `ReadKey(bool intercept)`, `ReadKey(bool intercept, string? message)`, `ReadKey(bool intercept, string? message, Color fg)`, `ReadKey(bool intercept, string? message, Color fg, Color bg)`

### Console Window Configuration

Класс `BOptions` предоставляет широкий контроль над окном консоли (большинство функций работают только в Windows; размер и заголовок — кроссплатформенно).

| Свойство | Описание | Платформа |
|----------|----------|-----------|
| `Width`, `Height` | Размер окна | Windows |
| `Title` | Заголовок окна | Кроссплатформенно |
| `Resizable` | Разрешить изменение размера | Windows |
| `Maximizable` | Разрешить разворачивание на весь экран | Windows |
| `Minimizable` | Разрешить сворачивание | Windows |
| `CenterWindow` | Центрировать окно на экране | Windows |
| `HideTitleBar` | Скрыть заголовок окна | Windows |
| `DisableCloseButton` | Отключить кнопку закрытия | Windows |
| `DisableQuickEdit` | Отключить режим быстрого редактирования | Windows |
| `EchoInput` | Отображать вводимые символы | Windows |
| `ProcessCtrlC` | Включить обработку Ctrl+C | Windows |
| `EnableInputHistory` | Включить историю команд | Windows |
| `CursorVisible` | Показывать/скрывать курсор | Кроссплатформенно |
| `CursorSize` | Размер курсора (1–100) | Windows |

### Clipboard Operations

Статический класс `BConsole.Clipboard` предоставляет простой API для работы с буфером обмена:

- `void SetText(string? text)`
- `bool TrySetText(string? text)` — возвращает успех операции без выбрасывания исключения.
- `string? GetText()`
- `bool IsTextAvailable()`
- `bool Clear()`

**Особенности платформ:**
- **Windows:** используется WinAPI (`user32.dll`).
- **macOS:** используется `pbcopy`/`pbpaste` (утилиты установлены по умолчанию).
- **Linux:** используется `wl-copy` (Wayland) или `xclip`/`xsel` (X11). Библиотека автоматически определяет доступные инструменты.

### Color Utilities

Класс `Color` предоставляет более 150 предопределённых цветов. Вы также можете создать собственный RGB-цвет:

```csharp
Color custom = new Color(123, 45, 67);
BConsole.WriteLine("Пользовательский цвет", custom);
```

Среди предопределённых цветов:
- Базовые: `Color.Red`, `Color.Green`, `Color.Blue`, `Color.White`, `Color.Black`
- Web: `Color.AliceBlue`, `Color.AntiqueWhite`, `Color.Cornsilk` и др.
- Пастельные: `Color.PastelRed`, `Color.PastelGreen`, `Color.PastelBlue`
- Неоновые: `Color.NeonRed`, `Color.NeonGreen`, `Color.NeonBlue`
- Металлические: `Color.GoldMetallic`, `Color.SilverMetallic`, `Color.Bronze`
- Землистые тона: `Color.Earth`, `Color.Clay`, `Color.Sand`, `Color.Moss`

Все цвета неизменяемы (immutable) и потокобезопасны.

---

## API Reference

Краткий обзор публичного API:

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

Все свойства могут быть `null` или имеют разумные значения по умолчанию. Полный список см. в разделе [Console Window Configuration](#console-window-configuration).

### `Color` (class)

- Конструкторы: `Color(int r, int g, int b)`
- Более 150 статических предопределённых цветов.
- Свойства: `R`, `G`, `B` (байты).

### `Clipboard` (static class, accessible via `BConsole.Clipboard`)

- `void SetText(string? text)`
- `bool TrySetText(string? text)`
- `string? GetText()`
- `bool IsTextAvailable()`
- `bool Clear()`

---

## Philosophy

**Чёрный ящик (Black Box)** – вся внутренняя логика скрыта за простым статическим API `BConsole`. Вы работаете с чистыми методами и свойствами, не задумываясь об ANSI-последовательностях, различиях платформ или управлении внутренним состоянием. BeautifulConsole управляет всем за вас.
