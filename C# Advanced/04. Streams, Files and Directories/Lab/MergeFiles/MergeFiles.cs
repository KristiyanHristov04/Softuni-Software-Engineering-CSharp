namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            Queue<string> text01 = new Queue<string>();
            Queue<string> text02 = new Queue<string>();
            using (StreamReader text01Reader = new StreamReader(firstInputFilePath))
            {
                string text = text01Reader.ReadToEnd();
                string[] tokens = text.Split();
                string finalText = string.Empty;
                for (int i = 0; i < tokens.Length; i++)
                {
                    finalText += tokens[i];
                }

                for (int i = 0; i < finalText.Length; i++)
                {
                    text01.Enqueue(finalText[i].ToString());
                }
            }

            using (StreamReader text02Reader = new StreamReader(secondInputFilePath))
            {
                string text = text02Reader.ReadToEnd();
                string[] tokens = text.Split();
                string finalText = string.Empty;
                for (int i = 0; i < tokens.Length; i++)
                {
                    finalText += tokens[i];
                }

                for (int i = 0; i < finalText.Length; i++)
                {
                    text02.Enqueue(finalText[i].ToString());
                }
            }

            if (text01.Count > text02.Count)
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (text02.Count > 0)
                    {
                        string currentElement01 = text01.Dequeue();
                        writer.WriteLine(currentElement01);
                        string currentElement02 = text02.Dequeue();
                        writer.WriteLine(currentElement02);
                    }
                    while (text01.Count > 0)
                    {
                        string element = text01.Dequeue();
                        writer.WriteLine(element);
                    }
                }
            }
            else if (text01.Count < text02.Count)
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (text01.Count > 0)
                    {
                        string currentElement01 = text01.Dequeue();
                        writer.WriteLine(currentElement01);
                        string currentElement02 = text02.Dequeue();
                        writer.WriteLine(currentElement02);
                    }
                    while (text02.Count > 0)
                    {
                        string element = text01.Dequeue();
                        writer.WriteLine(element);
                    }
                }
            }
            else if (text01.Count == text02.Count)
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (text01.Count > 0)
                    {
                        string currentElement01 = text01.Dequeue();
                        writer.WriteLine(currentElement01);
                        string currentElement02 = text02.Dequeue();
                        writer.WriteLine(currentElement02);
                    }
                }
            }
        }
    }
}
