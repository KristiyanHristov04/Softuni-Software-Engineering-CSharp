namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StreamWriter writer = new StreamWriter(outputFilePath);
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int lineCounter = 1;
                string text = string.Empty;
                while (true)
                {
                    text = reader.ReadLine();
                    if (text == null)
                    {
                        break;
                    }
                    int characters = 0;
                    int punctuationMarks = 0;

                    foreach (var ch in text)
                    {
                        if (ch == '-' || ch == '.' || ch == ',' || ch == '!'
                            || ch == '?' || ch == '\'')
                        {
                            punctuationMarks++;
                        }
                        else if ((ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122))
                        {
                            characters++;
                        }
                    }
                    writer.WriteLine($"Line {lineCounter}: {text} ({characters})({punctuationMarks})");
                    lineCounter++;
                }
            }
            writer.Close();
        }
    }
}
