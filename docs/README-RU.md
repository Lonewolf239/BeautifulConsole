[![NuGet](https://img.shields.io/nuget/v/BeautifulConsole?style=for-the-badge&logo=nuget&logoColor=FFFFFF)](https://www.nuget.org/packages/BeautifulConsole)
[![Downloads](https://img.shields.io/nuget/dt/BeautifulConsole?style=for-the-badge&logo=download&logoColor=FFFFFF)](https://www.nuget.org/packages/BeautifulConsole)
[![.NET 6+](https://img.shields.io/badge/.NET-6+-2D2D2D?style=for-the-badge&logo=dotnet&logoColor=FFFFFF)](https://dotnet.microsoft.com/)
[![MIT License](https://img.shields.io/badge/License-MIT-2D2D2D?style=for-the-badge&logo=opensourceinitiative&logoColor=FFFFFF)](https://github.com/Lonewolf239/BeautifulConsole/blob/main/LICENSE)

[![Roadmap](https://img.shields.io/badge/ROADMAP-2D2D2D?style=for-the-badge&logo=map&logoColor=FFFFFF)](./ROADMAP.md)
[![Changelog](https://img.shields.io/badge/CHANGELOG-2D2D2D?style=for-the-badge&logo=history&logoColor=FFFFFF)](./CHANGELOG.md)

### Languages
[![EN](https://img.shields.io/badge/README-EN-2D2D2D?style=for-the-badge&logo=github&logoColor=FFFFFF)](./README.md)
[![RU](https://img.shields.io/badge/README-RU-2D2D2D?style=for-the-badge&logo=google-translate&logoColor=FFFFFF)](./README-RU.md)

# BeautifulConsole

Мощная .NET-библиотека для создания красивых консольных приложений с **поддержкой true‑цветов (24 бит)**, **кросс‑платформенным буфером обмена**, **расширенной настройкой окна** и чистым API, спроектированным по принципу «чёрного ящика».

```bash
dotnet add package BeautifulConsole
```

- **Пакет:** [nuget.org/packages/BeautifulConsole](https://www.nuget.org/packages/BeautifulConsole)
- **Версия:** 0.2 | **.NET 6+**
- **Разработчик:** [Lonewolf239](https://github.com/Lonewolf239)

---

## Features

| | Возможность | Подробности |
|---|------------|-------------|
| 🎨 | **True color (24‑bit) вывод** | ANSI-escape-последовательности для полноцветного RGB. В терминалах без поддержки ANSI используется ближайший цвет из `ConsoleColor`. |
| 🌈 | **Градиентный текст** | Плавные цветовые переходы с помощью `WriteGradient`. |
| ⌨️ | **Богатый ввод с подсказками** | `Read`, `ReadLine`, `ReadKey` с цветными `Message`. |
| 🖥️ | **Настройка окна консоли** | Изменение размера, заголовка, возможность изменения размеров, максимизации, центрирование, отключение кнопки закрытия, скрытие заголовка (только Windows). |
| 📋 | **Кросс‑платформенный буфер обмена** | Копирование/вставка текста на Windows (WinAPI), macOS (`pbcopy`/`pbpaste`) и Linux (`wl-copy`/`xclip`/`xsel`). |
| 🐭 | **Поддержка мыши (экспериментально)** | Включение/отключение отслеживания событий мыши с помощью `EnableMouse` / `DisableMouse`. |
| 🔒 | **Ограничение единственного экземпляра** | Обнаружение уже запущенного экземпляра приложения через мьютекс. |
| ⚙️ | **Глобальные цвета по умолчанию** | Управление цветами переднего плана и фона по умолчанию, а также автоматический сброс после каждой записи. |
| 🗺️ | **Богатая цветовая палитра** | Более 150 предопределённых цветов (web, пастельные, неоновые, металлические и др.) плюс произвольные RGB. |
| 📦 | **Чёрный ящик** | Всё взаимодействие происходит через статический класс `BConsole` – внутренняя сложность скрыта. |

---

## Installation

```bash
dotnet add package BeautifulConsole
```

---

## Quick Start

### Hello, World! с цветом

```csharp
using BeautifulConsole;
using BeautifulConsole.Models; // Для класса Message

BConsole.WriteLine(new Message("Привет, BeautifulConsole!", Color.NeonGreen));
BConsole.WriteLine(new Message("Красный на голубом", Color.Red, Color.Cyan));
```

### Ввод с подсказкой

```csharp
string name = BConsole.ReadLine(new Message("Как вас зовут? ", Color.Yellow));
BConsole.WriteLine($"Привет, {name}!", Color.Yellow);
```

### Градиентный текст

```csharp
BConsole.WriteGradient("Этот текст плавно меняет цвет от красного к синему", Color.Red, Color.Blue);
```

### Настройка окна консоли (Windows)

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

### Копирование в буфер обмена

```csharp
BeautifulConsole.Clipboard.Clipboard.SetText("Привет из BeautifulConsole!");
string text = BeautifulConsole.Clipboard.Clipboard.GetText();
if (BeautifulConsole.Clipboard.Clipboard.IsTextAvailable())
    Console.WriteLine($"Буфер обмена содержит: {text}");
```

### Ограничение единственного экземпляра

```csharp
if (!BConsole.SetMutex("MyApp_Unique_Name"))
{
    Console.WriteLine("Другая копия приложения уже запущена.");
    return;
}
// Логика вашего приложения...
// По завершении вызовите BConsole.ReleaseMutex() или положитесь на финализатор.
```

---

## Detailed Usage

### Цветной вывод

Все методы `Write` и `WriteLine` принимают объект `Message`, который содержит текст и опциональные цвета переднего плана и фона:

- `Write(Message? message)`
- `WriteLine()`
- `WriteLine(Message? message)`

**Пример:**

```csharp
BConsole.WriteLine(new Message("Это зелёный текст", Color.Green));
BConsole.WriteLine(new Message("Белый на синем", Color.White, Color.Blue));
```

Свойство `AutoResetColor` (по умолчанию `true`) автоматически сбрасывает цвета к значениям по умолчанию после каждого вывода. Если установить его в `false`, цвета будут сохраняться:

```csharp
BConsole.AutoResetColor = false;
BConsole.Write(new Message("Этот текст остаётся ", Color.Red));
BConsole.WriteLine(new Message("красным", Color.Red));
BConsole.ResetColor();   // ручной сброс
```

Цвета по умолчанию можно изменить:

```csharp
BConsole.DefaultForegroundColor = Color.LightGray;
BConsole.DefaultBackgroundColor = Color.DarkBlue;
```

### Градиентный текст

Метод `WriteGradient` выводит текст с плавным переходом цвета:

```csharp
WriteGradient(string text, Color startColor, Color endColor, bool resetAfter = true);
```

**Пример:**

```csharp
BConsole.WriteGradient("Радужный эффект", Color.Red, Color.Violet);
```

### Ввод с подсказкой

Все методы ввода имеют перегрузки, которые перед чтением отображают цветное сообщение `Message`:

- `Read(bool newLine)`
- `Read(Message? message, bool newLine)`
- `ReadLine(bool newLine)`
- `ReadLine(Message? message, bool newLine)`
- `ReadKey(bool intercept, bool newLine)`
- `ReadKey(bool intercept, Message? message, bool newLine)`

**Пример:**

```csharp
var prompt = new Message("Введите ваше имя: ", Color.Cyan);
string name = BConsole.ReadLine(prompt);
BConsole.WriteLine($"Привет, {name}!");
```

### Настройка окна консоли

Класс `BOptions` предоставляет широкие возможности управления окном консоли (большинство свойств работают только в Windows, некоторые – кросс-платформенно).

| Свойство | Описание | Платформа |
|----------|----------|-----------|
| `Width`, `Height` | Размер окна | Windows |
| `Title` | Заголовок окна | Кросс‑платформенно |
| `Resizable` | Разрешить изменение размера | Windows |
| `Maximizable` | Разрешить максимизацию | Windows |
| `Minimizable` | Разрешить минимизацию | Windows |
| `CenterWindow` | Центрировать на экране | Windows |
| `HideTitleBar` | Скрыть заголовок | Windows |
| `DisableCloseButton` | Отключить кнопку закрытия | Windows |
| `DisableQuickEdit` | Отключить быстрый режим редактирования | Windows |
| `EchoInput` | Показывать вводимые символы | Windows |
| `ProcessCtrlC` | Обрабатывать Ctrl+C | Windows |
| `EnableInputHistory` | Включить историю ввода | Windows |
| `CursorVisible` | Показать/скрыть курсор | Кросс‑платформенно |
| `CursorSize` | Размер курсора (1–100) | Windows |

Кроме того, множество свойств консоли теперь доступны напрямую через `BConsole`:

- `CursorVisible`
- `WindowWidth`, `WindowHeight`
- `BufferWidth`, `BufferHeight`
- `Title`
- `TreatControlCAsInput`
- `CursorSize`
- `NumberLock`, `CapsLock` (только Windows)
- `LargestWindowWidth`, `LargestWindowHeight`
- `IsInputRedirected`, `IsOutputRedirected`, `IsErrorRedirected`
- `InputEncoding`, `OutputEncoding`

### Поддержка мыши (экспериментально)

В терминалах, поддерживающих отслеживание мыши, можно включить или отключить получение событий мыши:

```csharp
BConsole.EnableMouse();  // Начать получать события мыши
BConsole.DisableMouse(); // Остановить получение событий мыши
```

**Примечание:** Обработка событий мыши пока не реализована полностью – поддерживается только включение/отключение отчёта. В будущих версиях будет добавлено чтение и обработка событий.

### Буфер обмена

Статический класс `BeautifulConsole.Clipboard.Clipboard` предоставляет простой API для работы с буфером обмена:

- `void SetText(string? text)`
- `bool TrySetText(string? text)` – возвращает успешность операции без выбрасывания исключений.
- `string? GetText()`
- `bool IsTextAvailable()`
- `bool Clear()`

**Особенности платформ:**
- **Windows:** использует WinAPI (`user32.dll`).
- **macOS:** использует `pbcopy`/`pbpaste` (обычно установлены по умолчанию).
- **Linux:** использует `wl-copy` (Wayland) или `xclip`/`xsel` (X11). Библиотека автоматически определяет доступные инструменты.

### Утилиты для работы с цветом

Класс `Color` содержит более 150 предопределённых цветов. Вы также можете создавать свои RGB-цвета:

```csharp
Color custom = new Color(123, 45, 67);
BConsole.WriteLine(new Message("Пользовательский цвет", custom));
```

Предопределённые цвета включают:
- Базовые: `Color.Red`, `Color.Green`, `Color.Blue`, `Color.White`, `Color.Black`
- Web: `Color.AliceBlue`, `Color.AntiqueWhite`, `Color.Cornsilk` и т.д.
- Пастельные: `Color.PastelRed`, `Color.PastelGreen`, `Color.PastelBlue`
- Неоновые: `Color.NeonRed`, `Color.NeonGreen`, `Color.NeonBlue`
- Металлические: `Color.GoldMetallic`, `Color.SilverMetallic`, `Color.Bronze`
- Землистые тона: `Color.Earth`, `Color.Clay`, `Color.Sand`, `Color.Moss`

Все цвета неизменяемы (immutable) и потокобезопасны.

---

## API Reference

Краткий обзор публичного API:

### `BConsole` (статический класс)

**Вывод**
- `Write(Message? message)`
- `WriteLine()`
- `WriteLine(Message? message)`
- `WriteGradient(string text, Color startColor, Color endColor, bool resetAfter = true)`
- `Clear()`
- `ResetColor()`

**Ввод**
- `Read(bool newLine = false)`
- `Read(Message? message, bool newLine = false)`
- `ReadLine(bool newLine = false)`
- `ReadLine(Message? message, bool newLine = false)`
- `ReadKey(bool intercept = false, bool newLine = false)`
- `ReadKey(bool intercept, Message? message, bool newLine = false)`

**Свойства**
- `bool AutoResetColor { get; set; }`
- `Color DefaultForegroundColor { get; set; }`
- `Color DefaultBackgroundColor { get; set; }`
- `bool CursorVisible { get; set; }`
- `int WindowWidth { get; set; }` (только Windows для setter)
- `int WindowHeight { get; set; }` (только Windows для setter)
- `int BufferWidth { get; set; }` (только Windows для setter)
- `int BufferHeight { get; set; }` (только Windows для setter)
- `string Title { get; set; }`
- `bool TreatControlCAsInput { get; set; }`
- `int CursorSize { get; set; }`
- `bool NumberLock { get; }` (только Windows)
- `bool CapsLock { get; }` (только Windows)
- `int LargestWindowWidth { get; }`
- `int LargestWindowHeight { get; }`
- `bool IsInputRedirected { get; }`
- `bool IsOutputRedirected { get; }`
- `bool IsErrorRedirected { get; }`
- `Encoding InputEncoding { get; set; }`
- `Encoding OutputEncoding { get; set; }`

**Настройка и единственный экземпляр**
- `void SetupConsoleSettings(BOptions? options)`
- `bool SetMutex(string? mutexName)`
- `void ReleaseMutex()`

**Мышь**
- `void EnableMouse()`
- `void DisableMouse()`

### `BOptions` (класс)

Все свойства имеют значения по умолчанию. См. раздел [Настройка окна консоли](#detailed-usage).

### `Color` (класс)

- Конструкторы: `Color(int r, int g, int b)`, `Color()` (пустой цвет)
- Более 150 статических предопределённых цветов.
- Свойства: `R`, `G`, `B` (байты).
- Методы: `Blend`, `Gradient`, `ToHsl`, `FromHsl`, `ToHsv`, `FromHsv`, `ToXterm256Index`.

### `Message` (класс)

- `Message(string? text, Color? foreground = null, Color? background = null)`
- `Message(char text, Color? foreground = null, Color? background = null)`
- Свойства: `Text`, `ForegroundColor`, `BackgroundColor`.

### `Clipboard` (статический класс, доступен через `BeautifulConsole.Clipboard.Clipboard`)

- `void SetText(string? text)`
- `bool TrySetText(string? text)`
- `string? GetText()`
- `bool IsTextAvailable()`
- `bool Clear()`

---

## Philosophy

**Чёрный ящик** – вся внутренняя логика скрыта за простым статическим API `BConsole`. Вы взаимодействуете с чистыми методами и свойствами, не задумываясь об ANSI-последовательностях, различиях платформ или внутреннем состоянии. BeautifulConsole управляет всем за вас.
