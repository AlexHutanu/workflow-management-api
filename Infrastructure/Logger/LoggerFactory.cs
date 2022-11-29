using ILogger = WorkflowManagement.Interfaces.ILogger;

namespace WorkflowManagement.Services;

public static class LoggerFactory
{
    public static ILogger GetLogger()
    {
        var environment = "Development";

        return environment switch
        {
            "Development" => DevelopmentLogger.GetInstance(),
            "Production" =>  ProductionLogger.GetInstance(),
            _ => throw new Exception("")
        };
    }
}