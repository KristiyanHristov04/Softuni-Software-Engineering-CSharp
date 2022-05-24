using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            //06. Building
            int floors = Convert.ToInt32(Console.ReadLine());
            int rooms = Convert.ToInt32(Console.ReadLine());
            for (int floor = floors; floor > 0; floor--)
            {
                for (int room = 0; room < rooms; room++)
                {
                    if (room <= rooms)
                    {
                        if (floor == floors)
                        {
                            Console.Write($"L{floor}{room} ");

                        }
                        if (floor % 2 == 0 && floor != floors)
                        {
                            Console.Write($"O{floor}{room} ");
                        }
                        else if(floor % 2 != 0 && floor != floors)
                        {
                            Console.Write($"A{floor}{room} ");
                        }
                        
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
