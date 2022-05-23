using System;

namespace Gaming_store
{
    class Program
    {
        static void Main(string[] args)
        {
            //03. Gaming Store
            double balance = Convert.ToDouble(Console.ReadLine());
            string input = Console.ReadLine();
            double totalSpendMoney = 0;
            while (input != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4":
                        if (balance < 39.99)
                        {
                            Console.WriteLine("Too Expensive");
                            input = Console.ReadLine();
                        }
                        else
                        {
                            balance -= 39.99;
                            Console.WriteLine("Bought OutFall 4");
                            totalSpendMoney += 39.99;
                            input = Console.ReadLine();
                        }

                        if (balance <= 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                        break;

                    case "CS: OG":
                        if (balance < 15.99)
                        {
                            Console.WriteLine("Too Expensive");
                            input = Console.ReadLine();
                        }
                        else
                        {
                            balance -= 15.99;
                            Console.WriteLine("Bought CS: OG");
                            totalSpendMoney += 15.99;
                            input = Console.ReadLine();
                        }

                        if (balance <= 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                        break;

                    case "Zplinter Zell":
                        if (balance < 19.99)
                        {
                            Console.WriteLine("Too Expensive");
                            input = Console.ReadLine();
                        }
                        else
                        {
                            balance -= 19.99;
                            Console.WriteLine("Bought Zplinter Zell");
                            totalSpendMoney += 19.99;
                            input = Console.ReadLine();
                        }

                        if (balance <= 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                        break;

                    case "Honored 2":
                        if (balance < 59.99)
                        {
                            Console.WriteLine("Too Expensive");
                            input = Console.ReadLine();
                        }
                        else
                        {
                            balance -= 59.99;
                            Console.WriteLine("Bought Honored 2");
                            totalSpendMoney += 59.99;
                            input = Console.ReadLine();
                        }

                        if (balance <= 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                        break;

                    case "RoverWatch":
                        if (balance < 29.99)
                        {
                            Console.WriteLine("Too Expensive");
                            input = Console.ReadLine();
                        }
                        else
                        {
                            balance -= 29.99;
                            Console.WriteLine("Bought RoverWatch");
                            totalSpendMoney += 29.99;
                            input = Console.ReadLine();
                        }

                        if (balance <= 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                        break;

                    case "RoverWatch Origins Edition":
                        if (balance < 39.99)
                        {
                            Console.WriteLine("Too Expensive");
                            input = Console.ReadLine();
                        }
                        else
                        {
                            balance -= 39.99;
                            Console.WriteLine("Bought RoverWatch Origins Edition");
                            totalSpendMoney += 39.99;
                            input = Console.ReadLine();
                        }

                        if (balance <= 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                        break;

                    default:
                        Console.WriteLine("Not Found");
                        input = Console.ReadLine();
                        break;
                }
            }
            if (input == "Game Time")
            {
                Console.WriteLine($"Total spent: ${totalSpendMoney:f2}. Remaining: ${balance:f2}");
            }
        }
    }
}
