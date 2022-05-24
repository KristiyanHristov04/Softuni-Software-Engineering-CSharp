using System;

namespace WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int time = Convert.ToInt32(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();
            if ((time >= 10 && time <= 18) && dayOfWeek != "Sunday")
            {
                Console.WriteLine("open");
            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}
