using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            //09. Clock
            int hours = 23;
            int minutes = 59;
            int seconds = 59;
            for (int h = 0; h <= hours; h++)
            {
                for (int m = 0; m <= minutes; m++)
                {
                    for (int s = 0; s <= seconds; s++)
                    {
                        Console.WriteLine($"{h} : {m} : {s}");
                    }
                }

            }






        }
    }
}
