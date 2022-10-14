using System;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playingFieldSize = Convert.ToInt32(Console.ReadLine());
            char[,] playingField = CreateMatrix(playingFieldSize);
            MolePosition molePosition = FindMoleStartingPosition(playingField);
            SpecialLocation specialLocation01 = FindSpecialLocation(playingField, true);
            SpecialLocation specialLocation02 = FindSpecialLocation(playingField, false);
            int points = 0;

            while (points < 25)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                switch (input)
                {
                    case "up":
                        if (IsInBounds(molePosition.Row - 1, molePosition.Col, playingFieldSize))
                        {
                            if (playingField[molePosition.Row - 1, molePosition.Col] == '-')
                            {
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                playingField[molePosition.Row - 1, molePosition.Col] = 'M';
                                molePosition.Row--;
                            }
                            else if (playingField[molePosition.Row - 1, molePosition.Col] == 'S')
                            {
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                if (molePosition.Row - 1 == specialLocation01.Row && molePosition.Col == specialLocation01.Col)
                                {
                                    playingField[molePosition.Row - 1, molePosition.Col] = '-';
                                    molePosition.Row = specialLocation02.Row;
                                    molePosition.Col = specialLocation02.Col;
                                    playingField[specialLocation02.Row, specialLocation02.Col] = 'M';
                                    points -= 3;
                                }
                                else if (molePosition.Row - 1 == specialLocation02.Row && molePosition.Col == specialLocation02.Col)
                                {
                                    playingField[molePosition.Row - 1, molePosition.Col] = '-';
                                    molePosition.Row = specialLocation01.Row;
                                    molePosition.Col = specialLocation01.Col;
                                    playingField[specialLocation01.Row, specialLocation01.Col] = 'M';
                                    points -= 3;
                                }
                            }
                            else if(playingField[molePosition.Row - 1, molePosition.Col] >= '0'&&
                                    playingField[molePosition.Row - 1, molePosition.Col] <= '9')
                            {
                                points += playingField[molePosition.Row - 1, molePosition.Col] - 48;
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                playingField[molePosition.Row - 1, molePosition.Col] = 'M';
                                molePosition.Row--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "down":
                        if (IsInBounds(molePosition.Row + 1, molePosition.Col, playingFieldSize))
                        {
                            if (playingField[molePosition.Row + 1, molePosition.Col] == '-')
                            {
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                playingField[molePosition.Row + 1, molePosition.Col] = 'M';
                                molePosition.Row++;
                            }
                            else if (playingField[molePosition.Row + 1, molePosition.Col] == 'S')
                            {
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                if (molePosition.Row + 1 == specialLocation01.Row && molePosition.Col == specialLocation01.Col)
                                {
                                    playingField[molePosition.Row + 1, molePosition.Col] = '-';
                                    molePosition.Row = specialLocation02.Row;
                                    molePosition.Col = specialLocation02.Col;
                                    playingField[specialLocation02.Row, specialLocation02.Col] = 'M';
                                    points -= 3;
                                }
                                else if (molePosition.Row + 1 == specialLocation02.Row && molePosition.Col == specialLocation02.Col)
                                {
                                    playingField[molePosition.Row + 1, molePosition.Col] = '-';
                                    molePosition.Row = specialLocation01.Row;
                                    molePosition.Col = specialLocation01.Col;
                                    playingField[specialLocation01.Row, specialLocation01.Col] = 'M';
                                    points -= 3;
                                }
                            }
                            else if (playingField[molePosition.Row + 1, molePosition.Col] >= '0' &&
                                    playingField[molePosition.Row + 1, molePosition.Col] <= '9')
                            {
                                points += playingField[molePosition.Row + 1, molePosition.Col] - 48;
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                playingField[molePosition.Row + 1, molePosition.Col] = 'M';
                                molePosition.Row++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "left":
                        if (IsInBounds(molePosition.Row, molePosition.Col - 1, playingFieldSize))
                        {
                            if (playingField[molePosition.Row, molePosition.Col - 1] == '-')
                            {
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                playingField[molePosition.Row, molePosition.Col - 1] = 'M';
                                molePosition.Col--;
                            }
                            else if (playingField[molePosition.Row, molePosition.Col - 1] == 'S')
                            {
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                if (molePosition.Row == specialLocation01.Row && molePosition.Col - 1 == specialLocation01.Col)
                                {
                                    playingField[molePosition.Row, molePosition.Col - 1] = '-';
                                    molePosition.Row = specialLocation02.Row;
                                    molePosition.Col = specialLocation02.Col;
                                    playingField[specialLocation02.Row, specialLocation02.Col] = 'M';
                                    points -= 3;
                                }
                                else if (molePosition.Row == specialLocation02.Row && molePosition.Col - 1 == specialLocation02.Col)
                                {
                                    playingField[molePosition.Row, molePosition.Col - 1] = '-';
                                    molePosition.Row = specialLocation01.Row;
                                    molePosition.Col = specialLocation01.Col;
                                    playingField[specialLocation01.Row, specialLocation01.Col] = 'M';
                                    points -= 3;
                                }
                            }
                            else if (playingField[molePosition.Row, molePosition.Col - 1] >= '0' &&
                                    playingField[molePosition.Row, molePosition.Col - 1] <= '9')
                            {
                                points += playingField[molePosition.Row, molePosition.Col - 1] - 48;
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                playingField[molePosition.Row, molePosition.Col - 1] = 'M';
                                molePosition.Col--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "right":
                        if (IsInBounds(molePosition.Row, molePosition.Col + 1, playingFieldSize))
                        {
                            if (playingField[molePosition.Row, molePosition.Col + 1] == '-')
                            {
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                playingField[molePosition.Row, molePosition.Col + 1] = 'M';
                                molePosition.Col++;
                            }
                            else if (playingField[molePosition.Row , molePosition.Col + 1] == 'S')
                            {
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                if (molePosition.Row == specialLocation01.Row && molePosition.Col + 1 == specialLocation01.Col)
                                {
                                    playingField[molePosition.Row, molePosition.Col + 1] = '-';
                                    molePosition.Row = specialLocation02.Row;
                                    molePosition.Col = specialLocation02.Col;
                                    playingField[specialLocation02.Row, specialLocation02.Col] = 'M';
                                    points -= 3;
                                }
                                else if (molePosition.Row == specialLocation02.Row && molePosition.Col + 1 == specialLocation02.Col)
                                {
                                    playingField[molePosition.Row, molePosition.Col + 1] = '-';
                                    molePosition.Row = specialLocation01.Row;
                                    molePosition.Col = specialLocation01.Col;
                                    playingField[specialLocation01.Row, specialLocation01.Col] = 'M';
                                    points -= 3;
                                }
                            }
                            else if (playingField[molePosition.Row, molePosition.Col + 1] >= '0' &&
                                    playingField[molePosition.Row, molePosition.Col + 1] <= '9')
                            {
                                points += playingField[molePosition.Row, molePosition.Col + 1] - 48;
                                playingField[molePosition.Row, molePosition.Col] = '-';
                                playingField[molePosition.Row, molePosition.Col + 1] = 'M';
                                molePosition.Col++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                }
            }
            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            PrintMatrixFinalState(playingField);

        }
        static void PrintMatrixFinalState(char[,] playingField)
        {
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    Console.Write($"{playingField[row, col]}");
                }
                Console.WriteLine();
            }
        }
        static bool IsInBounds(int row, int col, int fieldSize)
        {
            return row >= 0 && row < fieldSize && col >= 0 && col < fieldSize;
        }
        static SpecialLocation FindSpecialLocation(char[,] playingField, bool isFirst)
        {
            bool isFound = false;
            bool isFirstTime = true;
            SpecialLocation specialLocation = new SpecialLocation();
            if (isFirst)
            {
                for (int row = 0; row < playingField.GetLength(0); row++)
                {
                    if (isFound)
                    {
                        break;
                    }
                    for (int col = 0; col < playingField.GetLength(1); col++)
                    {
                        if (playingField[row, col] == 'S')
                        {
                            specialLocation.Row = row;
                            specialLocation.Col = col;
                            isFound = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int row = 0; row < playingField.GetLength(0); row++)
                {
                    if (isFound)
                    {
                        break;
                    }
                    for (int col = 0; col < playingField.GetLength(1); col++)
                    {
                        if (playingField[row, col] == 'S' && !isFirstTime)
                        {
                            specialLocation.Row = row;
                            specialLocation.Col = col;
                            isFound = true;
                            break;
                        }
                        else if (playingField[row, col] == 'S' && isFirstTime)
                        {
                            isFirstTime = false;
                        }
                    }
                }
            }
            return specialLocation;
        }
        static MolePosition FindMoleStartingPosition(char[,] playingField)
        {
            MolePosition molePosition = new MolePosition();
            bool isFound = false;
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    if (playingField[row, col] == 'M')
                    {
                        molePosition.Row = row;
                        molePosition.Col = col;
                        isFound = true;
                        break;
                    }
                }
            }
            return molePosition;
        }
        static char[,] CreateMatrix(int fieldSize)
        {
            char[,] matrix = new char[fieldSize, fieldSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }
    }
    class MolePosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
    class SpecialLocation
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
