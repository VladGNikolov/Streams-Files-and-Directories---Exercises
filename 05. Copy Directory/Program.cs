namespace CopyDirectory;

using System;

public class CopyDirectory
{
    static void Main()
    {
        string inputPath = @$"{Console.ReadLine()}";
        string outputPath = @$"{Console.ReadLine()}";

        CopyAllFiles(inputPath, outputPath);
    }

    public static void CopyAllFiles(string inputPath, string outputPath)
    {
        if (Directory.Exists(outputPath)) 
        {
            Directory.Delete(outputPath, true);
        }
        Directory.CreateDirectory(outputPath);
        string[] directoryFile = Directory.GetFiles(inputPath);

        foreach (string file in directoryFile) 
        {
            string movement = Path.GetFileName(file);
            string destination = Path.Combine(outputPath, movement);

            File.Copy(file, destination);
           
        }
    }
}
