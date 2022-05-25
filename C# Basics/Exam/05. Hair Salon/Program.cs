using System;

namespace Hair_Salon
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hair Salon
            int neededMoneyForTheDay = Convert.ToInt32(Console.ReadLine());
            string input = Console.ReadLine();
            int collectedMoney = 0;
            while (input != "closed")
            {
                if (input == "color")
                {
                    
                }
                else
                {
                    if (input == "haircut")
                    {
                        input = Console.ReadLine();
                        if (input == "mens" && collectedMoney < neededMoneyForTheDay)
                        {
                            collectedMoney += 15;
                            if (collectedMoney >= neededMoneyForTheDay)
                            {
                                break;
                            }
                            else
                            {
                                input = Console.ReadLine();
                            }
                            
                        }
                        else if (input == "ladies" && collectedMoney < neededMoneyForTheDay)
                        {
                            collectedMoney += 20;
                            if (collectedMoney >= neededMoneyForTheDay)
                            {
                                break;
                            }
                            else
                            {
                                input = Console.ReadLine();
                            }
                            
                        }
                        else if (input == "kids" && collectedMoney < neededMoneyForTheDay)
                        {
                            collectedMoney += 10;
                            if (collectedMoney >= neededMoneyForTheDay)
                            {
                                break;
                            }
                            else
                            {
                                input = Console.ReadLine();
                            }
                            
                        }
                    }
                }
                

                if (input == "closed")
                {
                    break;
                }
                               
                if (input == "color")
                {
                    
                }
                else
                {
                    
                }

                if (collectedMoney >= neededMoneyForTheDay)
                {
                    break;
                }
                
                if (input == "color")
                {
                    string color = Console.ReadLine();
                    if (color == "touch up" && collectedMoney < neededMoneyForTheDay)
                    {
                        collectedMoney += 20;
                        input = Console.ReadLine();
                    }
                    else if (color == "full color" && collectedMoney < neededMoneyForTheDay)
                    {
                        collectedMoney += 30;
                        input = Console.ReadLine();
                    }
                }                                
                
            }
            if (collectedMoney >= neededMoneyForTheDay)
            {
                Console.WriteLine("You have reached your target for the day!");
                Console.WriteLine($"Earned money: {collectedMoney}lv.");
            }
            else if(collectedMoney < neededMoneyForTheDay)
            {
                Console.WriteLine($"Target not reached! You need {neededMoneyForTheDay - collectedMoney}lv. more.");
                Console.WriteLine($"Earned money: {collectedMoney}lv.");
            }
           
        }
    }
}
