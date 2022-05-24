using System;

namespace Time___15_minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = Convert.ToInt32(Console.ReadLine());
            int minutes = Convert.ToInt32(Console.ReadLine());
            if (minutes >= 45 && hour != 23)
            {
                if ((minutes + 15) - 60 < 10)
                {
                    Console.WriteLine($"{hour + 1}:0{(minutes + 15) - 60}");
                }
                else if ((minutes + 15) - 60 >= 10)
                {
                    Console.WriteLine($"{hour + 1}:{(minutes + 15) - 60}");
                }


            }
            else if (minutes <= 44)
            {
                Console.WriteLine($"{hour}:{minutes + 15}");
            }
            else if (hour == 23 && minutes >= 45)
            {
                if ((minutes + 15) - 60 < 10)
                {
                    Console.WriteLine($"{hour = 0}:0{(minutes + 15) - 60}");
                }
                else if ((minutes + 15) - 60 >= 10)
                {
                    Console.WriteLine($"{hour = 0}:{(minutes + 15) - 60}");
                }

            }
        }
    }
}
