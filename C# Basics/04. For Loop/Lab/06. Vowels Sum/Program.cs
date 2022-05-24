using System;

namespace Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //06. Vawels sum
            string text = Console.ReadLine();
            //a e i o u 
            //1 2 3 4 5
            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {                
                switch (text[i])
                {
                    case 'a':
                        sum += 1;
                        break;
                    case 'e':
                        sum += 2;
                        break;
                    case 'i':
                        sum += 3;
                        break;
                    case 'o':
                        sum += 4;
                        break;
                    case 'u':
                        sum += 5;
                        break;


                }
            }
            Console.WriteLine(sum);
        }
    }
}
