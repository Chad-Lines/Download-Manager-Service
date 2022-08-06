namespace DownloadManager;

internal class DownloadManager
{
    // Defining the source and destination directories
    static string _sourceDir = @"C:\Users\chadl\Downloads";
    static string _destDirDocuments = @"C:\Users\chadl\Documents";
    static string _destDirMusic = @"C:\Users\chadl\Music";
    static string _destDirPictures = @"C:\Users\chadl\Pictures";
    static string _destDirVideos = @"C:\Users\chadl\Videos";

    // The FileSystemWatcher enables us to monitor changes to a (the source) folder
    private static FileSystemWatcher fsw; 

    static void Main(string[] args)
    {
        fsw = new FileSystemWatcher(_sourceDir);                // Tell the fsw to watch the source folder
        fsw.EnableRaisingEvents = true;                         // This allows us to raise events based on changes to the source folder
        fsw.Created += new FileSystemEventHandler(ProcessFile); // When a new file shows up, call the FileCreated method
    }

    static void ProcessFile(Object sender, FileSystemEventArgs e)
    {
        // Get the last 4 chars of the string
        //string ext = e.Name.Substring(e.Name.Length - 4);

        // Defining the extensions for the various file types
        string[] docExtensions = { "xlsx", ".pdf", "docx", ".txt", ".csv" };
        string[] musicExtensions = { ".mp3", "flac", ".ogg" };                      
        string[] vidExtensions = { ".mp4", ".avi", ".mov", ".flv", ".mkv", "webm" };                                        
        string[] pictureExtensions = { ".jpg", "jpeg", ".png", ".bmp", ".gif" };

        // Get a list of files in the source directory
        string[] srcFiles = Directory.GetFiles(_sourceDir);

        // Iterate through the files
        foreach (string f in srcFiles)
        {
            // Based on the file extension, move it to the destination folder
            if (docExtensions.Any(f.Contains)) File.Move(f, _destDirDocuments);
            else if (musicExtensions.Any(f.Contains)) File.Move(f, _destDirMusic);
            else if (pictureExtensions.Any(f.Contains)) File.Move(f, _destDirPictures);
            else if (vidExtensions.Any(f.Contains)) File.Move(f, _destDirVideos);
            else Console.WriteLine("No files found to move.");
        }        
    }
}