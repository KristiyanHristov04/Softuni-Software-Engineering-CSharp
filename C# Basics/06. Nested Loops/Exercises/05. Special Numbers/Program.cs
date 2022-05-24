using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //05. Special numbers
            int n = int.Parse(Console.ReadLine());


            for (int i = 1111; i < 9999; i++)
            {
                int counter = 0;
                string currentNum = i.ToString();
                for (int j = 0; j < 4; j++)
                {

                    int currentDigit = int.Parse(currentNum[j].ToString());
                    if (currentDigit == 0)
                    {
                        break;
                    }
                    if (n % currentDigit == 0)
                    {
                        counter++;
                    }
                }
                if (counter == 4)
                {
                    Console.Write(i + " ");
                }
            }

        }
    }
}
