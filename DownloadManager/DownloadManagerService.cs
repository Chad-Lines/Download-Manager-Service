namespace DownloadManager;

public class DownloadManagerService
{
    
    public static void Main()
    {
        // Setting up the path
        string _downloadPath = @"C:\Users\chadl\Downloads";

        // Getting the contents of the folder
        string[] _files = Directory.GetFiles(_downloadPath);

        foreach (string f in _files)
        {
            Console.WriteLine(f);
        }
    }
}
