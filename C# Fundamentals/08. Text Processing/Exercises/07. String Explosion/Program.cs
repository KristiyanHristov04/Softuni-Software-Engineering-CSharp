using System;

namespace _07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strenght = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string currentSymbol = input[i].ToString();
                if (currentSymbol == ">")
                {
                    strenght += Convert.ToInt32(input[i + 1].ToString());
                }
                else
                {
                    if (strenght != 0)
                    {
                        input = input.Remove(i, currentSymbol.Length);
                        i--;
                        strenght--;
                    }
                }
            }
            Console.WriteLine(input);
        }
    }
}
