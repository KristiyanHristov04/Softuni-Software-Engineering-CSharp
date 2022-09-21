using System;

namespace _08._Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();
            if (firstInput.Length == 4)
            {
                string firstName = firstInput[0];
                string lastName = firstInput[1];
                string adress = firstInput[2];
                string town = firstInput[3];

                string fullName = firstName + " " + lastName;
                Threeuple<string, string, string> tuple01 = new Threeuple<string, string, string>(fullName, adress, town);
                Console.WriteLine(tuple01);
            }
            else
            {
                string firstName = firstInput[0];
                string lastName = firstInput[1];
                string adress = firstInput[2];
                string town01 = firstInput[3];
                string town02 = firstInput[4];

                string fullName = firstName + " " + lastName;
                string fullTownName = town01 + " " + town02;
                Threeuple<string, string, string> tuple01 = new Threeuple<string, string, string>(fullName, adress, fullTownName);
                Console.WriteLine(tuple01);
            }
            

            string[] secondInput = Console.ReadLine().Split();
            string name = secondInput[0];
            int litersOfBeer = Convert.ToInt32(secondInput[1]);
            string drunkOrNot = secondInput[2] == "drunk" ? "True" : "False";
            Threeuple<string, int, string> tuple02 = new Threeuple<string, int, string>(name, litersOfBeer, drunkOrNot);
            Console.WriteLine(tuple02);

            string[] thirdInput = Console.ReadLine().Split();
            string name02 = thirdInput[0];
            double accountBalance = Convert.ToDouble(thirdInput[1]);
            string bankName = thirdInput[2];
            Threeuple<string, double, string> tuple03 = new Threeuple<string, double, string>(name02, accountBalance, bankName);
            Console.WriteLine(tuple03);

        }
    }
}
