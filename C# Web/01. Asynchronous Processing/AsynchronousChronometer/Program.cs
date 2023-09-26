namespace AsynchronousChronometer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chronometer myChronometer = new Chronometer();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                } 
                else if (input == "start")
                {
                    Task.Run(() =>
                    {
                        myChronometer.Start();
                    });
                }
                else if (input == "stop")
                {
                    myChronometer.Stop();
                }
                else if (input == "lap")
                {
                    Console.WriteLine(myChronometer.Lap());
                }
                else if (input == "laps")
                {
                    if (myChronometer.Laps.Count > 0)
                    {
                        Console.WriteLine("Laps:");
                        for (int i = 0; i < myChronometer.Laps.Count; i++)
                        {
                            Console.WriteLine($"{i}. {myChronometer.Laps[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Laps: no laps");
                    }
                }
                else if (input == "reset")
                {
                    myChronometer.Reset();
                }
                else if (input == "time")
                {
                    Console.WriteLine(myChronometer.GetTime);
                }
            }
            myChronometer.Stop();
        }
    }
}