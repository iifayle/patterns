public interface ILogger
{
    void start(string title);
    void log(string message);
    void stop();
}
public class Logger : ILogger
{
    private string LogFileName = string.Format(@"{0}/LOG{1}.txt",Directory.GetCurrentDirectory(),DateTime.Now.ToString("yyyyMMdd-HH-mm-ss"));
    private static Logger? _instance;//для хран единств экземп класса
    private int _logId;
    private Stack<string> _namespaces;//LIFO

    public static ILogger CreateObg()
    {
        return _instance ??= new Logger();//механизм для создания единст экземп
    }
    private Logger()
    {
        _logId = 0;
        _namespaces = new Stack<string>();
        WriteLog("INIT");
    }
    //----------------------
    public void start(string title)
    {
        _namespaces.Push(title);
        WriteLog("STRT");
    }
    public void stop()
    {
        _namespaces.Pop();
        WriteLog("Stop");
    }
    public void log(string message)
    {
        WriteLog("Info", message);
    }
    private void WriteLog(string logType, string message = "")
    {
        _logId++;
        File.AppendAllText(LogFileName, $"{FormateLog(logType, message)}\n");
    }
    private string FormateLog(string logType, string logMessage = "")
    {
        return $"{_logId:d6}-{DateTime.Now:dd.MM.yyyy HH:mm:ss}-{logType} {FormateNamespace()}{logMessage}";
    }
    private string FormateNamespace()
    {
        return _namespaces.Count == 0 ? "" : string.Join(":", _namespaces.Reverse()) + ":";
    }
}