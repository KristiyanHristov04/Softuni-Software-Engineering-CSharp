namespace SumEvensInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;

            Task task = Task.Run(async () =>
            {
                for (long i = 0; i < 1000000000; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                    await Task.Delay(1000);
                }
            });


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "show")
                {
                    Console.WriteLine(sum);
                } else if (input == "exit")
                {
                    return;
                }
            }
        }

    }
}