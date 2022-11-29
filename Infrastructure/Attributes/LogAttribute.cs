using LoggerFactory = WorkflowManagement.Services.LoggerFactory;

namespace Infrastructure.Attributes;

public class LogAttribute : Attribute
{
    
    public LogAttribute(string name)
    {
        var logger = LoggerFactory.GetLogger();
        logger.Info(name);
    }
}