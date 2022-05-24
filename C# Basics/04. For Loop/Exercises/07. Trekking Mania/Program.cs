using System;

namespace Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            //07. Trekking Mania
            int numberOfGroups = Convert.ToInt32(Console.ReadLine());
            int totalPeople = 0;
            double peopleMusala = 0;
            double peopleMonblan = 0;
            double peopleKilimindjaro = 0;
            double peopleK2 = 0;
            double peopleEverest = 0;
            for (int i = 1; i <= numberOfGroups; i++)
            {
                int howManyPeopleInAGroup = Convert.ToInt32(Console.ReadLine());
                if (howManyPeopleInAGroup <= 5)
                {
                    peopleMusala += howManyPeopleInAGroup;
                    totalPeople += howManyPeopleInAGroup;
                }
                else if(howManyPeopleInAGroup >= 6 && howManyPeopleInAGroup <= 12)
                {
                    peopleMonblan += howManyPeopleInAGroup;
                    totalPeople += howManyPeopleInAGroup;
                }   
                else if(howManyPeopleInAGroup >= 13 && howManyPeopleInAGroup <= 25)
                {
                    peopleKilimindjaro += howManyPeopleInAGroup;
                    totalPeople += howManyPeopleInAGroup;
                }
                else if (howManyPeopleInAGroup >= 26 && howManyPeopleInAGroup <= 40)
                {
                    peopleK2 += howManyPeopleInAGroup;
                    totalPeople += howManyPeopleInAGroup;
                }
                else if(howManyPeopleInAGroup >= 41)
                {
                    peopleEverest += howManyPeopleInAGroup;
                    totalPeople += howManyPeopleInAGroup;
                }
            }
            //Console.WriteLine(totalPeople);            
            Console.WriteLine($"{(peopleMusala / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(peopleMonblan / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(peopleKilimindjaro / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(peopleK2 / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(peopleEverest / totalPeople) * 100:f2}%");
        }
    }
}
