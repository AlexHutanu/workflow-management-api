using ILogger = WorkflowManagement.Interfaces.ILogger;

namespace WorkflowManagement.Services;

public class DevelopmentLogger : ILogger
{

    private static DevelopmentLogger? _instance = null;

    private DevelopmentLogger() {}

    public static DevelopmentLogger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DevelopmentLogger();
        }

        return _instance;
    }
    
    public void Info(string message)
    {
        Console.WriteLine($"INFO {message}");
    }

    public void Warn(string message)
    {
        Console.WriteLine($"WARNING {message}");
    }

    public void Error(string message)
    {
        Console.WriteLine($"ERROR {message}");
    }
}