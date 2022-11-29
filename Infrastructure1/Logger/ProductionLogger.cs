using ILogger = WorkflowManagement.Interfaces.ILogger;

namespace WorkflowManagement.Services;

public class ProductionLogger : ILogger
{

    private static ProductionLogger? _instance = null;
    
    private ProductionLogger() {}

    public static ProductionLogger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ProductionLogger();
        }

        return _instance;
    }
    
    public void Info(string message) { }

    public void Warn(string message) { }

    public void Error(string message)
    {
        Console.WriteLine($"ERROR {message}");
    }
}