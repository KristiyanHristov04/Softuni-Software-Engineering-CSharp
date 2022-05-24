using System;

namespace InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            if ((number >= 100 && number <= 200) || number == 0)
            {

            }
            else
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
