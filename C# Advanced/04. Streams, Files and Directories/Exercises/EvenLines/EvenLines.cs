namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string finalText = string.Empty;
            string text = string.Empty;
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int counter = 0;
                bool isFirstTime = true;
                while (true)
                {
                    text = reader.ReadLine();
                    if (text == null)
                    {
                        break;
                    }
                    text = text.Replace('-', '@');
                    text = text.Replace(',', '@');
                    text = text.Replace('.', '@');
                    text = text.Replace(',', '@');
                    text = text.Replace('!', '@');
                    text = text.Replace('?', '@');
                    string[] textSplitted = text.Split(' ');
                    Stack<string> stack = new Stack<string>();
                    if (counter % 2 == 0)
                    {
                        for (int i = 0; i < textSplitted.Length; i++)
                        {
                            stack.Push(textSplitted[i]);
                        }
                        if (isFirstTime)
                        {
                            finalText += String.Join(" ", stack);
                            isFirstTime = false;
                        }
                        else
                        {
                            finalText += "\n";
                            finalText += String.Join(" ", stack);
                        }
                    }
                    counter++;
                }
                return finalText;
            } 
        }
    }
}
