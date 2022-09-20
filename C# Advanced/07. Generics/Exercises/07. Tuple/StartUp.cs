using System;

namespace _07._Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string firstName = input.Split(' ')[0];
            string secondName = input.Split(' ')[1];
            string adress = input.Split(' ')[2];
            string fullName = firstName + " " + secondName;
            MyTuple<string, string> tuple01 = new MyTuple<string, string>(fullName, adress);
            Console.WriteLine(tuple01);

            string secondInput = Console.ReadLine();
            string name = secondInput.Split(' ')[0];
            int litersOfBeer = Convert.ToInt32(secondInput.Split(' ')[1]);
            MyTuple<string, int> tuple02 = new MyTuple<string, int>(name, litersOfBeer);
            Console.WriteLine(tuple02);

            string thirdInput = Console.ReadLine();
            int integer = Convert.ToInt32(thirdInput.Split(' ')[0]);
            double doubleNum = Convert.ToDouble(thirdInput.Split(' ')[1]);
            MyTuple<int, double> tuple03 = new MyTuple<int, double>(integer, doubleNum);
            Console.WriteLine(tuple03);
        }
    }
}
