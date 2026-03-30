[![EN](https://img.shields.io/badge/CHANGELOG-EN-2D2D2D?style=for-the-badge&logo=github&logoColor=FFFFFF)](./CHANGELOG.md)
[![RU](https://img.shields.io/badge/CHANGELOG-RU-2D2D2D?style=for-the-badge&logo=google-translate&logoColor=FFFFFF)](./CHANGELOG-RU.md)

## Changelog · BeautifulConsole

<details open>
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
