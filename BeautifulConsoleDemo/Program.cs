using BeautifulConsole;
using BeautifulConsole.Models;

class Program
{
    static void Main()
    {
        BConsole.WriteLine(new("test15"));
        BConsole.WriteLine(new("test15", Color.Cyan));
        BConsole.WriteLine(new("test15", Color.Coral));
        BConsole.WriteLine(new("test15", Color.Tomato));
        BConsole.WriteLine(new("test15", Color.Tomato, Color.Cyan));
        BConsole.WriteLine(new("test15", Color.Tomato, Color.Yellow));
        BConsole.WriteLine(new("test15", Color.Tomato, Color.Orange));
        BConsole.WriteGradient("test15-gradient\n", Color.Tomato, Color.Green);
        string? bitch = BConsole.ReadLine(new("PLS input bitch: ", Color.MintCream));
        if (bitch is not null) BConsole.WriteGradient(bitch, Color.DarkGreen, Color.Navy);
        BConsole.ReadKey(true);
    }
}
