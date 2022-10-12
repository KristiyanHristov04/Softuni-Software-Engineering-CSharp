using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int wastedFood = 0;
            while (plates.Count > 0 && guests.Count > 0)
            {
                int currentGuest = guests.Peek();
                int currentPlate = plates.Peek();
                if (currentGuest > currentPlate)
                {
                    while (currentGuest > 0)
                    {
                        currentGuest -= currentPlate;
                        if(currentGuest <= 0)
                        {
                            wastedFood += Math.Abs(currentGuest);
                        }
                        plates.Pop();
                        if (plates.Count > 0)
                        {
                            currentPlate = plates.Peek();
                        }                      
                    }
                    guests.Dequeue();
                }
                else if (currentPlate >= currentGuest)
                {
                    wastedFood += currentPlate - currentGuest;
                    plates.Pop();
                    guests.Dequeue();
                }
            }
            if (plates.Count > 0 && guests.Count == 0)
            {
                Console.WriteLine("Plates: " + String.Join(" ", plates));
            }
            else if (guests.Count > 0 && plates.Count == 0)
            {
                Console.WriteLine("Guests: " + String.Join(" ", guests));
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
