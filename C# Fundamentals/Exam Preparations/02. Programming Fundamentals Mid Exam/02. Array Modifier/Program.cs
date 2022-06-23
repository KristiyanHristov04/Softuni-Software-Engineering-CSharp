using System;
using System.Linq;

namespace _02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] commands = input.Split(' ');
                int index01 = 0;
                int index02 = 0;
                if (commands[0] != "decrease")
                {
                    index01 = Convert.ToInt32(commands[1]);
                    index02 = Convert.ToInt32(commands[2]);
                }             
                switch (commands[0])
                {
                    case "swap":
                        int number01ToSwap = 0;
                        int number02ToSwap = 0;
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            if (i == index01)
                            {
                                number01ToSwap = numbers[i];
                            }
                            else if(i == index02)
                            {
                                number02ToSwap = numbers[i];
                            }
                        }
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            if (i == index01)
                            {
                                numbers[i] = number02ToSwap;
                            }
                            else if(i == index02)
                            {
                                numbers[i] = number01ToSwap;
                            }
                        }
                        break;
                    case "multiply":
                        int element01 = numbers[index01];
                        int element02 = numbers[index02];
                        int result = element01 * element02;
                        numbers[index01] = result;
                        break;
                    case "decrease":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i]--;
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
