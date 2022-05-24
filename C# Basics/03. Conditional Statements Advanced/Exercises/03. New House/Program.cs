using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFlower = Console.ReadLine();
            int numberOfFlowers = Convert.ToInt32(Console.ReadLine());
            int budget = Convert.ToInt32(Console.ReadLine());
            double totalPrice = 0;
            double leftMoney = 0;
            if (typeOfFlower == "Roses")
            {
                if (numberOfFlowers > 80)
                {
                    totalPrice = numberOfFlowers * 5;
                    totalPrice = totalPrice - (totalPrice * 0.10);
                    if (budget >= totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} " +
                            $"Roses and {leftMoney:f2} leva left.");
                    }
                    else if (budget < totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):f2}" +
                        " leva more.");
                    }
                }
                else if (numberOfFlowers <= 80)
                {
                    totalPrice = numberOfFlowers * 5;
                    if (budget >= totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} " +
                            $"Roses and {leftMoney:f2} leva left.");
                    }
                    else if (budget < totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):f2}" +
                        " leva more.");
                    }

                }
            }
            else if (typeOfFlower == "Dahlias")
            {
                if (numberOfFlowers > 90)
                {
                    totalPrice = numberOfFlowers * 3.80;
                    totalPrice = totalPrice - (totalPrice * 0.15);
                    if (budget >= totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} " +
                            $"Dahlias and {leftMoney:f2} leva left.");
                    }
                    else if (budget < totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):f2}" +
                        " leva more.");
                    }
                }
                else if (numberOfFlowers <= 90)
                {
                    totalPrice = numberOfFlowers * 3.80;
                    if (budget >= totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} " +
                            $"Dahlias and {leftMoney:f2} leva left.");
                    }
                    else if (budget < totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):f2}" +
                        " leva more.");
                    }

                }
            }
            else if (typeOfFlower == "Tulips")
            {
                if (numberOfFlowers > 80)
                {
                    totalPrice = numberOfFlowers * 2.80;
                    totalPrice = totalPrice - (totalPrice * 0.15);
                    if (budget >= totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} " +
                            $"Tulips and {leftMoney:f2} leva left.");
                    }
                    else if (budget < totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):f2}" +
                        " leva more.");
                    }
                }
                else if (numberOfFlowers <= 80)
                {
                    totalPrice = numberOfFlowers * 2.80;
                    if (budget >= totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} " +
                            $"Tulips and {leftMoney:f2} leva left.");
                    }
                    else if (budget < totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):f2}" +
                        " leva more.");
                    }

                }
            }
            else if (typeOfFlower == "Narcissus")
            {
                if (numberOfFlowers >= 120)
                {
                    totalPrice = numberOfFlowers * 3;
                    if (budget >= totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} " +
                            $"Narcissus and {leftMoney:f2} leva left.");
                    }
                    else if (budget < totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):f2}" +
                        " leva more.");
                    }
                }
                else if (numberOfFlowers < 120)
                {
                    totalPrice = numberOfFlowers * 3;
                    totalPrice = totalPrice + (totalPrice * 0.15);
                    if (budget >= totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} " +
                            $"Narcissus and {leftMoney:f2} leva left.");
                    }
                    else if (budget < totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):f2}" +
                        " leva more.");
                    }

                }
            }
            else if (typeOfFlower == "Gladiolus")
            {
                if (numberOfFlowers >= 80)
                {
                    totalPrice = numberOfFlowers * 2.50;
                    if (budget >= totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} " +
                            $"Gladiolus and {leftMoney:f2} leva left.");
                    }
                    else if (budget < totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):f2}" +
                        " leva more.");
                    }
                }
                else if (numberOfFlowers < 80)
                {
                    totalPrice = numberOfFlowers * 2.50;
                    totalPrice = totalPrice + (totalPrice * 0.20);
                    if (budget >= totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} " +
                            $"Gladiolus and {leftMoney:f2} leva left.");
                    }
                    else if (budget < totalPrice)
                    {
                        leftMoney = budget - totalPrice;
                        Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):f2}" +
                        " leva more.");
                    }
                }
            }
        }
    }
}