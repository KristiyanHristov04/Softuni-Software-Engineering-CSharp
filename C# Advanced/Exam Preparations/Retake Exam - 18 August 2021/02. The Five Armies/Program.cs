using System;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = Convert.ToInt32(Console.ReadLine());
            int numberOfRows = Convert.ToInt32(Console.ReadLine());
            char[][] matrix = CreateMatrix(numberOfRows);
            ArmyPosition armyPosition = FindArmyStartingPosition(matrix);
            bool isMordorReached = false;

            while (armyArmor > 0 && !isMordorReached)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = input[0];
                int orcRowSpawnLocation = Convert.ToInt32(input[1]);
                int orcColSpawnLocation = Convert.ToInt32(input[2]);
                matrix[orcRowSpawnLocation][orcColSpawnLocation] = 'O';

                switch (direction)
                {
                    case "up":
                        armyArmor--;
                        if (IsInBounds(armyPosition.Row - 1, armyPosition.Col, matrix))
                        {
                            if (matrix[armyPosition.Row - 1][armyPosition.Col] == 'O')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                armyArmor -= 2;
                                if (armyArmor <= 0)
                                {
                                    matrix[armyPosition.Row - 1][armyPosition.Col] = 'X';
                                    armyPosition.Row--;
                                }
                                else
                                {
                                    matrix[armyPosition.Row - 1][armyPosition.Col] = 'A';
                                    armyPosition.Row--;
                                }
                            }
                            else if (matrix[armyPosition.Row - 1][armyPosition.Col] == 'M')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                matrix[armyPosition.Row - 1][armyPosition.Col] = '-';
                                isMordorReached = true;
                                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                                PrintFinalStateOfMatrix(matrix);
                                return;
                            }
                            else if (matrix[armyPosition.Row - 1][armyPosition.Col] == '-')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                matrix[armyPosition.Row - 1][armyPosition.Col] = 'A';
                                armyPosition.Row--;
                            }
                        }
                        break;
                    case "down":
                        armyArmor--;
                        if (IsInBounds(armyPosition.Row + 1, armyPosition.Col, matrix))
                        {
                            if (matrix[armyPosition.Row + 1][armyPosition.Col] == 'O')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                armyArmor -= 2;
                                if (armyArmor <= 0)
                                {
                                    matrix[armyPosition.Row + 1][armyPosition.Col] = 'X';
                                    armyPosition.Row++;
                                }
                                else
                                {
                                    matrix[armyPosition.Row + 1][armyPosition.Col] = 'A';
                                    armyPosition.Row++;
                                }
                            }
                            else if (matrix[armyPosition.Row + 1][armyPosition.Col] == 'M')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                matrix[armyPosition.Row + 1][armyPosition.Col] = '-';
                                isMordorReached = true;
                                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                                PrintFinalStateOfMatrix(matrix);
                                return;
                            }
                            else if (matrix[armyPosition.Row + 1][armyPosition.Col] == '-')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                matrix[armyPosition.Row + 1][armyPosition.Col] = 'A';
                                armyPosition.Row++;
                            }
                        }
                        break;
                    case "left":
                        armyArmor--;
                        if (IsInBounds(armyPosition.Row, armyPosition.Col - 1, matrix))
                        {
                            if (matrix[armyPosition.Row][armyPosition.Col - 1] == 'O')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                armyArmor -= 2;
                                if (armyArmor <= 0)
                                {
                                    matrix[armyPosition.Row][armyPosition.Col - 1] = 'X';
                                    armyPosition.Col--;
                                }
                                else
                                {
                                    matrix[armyPosition.Row][armyPosition.Col - 1] = 'A';
                                    armyPosition.Col--;
                                }
                            }
                            else if (matrix[armyPosition.Row][armyPosition.Col - 1] == 'M')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                matrix[armyPosition.Row][armyPosition.Col - 1] = '-';
                                isMordorReached = true;
                                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                                PrintFinalStateOfMatrix(matrix);
                                return;
                            }
                            else if (matrix[armyPosition.Row][armyPosition.Col - 1] == '-')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                matrix[armyPosition.Row][armyPosition.Col - 1] = 'A';
                                armyPosition.Col--;
                            }
                        }
                        break;
                    case "right":
                        armyArmor--;
                        if (IsInBounds(armyPosition.Row, armyPosition.Col + 1, matrix))
                        {
                            if (matrix[armyPosition.Row][armyPosition.Col + 1] == 'O')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                armyArmor -= 2;
                                if (armyArmor <= 0)
                                {
                                    matrix[armyPosition.Row][armyPosition.Col + 1] = 'X';
                                    armyPosition.Col++;
                                }
                                else
                                {
                                    matrix[armyPosition.Row][armyPosition.Col + 1] = 'A';
                                    armyPosition.Col++;
                                }
                            }
                            else if (matrix[armyPosition.Row][armyPosition.Col + 1] == 'M')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                matrix[armyPosition.Row][armyPosition.Col + 1] = '-';
                                isMordorReached = true;
                                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                                PrintFinalStateOfMatrix(matrix);
                                return;
                            }
                            else if (matrix[armyPosition.Row][armyPosition.Col + 1] == '-')
                            {
                                matrix[armyPosition.Row][armyPosition.Col] = '-';
                                matrix[armyPosition.Row][armyPosition.Col + 1] = 'A';
                                armyPosition.Col++;
                            }
                        }
                        break;
                }
            }
            if (armyArmor <= 0)
            {
                Console.WriteLine($"The army was defeated at {armyPosition.Row};{armyPosition.Col}.");
                matrix[armyPosition.Row][armyPosition.Col] = 'X';
            }
            PrintFinalStateOfMatrix(matrix);
        }
        static void PrintFinalStateOfMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
                }
                Console.WriteLine();
            }
        }
        static bool IsInBounds(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
        static ArmyPosition FindArmyStartingPosition(char[][] matrix)
        {
            bool isFound = false;
            ArmyPosition armyPosition = new ArmyPosition();
            for (int row = 0; row < matrix.Length; row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        armyPosition.Row = row;
                        armyPosition.Col = col;
                        isFound = true;
                        break;
                    }
                }
            }
            return armyPosition;
        }
        static char[][] CreateMatrix(int numberOfRows)
        {
            char[][] matrix = new char[numberOfRows][];
            for (int row = 0; row < matrix.Length; row++)
            {
                string input = Console.ReadLine();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
            return matrix;
        }
    }
    class ArmyPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
