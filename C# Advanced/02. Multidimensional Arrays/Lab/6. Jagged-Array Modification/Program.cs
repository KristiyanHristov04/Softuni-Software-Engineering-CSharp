using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int jaggedArrayRows = Convert.ToInt32(Console.ReadLine());
            int[][] jaggedArray = new int[jaggedArrayRows][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] jaggedArrayElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[row] = new int[jaggedArrayElements.Length];
                for (int col = 0; col < jaggedArrayElements.Length; col++)
                {
                    jaggedArray[row][col] = jaggedArrayElements[col];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] commands = input.Split();
                string mainCommand = commands[0];
                int row = Convert.ToInt32(commands[1]);
                int col = Convert.ToInt32(commands[2]);
                int value = Convert.ToInt32(commands[3]);
                switch (mainCommand)
                {
                    case "Add":
                        if (row < jaggedArrayRows && col < jaggedArrayRows && row >= 0 && col >= 0)
                        {
                            jaggedArray[row][col] += value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        
                        break;
                    case "Subtract":
                        if (row < jaggedArrayRows && col < jaggedArrayRows && row >= 0 && col >= 0)
                        {
                            jaggedArray[row][col] -= value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }                      
                        break;
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray.Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
