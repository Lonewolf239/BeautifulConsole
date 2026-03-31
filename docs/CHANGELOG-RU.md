[![EN](https://img.shields.io/badge/CHANGELOG-EN-2D2D2D?style=for-the-badge&logo=github&logoColor=FFFFFF)](./CHANGELOG.md)
[![RU](https://img.shields.io/badge/CHANGELOG-RU-2D2D2D?style=for-the-badge&logo=google-translate&logoColor=FFFFFF)](./CHANGELOG-RU.md)

## Changelog · BeautifulConsole

<details open>
<summary><strong>0.2</strong> — March 31, 2026</summary>

#### List of changes

- **Определение возможностей терминала**
  - Автоматическое определение поддержки ANSI, truecolor (24‑бит), 256‑цветной палитры, событий мыши, протоколов Kitty и iTerm2.
  - ANSI-последовательности автоматически отключаются при перенаправлении вывода.
- **Улучшения работы с цветами**
  - Новые методы `Color`: смешивание, градиенты, преобразования в HSL/HSV, преобразование в индекс xterm‑256.
  - Добавлен метод `WriteGradient` для плавного градиентного вывода текста.
  - Расширен набор предопределённых цветов.
- **Оптимизация производительности**
  - Кэширование ANSI-последовательностей для повторного использования.
  - Потокобезопасный вывод с помощью синхронизации `lock`.
  - Уменьшено количество вызовов `Console.Write` при выводе градиентов.
- **Улучшения ввода**
  - Все методы `Read`, `ReadLine` и `ReadKey` теперь принимают необязательный параметр `newLine` (по умолчанию `false`), позволяющий управлять выводом пустой строки перед приглашением.
- **Основа для поддержки мыши** 
  - Методы `EnableMouse()` и `DisableMouse()` для включения отслеживания мыши (полная обработка событий будет добавлена в версии 0.3).
- **Дополнения API**
  - Метод `Color.CreateClamped()` для безопасного создания цвета с автоматическим ограничением компонентов. 
  - Метод `WriteGradient()` для вывода текста градиентом.

</details>

<details>
<summary><strong>0.1.2</strong> — March 30, 2026</summary>

#### List of changes

- Расширенные возможности управления консолью с помощью статического класса `BConsole`:
  - `WindowWidth` / `WindowHeight` – получение/установка размера окна консоли.
  - `BufferWidth` / `BufferHeight` – управление размером буфера экрана.
  - `Title` – получение/установка заголовка окна.
  - `TreatControlCAsInput` – управление обработкой Ctrl+C.
  - `CursorSize` – изменение размера курсора (1–100%).
  - `NumberLock` / `CapsLock` – состояние переключаемых клавиш.
  - `LargestWindowWidth` / `LargestWindowHeight` – максимально возможный размер окна.
  - `IsInputRedirected` / `IsOutputRedirected` / `IsErrorRedirected` – проверка перенаправления потока.
  - `InputEncoding` / `OutputEncoding` – управление кодированием ввода/вывода.

</details>

<details>
<summary><strong>0.1.1</strong> — March 30, 2026</summary>

#### List of changes

- **Исправлена функциональность буфера обмена в Linux и macOS**
Ранее проверка наличия утилит (xclip, xsel, wl-clipboard, pbpaste) всегда возвращала false из-за некорректного выполнения команды -v. Теперь используется /bin/sh -c "command -v <command>" с резервным вариантом, что гарантирует корректное обнаружение установленных инструментов.
- **Увеличен тайм-аут для команд буфера обмена**
Тайм-аут ожидания завершения процессов увеличен с 3 до 10 секунд, что позволяет копировать большие объемы текста без ложных срабатываний.

</details>

<details>
<summary><strong>0.1</strong> — March 30, 2026</summary>

#### List of changes

- Первый релиз

</details>
