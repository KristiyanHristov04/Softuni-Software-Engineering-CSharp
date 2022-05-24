using System;

namespace PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = Convert.ToDouble(Console.ReadLine());
            char gender = Convert.ToChar(Console.ReadLine());
            if (gender == 'f')
            {
                if (age < 16)
                {
                    Console.WriteLine("Miss");
                }
                else if (age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
            }
            else if (gender == 'm')
            {
                if (age < 16)
                {
                    Console.WriteLine("Master");
                }
                else if (age >= 16)
                {
                    Console.WriteLine("Mr.");
                }
            }
        }
    }
}
