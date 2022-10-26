using System;

namespace Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICar seat = new Seat("Leon", "Grey");
            ICar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat.ToString());
            seat.Start();
            seat.Stop();
            Console.WriteLine(tesla.ToString());
            tesla.Start();
            tesla.Stop();
        }
    }
}
