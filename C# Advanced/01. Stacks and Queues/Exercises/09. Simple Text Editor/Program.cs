using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> operations = new Stack<string>();
            StringBuilder text = new StringBuilder();
            int numberOfCommands = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string input = Console.ReadLine();
                if (input.StartsWith("1"))
                {
                    string textToAdd = input.Split()[1];
                    string textForBackup = text.ToString();
                    operations.Push(textForBackup);
                    text.Append(textToAdd);
                }
                else if (input.StartsWith("2"))
                {
                    int count = Convert.ToInt32(input.Split()[1]);
                    string textForBackup = text.ToString();
                    operations.Push(textForBackup);
                    text.Remove(text.Length - count, count);       
                }
                else if (input.StartsWith("3"))
                {
                    int index = Convert.ToInt32(input.Split()[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (input.StartsWith("4"))
                {
                    string backupText = operations.Pop();
                    text.Clear();
                    text.Append(backupText);
                }
            }
        }
    }
}
