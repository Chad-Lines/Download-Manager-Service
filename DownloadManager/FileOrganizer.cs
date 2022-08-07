namespace DownloadManager;

public class FileOrganizer
{
    // Defining the source directory
    static string _sourceDir = @"C:\Users\chadl\Organize";
    
    // Defining the destination directories
    static string _dirDocuments = @"C:\Users\chadl\Actual Documents";
    static string _dirMusic = @"C:\Users\chadl\Music";
    static string _dirPictures = @"C:\Users\chadl\Pictures";
    static string _dirVideos = @"C:\Users\chadl\Videos";

    // Defining the extensions for the various file types
    static string[] _docExtensions = { "xlsx", ".pdf", "docx", ".txt", ".csv" };
    static string[] _musicExtensions = { ".mp3", "flac", ".ogg" };
    static string[] _vidExtensions = { ".mp4", ".avi", ".mov", ".flv", ".mkv", "webm" };
    static string[] _pictureExtensions = { ".jpg", "jpeg", ".png", ".bmp", ".gif", ".svg" };

    // The FileSystemWatcher enables us to monitor changes to a (the source) folder
    private static FileSystemWatcher _fsw;

    public FileOrganizer()
    {
        _fsw = new FileSystemWatcher(_sourceDir);                // Tell the fsw to watch the source folder
        _fsw.EnableRaisingEvents = true;                         // This allows us to raise events based on changes to the source folder
        _fsw.Created += new FileSystemEventHandler(ProcessFiles); // When a new file shows up, call the FileCreated method
    }

    static void ProcessFiles(Object sender, FileSystemEventArgs e)
    {
        // This will hold the full destination path (e.x. "C:\Users\chadl\Documents\Example.txt")
        // This format is required by the File.Move method
        string fullDestPath;

        // Returns the name of the file sans the path (e.x. "Example.txt")
        string fileName = e.Name;

        // Try...
        try
        {
            // Make sure the file name is not null. If it is, return
            if (fileName == null) return;

            // Check if the filename has the an extension matching those defined. If so, then we
            // set the destination path accordingly        
            else if (_docExtensions.Any(fileName.Contains)) fullDestPath = Path.Combine(_dirDocuments, fileName);
            else if (_musicExtensions.Any(fileName.Contains)) fullDestPath = Path.Combine(_dirMusic, fileName);
            else if (_vidExtensions.Any(fileName.Contains)) fullDestPath = Path.Combine(_dirVideos, fileName);
            else if (_pictureExtensions.Any(fileName.Contains)) fullDestPath = Path.Combine(_dirPictures, fileName);

            // If the file extension isn't found, just return
            else return;

            // Call the MoveFile method
            MoveFile(e, fullDestPath);
        }
        // If the above fails for any reason...
        catch (Exception ex)
        {
            // Log the error
            LogFailure(ex);
        }        
    }    

    static void MoveFile(FileSystemEventArgs e, string fullDestPath)
    {
        try
        {
            // Move the file
            File.Move(e.FullPath, fullDestPath);

            // Log the successful operations
            Log.Add($"{e.Name} moved to {fullDestPath}.", "Success");
        }
        catch (Exception ex)
        {
            // Log the error
            LogFailure(ex);
        }

    }

    static void LogFailure(Exception ex)
    {
        // Send the error to the log
        Log.Add(ex.ToString(), "Error");
    }
    
}