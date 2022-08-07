
namespace DownloadManager;

internal class Log
{
    static string _filePath = @"C:\Users\chadl\Organize\DownloadManagerLog.log";

    public static void Add(string msgTxt, string type)
    {
        string msg = $"{DateTime.Now.ToString()}: {type}: " +     // The message to log
                $"Message: {msgTxt}" + Environment.NewLine;

        File.AppendAllText(_filePath, msg);                      // Appending the message to the log file
    }
}
