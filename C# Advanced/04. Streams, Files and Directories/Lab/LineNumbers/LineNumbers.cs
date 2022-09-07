namespace LineNumbers
{
    using System.Collections.Generic;
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            Queue<string> text = new Queue<string>();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                while (reader.ReadLine() != null)
                {
                    string line = reader.ReadLine();
                    text.Enqueue(line);
                }
            }

            int counter = 1;
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                while (text.Count > 0)
                {
                    string textLine = text.Dequeue();
                    writer.WriteLine($"{counter}. {textLine}");
                    counter++;
                }
            }
        }
    }
}
