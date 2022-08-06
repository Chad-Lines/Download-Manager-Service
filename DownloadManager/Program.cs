namespace DownloadManager;

internal class Program
{
    static void Main(string[] args)
    {
        // Defining the source and destination directories
        string sourceDir = @"C:\Users\chadl\Downloads";
        string destDirDocuments = = @"C:\Users\chadl\Documents";
        string destDirMusic = @"C:\Users\chadl\Music";
        string destDirPictures = @"C:\Users\chadl\Pictures";
        string destDirVideos = @"C:\Users\chadl\Videos";

        string[] downloadFiles = Directory.GetFiles(sourceDir);

        foreach (string f in downloadFiles) {  Console.WriteLine(f); }
    }
}