using System;
using System.Linq;

namespace _02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitingPeople = Convert.ToInt32(Console.ReadLine());
            int[] lift = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int placedPeople = 0;
            for (int i = 0; i < lift.Length; i++)
            {
                if (lift[i] == 4)
                {
                    continue;
                }
                else if(lift[i] < 4)
                {
                    while (lift[i] < 4 && waitingPeople > 0)
                    {
                        lift[i]++;
                        placedPeople++;
                        waitingPeople--;
                    }
                    placedPeople = 0;
                }
            }

            bool isEmpty = false;
            for (int i = 0; i < lift.Length; i++)
            {
                if (lift[i] < 4)
                {
                    isEmpty = true;
                }
            }
            if(isEmpty && waitingPeople == 0)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if(!isEmpty && waitingPeople > 0)
            {
                Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
            }
            Console.WriteLine(String.Join(" ", lift));

        }
    }
}
