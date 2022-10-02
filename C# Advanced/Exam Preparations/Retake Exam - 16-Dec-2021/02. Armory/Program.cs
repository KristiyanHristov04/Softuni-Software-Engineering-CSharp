using System;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armorySize = Convert.ToInt32(Console.ReadLine());
            char[,] armory = CreateArmory(armorySize);
            ArmyOfficerPosition officerPosition = ArmyOfficerPos(armory);
            MirrorPosition mirrorPosition01 = MirrorPos01(armory);
            MirrorPosition mirrorPosition02 = MirrorPos02(armory);
            int collectedMoney = 0;
            bool isOutOfArmory = false;
            while (collectedMoney < 65 && !isOutOfArmory)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "up":
                        if (IsInBounds(officerPosition.Row - 1, officerPosition.Col, armorySize))
                        {
                            collectedMoney = DoesEverything(armory, officerPosition, mirrorPosition01, mirrorPosition02, collectedMoney, -1, 0);
                        }
                        else
                        {
                            armory[officerPosition.Row, officerPosition.Col] = '-';
                            isOutOfArmory = true;
                            break;
                        }
                        break;
                    case "down":
                        if (IsInBounds(officerPosition.Row + 1, officerPosition.Col, armorySize))
                        {
                            collectedMoney = DoesEverything(armory, officerPosition, mirrorPosition01, mirrorPosition02, collectedMoney, 1, 0);
                        }
                        else
                        {
                            armory[officerPosition.Row, officerPosition.Col] = '-';
                            isOutOfArmory = true;
                            break;
                        }
                        break;
                    case "left":
                        if (IsInBounds(officerPosition.Row, officerPosition.Col - 1, armorySize))
                        {
                            collectedMoney = DoesEverything(armory, officerPosition, mirrorPosition01, mirrorPosition02, collectedMoney, 0, -1);
                        }
                        else
                        {
                            armory[officerPosition.Row, officerPosition.Col] = '-';
                            isOutOfArmory = true;
                            break;
                        }
                        break;
                    case "right":
                        if (IsInBounds(officerPosition.Row, officerPosition.Col + 1, armorySize))
                        {
                            collectedMoney = DoesEverything(armory, officerPosition, mirrorPosition01, mirrorPosition02, collectedMoney, 0, 1);
                        }
                        else
                        {
                            armory[officerPosition.Row, officerPosition.Col] = '-';
                            isOutOfArmory = true;
                            break;
                        }
                        break;
                }
            }
            if (isOutOfArmory)
            {
                Console.WriteLine("I do not need more swords!");
            }
            if (collectedMoney >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {collectedMoney} gold coins.");
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write($"{armory[row, col]}");
                }
                Console.WriteLine();
            }
        }
        static char[,] CreateArmory(int armorySize)
        {
            char[,] armory = new char[armorySize, armorySize];
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                string armoryElements = Console.ReadLine();
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    armory[row, col] = armoryElements[col];
                }
            }
            return armory;
        }
        static ArmyOfficerPosition ArmyOfficerPos(char[,] armory)
        {
            ArmyOfficerPosition position = new ArmyOfficerPosition();
            bool flag = false;
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                if (flag)
                {
                    break;
                }
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row, col] == 'A')
                    {
                        position.Row = row;
                        position.Col = col;
                        flag = true;
                        break;
                    }
                }
            }
            return position;
        }
        static bool IsInBounds(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
        static MirrorPosition MirrorPos01(char[,] armory)
        {
            MirrorPosition mirrorPosition01 = new MirrorPosition();
            bool flag = false;
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                if (flag){
                    break;
                }
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row, col] == 'M'){
                        mirrorPosition01.Row = row;
                        mirrorPosition01.Col = col;
                        flag = true;
                        break;
                    }
                }
            }
            return mirrorPosition01;
        }
        static MirrorPosition MirrorPos02(char[,] armory)
        {
            MirrorPosition mirrorPosition02 = new MirrorPosition();
            bool flag = false;
            bool isFirstTime = true;
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                if (flag){
                    break;
                }
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row, col] == 'M' && !isFirstTime){
                        mirrorPosition02.Row = row;
                        mirrorPosition02.Col = col;
                        flag = true;
                        break;
                    }
                    else if (armory[row, col] == 'M' && isFirstTime){
                        isFirstTime = false;
                    }
                }
            }
            return mirrorPosition02;
        }
        static int DoesEverything(char[,] armory, ArmyOfficerPosition officerPosition, MirrorPosition mirrorPosition01, MirrorPosition mirrorPosition02, int collectedMoney, int rowValue, int colValue)
        {
            if (armory[officerPosition.Row + rowValue, officerPosition.Col + colValue] == '-')
            {
                armory[officerPosition.Row, officerPosition.Col] = '-';
                armory[officerPosition.Row + rowValue, officerPosition.Col + colValue] = 'A';
                officerPosition.Row += rowValue;
                officerPosition.Col += colValue;
            }
            else if (armory[officerPosition.Row + rowValue, officerPosition.Col + colValue] == 'M')
            {
                if (officerPosition.Row + rowValue== mirrorPosition01.Row && officerPosition.Col + colValue == mirrorPosition01.Col)
                {
                    armory[officerPosition.Row, officerPosition.Col] = '-';
                    armory[officerPosition.Row + rowValue, officerPosition.Col + colValue] = '-';
                    armory[mirrorPosition02.Row, mirrorPosition02.Col] = 'A';
                    officerPosition.Row = mirrorPosition02.Row;
                    officerPosition.Col = mirrorPosition02.Col;
                }
                else if (officerPosition.Row + rowValue== mirrorPosition02.Row && officerPosition.Col + colValue == mirrorPosition02.Col)
                {
                    armory[officerPosition.Row, officerPosition.Col] = '-';
                    armory[officerPosition.Row + rowValue, officerPosition.Col + colValue] = '-';
                    armory[mirrorPosition01.Row, mirrorPosition01.Col] = 'A';
                    officerPosition.Row = mirrorPosition01.Row;
                    officerPosition.Col = mirrorPosition01.Col;
                }
            }
            else if (armory[officerPosition.Row + rowValue, officerPosition.Col + colValue] >= '0' && armory[officerPosition.Row + rowValue, officerPosition.Col + colValue] <= '9')
            {
                armory[officerPosition.Row, officerPosition.Col] = '-';
                collectedMoney += armory[officerPosition.Row + rowValue, officerPosition.Col + colValue] - 48;
                armory[officerPosition.Row + rowValue, officerPosition.Col + colValue] = 'A';
                officerPosition.Row += rowValue;
                officerPosition.Col += colValue;
            }
            return collectedMoney;
        }
    }
    class ArmyOfficerPosition {
        public int Row { get; set; }
        public int Col { get; set; }
    }
    class MirrorPosition{
        public int Row { get; set; }
        public int Col { get; set; }
    } 
}