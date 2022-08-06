namespace DownloadManager;

public class FileInputMonitor
{
    // Defining the source and destination directories
    static string _sourceDir = @"C:\Users\chadl\Downloads";
    static string _destDirDocuments = @"C:\Users\chadl\Documents";
    static string _destDirMusic = @"C:\Users\chadl\Music";
    static string _destDirPictures = @"C:\Users\chadl\Pictures";
    static string _destDirVideos = @"C:\Users\chadl\Videos";

    // The FileSystemWatcher enables us to monitor changes to a (the source) folder
    private static FileSystemWatcher _fsw;

    public FileInputMonitor()
    {
        Console.WriteLine("FileInputMonitor Called");
        _fsw = new FileSystemWatcher(_sourceDir);                // Tell the fsw to watch the source folder
        _fsw.EnableRaisingEvents = true;                         // This allows us to raise events based on changes to the source folder
        _fsw.Created += new FileSystemEventHandler(ProcessFiles); // When a new file shows up, call the FileCreated method
    }

    static void ProcessFiles(Object sender, FileSystemEventArgs e)
    {
        Console.WriteLine("ProcessFiles Called");

        string fileName = e.Name;

        // Defining the extensions for the various file types
        string[] docExtensions = { "xlsx", ".pdf", "docx", ".txt", ".csv" };
        string[] musicExtensions = { ".mp3", "flac", ".ogg" };                      
        string[] vidExtensions = { ".mp4", ".avi", ".mov", ".flv", ".mkv", "webm" };                                        
        string[] pictureExtensions = { ".jpg", "jpeg", ".png", ".bmp", ".gif" };

        if (docExtensions.Any(fileName.Contains))
        {
            _destDirDocuments += string.Concat(@"\", fileName);
            File.Move(e.FullPath, _destDirDocuments);
            Console.Write(e.FullPath + _destDirDocuments);
        }


        // Get a list of files in the source directory
        //string[] srcFiles = Directory.GetFiles(_sourceDir);

        // Iterate through the files
        //foreach (string f in srcFiles)
        //{
        //    Console.WriteLine(f);

        //    // Based on the file extension, move it to the destination folder
        //    if (docExtensions.Any(f.Contains)){ File.Move(f, string.Concat(_destDirDocuments);
        //    else if (musicExtensions.Any(f.Contains)) File.Move(f, _destDirMusic);
        //    else if (pictureExtensions.Any(f.Contains)) File.Move(f, _destDirPictures);
        //    else if (vidExtensions.Any(f.Contains)) File.Move(f, _destDirVideos);
        //    else Console.WriteLine("No files found to move.");
        //}        
    }
}