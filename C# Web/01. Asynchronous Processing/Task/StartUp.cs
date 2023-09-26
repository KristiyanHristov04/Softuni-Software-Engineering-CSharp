using System.Diagnostics;

namespace Summary
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            long number01 = 0;
            Task task01 = Task.Run(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (long i = 1; i <= 10; i++)
                {
                    number01 = i;
                    Task.Delay(1000).Wait();
                }
                stopwatch.Stop();
                Console.WriteLine("Ascending Time Taken:");
                Console.WriteLine($"Minutes: {stopwatch.Elapsed.Hours}");
                Console.WriteLine($"Minutes: {stopwatch.Elapsed.Minutes}");
                Console.WriteLine($"Seconds: {stopwatch.Elapsed.Seconds}");
                Console.WriteLine($"Milliseconds: {stopwatch.Elapsed.Milliseconds}");
            });

            long number02 = 0;
            Task task02 = Task.Run(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (long i = 10; i >= 1 ; i--)
                {
                    number02 = i;
                    Task.Delay(500).Wait();
                }
                stopwatch.Stop();
                Console.WriteLine("Descending Time Taken:");
                Console.WriteLine($"Minutes: {stopwatch.Elapsed.Hours}");
                Console.WriteLine($"Minutes: {stopwatch.Elapsed.Minutes}");
                Console.WriteLine($"Seconds: {stopwatch.Elapsed.Seconds}");
                Console.WriteLine($"Milliseconds: {stopwatch.Elapsed.Milliseconds}");
            });

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "a")
                {
                    Console.WriteLine("Ascending -> " + number01);
                }
                else if (input == "d")
                {
                    Console.WriteLine("Descending -> " + number02);
                }
                else if (input == "s")
                {
                    Console.WriteLine("Ascending Reached -> " + number01);
                    Console.WriteLine("Descending Reached -> " + number02);
                    return;
                }
            }
        }
    }
}