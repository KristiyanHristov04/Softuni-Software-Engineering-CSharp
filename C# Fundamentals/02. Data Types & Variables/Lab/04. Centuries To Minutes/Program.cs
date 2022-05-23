using System;

namespace Centuries_To_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte centuries = Convert.ToByte(Console.ReadLine());
            decimal totalDaysInAYear = 365.2422m;
            ushort years = (ushort)(centuries * 100);
            int days = (int)(years * totalDaysInAYear);
            long hours = days * 24;
            long minutes = hours * 60;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
