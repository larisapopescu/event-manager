namespace mainfile;

public class ConsoleLogger : ILogger
{
    public void Info(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[INFO] {message}");
        Console.ResetColor();
    }

    public void Warning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[WARN] {message}");
        Console.ResetColor();
    }

    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR] {message}");
        Console.ResetColor();
    }
}