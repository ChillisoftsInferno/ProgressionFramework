using NLog;
using ILogger = DialogueSystem.Interfaces.ILogger;

namespace DialogueSystem.Services;

public class MyLogger : ILogger
{
    private static MyLogger _instance;
    private static Logger logger;

    private const string loggerRules = "myAppLoggerRules";
    public MyLogger() { }
    
    public static MyLogger GetInstance() => _instance ??= new MyLogger();
    // {
    //     // if (_instance == null) _instance = new MyLogger();
    //     // return _instance;
    // }
    private Logger GetLogger(string theLogger) => MyLogger.logger ??= LogManager.GetLogger(theLogger);
    // {
    //     //if (MyLogger.logger == null) MyLogger.logger = LogManager.GetLogger(theLogger);
    //     return 
    // }
    
    public void Debug(string message, string? arg = null)
    {
        if (arg == null)
            GetLogger(loggerRules).Debug(message, arg);
        else
            GetLogger(loggerRules).Debug(message, arg);
    }
    
    public void Info(string message, string? arg = null)
    {
        if (arg == null)
            GetLogger(loggerRules).Info(message, arg);
        else
            GetLogger(loggerRules).Info(message, arg);
    }
    
    public void Warning(string message, string? arg = null)
    {
        if (arg == null)
            GetLogger(loggerRules).Warn(message, arg);
        else
            GetLogger(loggerRules).Warn(message, arg);
    }
    
    public void Error(string message, string? arg = null)
    {
        if (arg == null)
            GetLogger(loggerRules).Error(message, arg);
        else
            GetLogger(loggerRules).Error(message, arg);
    }
}
