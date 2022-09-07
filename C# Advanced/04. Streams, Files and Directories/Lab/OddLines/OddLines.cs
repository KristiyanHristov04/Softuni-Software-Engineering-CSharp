namespace OddLines
{
    using System.Collections.Generic;
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            int counter = 1;
            Queue<string> text = new Queue<string>();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                while (reader.ReadLine() != null)
                {
                    string currentTextLine = reader.ReadLine();
                    if (counter % 2 != 0)
                    {
                        text.Enqueue(currentTextLine);
                    }
                }
            }
            
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                while (text.Count > 0)
                {
                    string currentLine = text.Dequeue();
                    writer.WriteLine(currentLine);
                }
            }
        }
    }
}
