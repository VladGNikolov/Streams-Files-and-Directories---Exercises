namespace DirectoryTraversal;

using System;
using System.IO.Enumeration;
using System.Text;

public class DirectoryTraversal
{
    static void Main()
    {
        string path = Console.ReadLine();
        string reportFileName = @"\report.txt";

        string reportContent = TraverseDirectory(path);
        Console.WriteLine(reportContent);

        WriteReportToDesktop(reportContent, reportFileName);
        
    }

    public static string TraverseDirectory(string inputFolderPath)
    {
        SortedDictionary<string, List<FileInfo>> extentionFiles = new();
       string[] fileNames = Directory.GetFiles(inputFolderPath);
        foreach (var fileName in fileNames) 
        {
            FileInfo fileInfo = new FileInfo(fileName);
            if (!extentionFiles.ContainsKey(fileInfo.Extension))
            {
                extentionFiles.Add(fileInfo.Extension, new List<FileInfo>());
            }
            extentionFiles[fileInfo.Extension].Add(fileInfo);
        }
        StringBuilder sb = new ();

        foreach (var extentionFile in extentionFiles.OrderByDescending(ef => ef.Value.Count))
        {
            sb.AppendLine(extentionFile.Key);

            //--Mecanismo.cs - 0.994kb
            foreach (var item in extentionFile.Value)
            {
                sb.AppendLine($"--{item.Name} - {item.Length/1024:f3}kb");
            }
        }

        return sb.ToString();

    }

    public static void WriteReportToDesktop(string textContent, string reportFileName)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ reportFileName;

        File.WriteAllText(path, textContent);
    }
}
