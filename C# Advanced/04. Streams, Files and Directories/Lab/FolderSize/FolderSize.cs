namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            FileInfo[] infos = dirInfo.GetFiles("*", SearchOption.AllDirectories);

            foreach (var fileInfo in infos)
            {
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;
            File.WriteAllText(outputFilePath, sum.ToString());
        }
    }
}
