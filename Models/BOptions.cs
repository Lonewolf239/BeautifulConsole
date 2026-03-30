namespace BeautifulConsole.Models;

/// <summary>Provides configuration options for console behavior and appearance.</summary>
public sealed class BOptions
{
    /// <summary>Gets or sets the width of the console window.</summary>
    public int? Width { get; set; }

    /// <summary>Gets or sets the height of the console window.</summary>
    public int? Height { get; set; }

    /// <summary>Gets or sets the title of the console window.</summary>
    public string? Title { get; set; }

    /// <summary>Gets or sets a value indicating whether the console window can be resized.</summary>
    public bool? Resizable { get; set; }

    /// <summary>Gets or sets a value indicating whether the console window can be maximized.</summary>
    public bool? Maximizable { get; set; }

    /// <summary>Gets or sets a value indicating whether the console window can be minimized.</summary>
    public bool? Minimizable { get; set; }

    /// <summary>Gets or sets a value indicating whether the console window should be centered on the screen.</summary>
    public bool? CenterWindow { get; set; }

    /// <summary>Gets or sets a value indicating whether the title bar should be hidden.</summary>
    public bool? HideTitleBar { get; set; }

    /// <summary>Gets or sets a value indicating whether the close button should be disabled.</summary>
    public bool? DisableCloseButton { get; set; }

    /// <summary>Gets or sets a value indicating whether quick edit mode should be disabled.</summary>
    public bool? DisableQuickEdit { get; set; }

    /// <summary>Gets or sets a value indicating whether the cursor is visible.</summary>
    public bool? CursorVisible { get; set; }

    /// <summary>Gets or sets the size of the cursor (1-100).</summary>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value is less than 1 or greater than 100.</exception>
    public int CursorSize
    {
        get => _CursorSize;
        set
        {
            if (value < 1 || value > 100)
                throw new System.ArgumentOutOfRangeException(nameof(value), value, "Cursor size must be between 1 and 100.");
            _CursorSize = value;
        }
    }
    private int _CursorSize = 100;

    /// <summary>Gets or sets a value indicating whether input characters should be echoed to the console.</summary>
    public bool? EchoInput { get; set; }

    /// <summary>Gets or sets a value indicating whether input history is enabled.</summary>
    public bool? EnableInputHistory { get; set; }

    /// <summary>Gets or sets a value indicating whether Ctrl+C should be processed as input.</summary>
    public bool? ProcessCtrlC { get; set; }

    /// <summary>Creates a new instance of BOptions with default values.</summary>
    public BOptions()
    {
        // Установка значений по умолчанию
        Resizable = true;
        Maximizable = true;
        Minimizable = true;
        CursorVisible = true;
        EchoInput = true;
        EnableInputHistory = true;
        ProcessCtrlC = true;
        DisableQuickEdit = false;
        DisableCloseButton = false;
        HideTitleBar = false;
        CenterWindow = false;
    }

    /// <summary>Creates a deep copy of the current options.</summary>
    public BOptions Clone() => new BOptions
    {
        Width = Width,
        Height = Height,
        Title = Title,
        Resizable = Resizable,
        Maximizable = Maximizable,
        Minimizable = Minimizable,
        CenterWindow = CenterWindow,
        HideTitleBar = HideTitleBar,
        DisableCloseButton = DisableCloseButton,
        DisableQuickEdit = DisableQuickEdit,
        CursorVisible = CursorVisible,
        CursorSize = CursorSize,
        EchoInput = EchoInput,
        EnableInputHistory = EnableInputHistory,
        ProcessCtrlC = ProcessCtrlC
    };
}
