namespace Asynchronous_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            Thread myThread = new Thread(() =>
            {
                PrintEvenNumbers(start, end);
            });

            myThread.Start();
            myThread.Join();
            Console.WriteLine("Thread finished work");
        }

        static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++) 
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}