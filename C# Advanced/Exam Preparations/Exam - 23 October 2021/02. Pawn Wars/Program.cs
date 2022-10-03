using System;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] chessBoard = new char[8, 8];
            chessBoard = FillChessBoardWithPawns(chessBoard);
            PawnPosition whitePawnPos = WhitePawnPosition(chessBoard);
            PawnPosition blackPawnPos = BlackPawnPosition(chessBoard);
            bool isWhiteTurn = true;
            while (true)
            {
                if (isWhiteTurn)
                {
                    isWhiteTurn = false;
                    if (IsInBounds(whitePawnPos.Row - 1, whitePawnPos.Col - 1) && chessBoard[whitePawnPos.Row - 1, whitePawnPos.Col - 1] == 'b')
                    {
                        //Hit black pawn.
                        chessBoard[whitePawnPos.Row, whitePawnPos.Col] = '-';
                        chessBoard[whitePawnPos.Row - 1, whitePawnPos.Col - 1] = 'w';
                        whitePawnPos.Row--;
                        whitePawnPos.Col--;
                        string boardPosition = ReturnBoardPosition(whitePawnPos.Row, whitePawnPos.Col);
                        Console.WriteLine($"Game over! White capture on {boardPosition}.");
                        return;
                    }
                    else if (IsInBounds(whitePawnPos.Row - 1, whitePawnPos.Col + 1) && chessBoard[whitePawnPos.Row - 1, whitePawnPos.Col + 1] == 'b')
                    {
                        //Hit black pawn.
                        chessBoard[whitePawnPos.Row, whitePawnPos.Col] = '-';
                        chessBoard[whitePawnPos.Row - 1, whitePawnPos.Col + 1] = 'w';
                        whitePawnPos.Row--;
                        whitePawnPos.Col++;
                        string boardPosition = ReturnBoardPosition(whitePawnPos.Row, whitePawnPos.Col);
                        Console.WriteLine($"Game over! White capture on {boardPosition}.");
                        return;
                    }
                    else
                    {
                        //Continue forward.
                        chessBoard[whitePawnPos.Row, whitePawnPos.Col] = '-';
                        chessBoard[whitePawnPos.Row - 1, whitePawnPos.Col] = 'w';
                        whitePawnPos.Row--;
                        if (whitePawnPos.Row == 0)
                        {
                            //Promote a queen.
                            string boardPosition = ReturnBoardPosition(whitePawnPos.Row, whitePawnPos.Col);
                            Console.WriteLine($"Game over! White pawn is promoted to a queen at {boardPosition}.");
                            return;
                        }
                    }
                }
                else if (!isWhiteTurn)
                {
                    isWhiteTurn = true;
                    if (IsInBounds(blackPawnPos.Row + 1, blackPawnPos.Col - 1) && chessBoard[blackPawnPos.Row + 1, blackPawnPos.Col - 1] == 'w')
                    {
                        //Hit white pawn.
                        chessBoard[blackPawnPos.Row, blackPawnPos.Col] = '-';
                        chessBoard[blackPawnPos.Row + 1, blackPawnPos.Col - 1] = 'b';
                        blackPawnPos.Row++;
                        blackPawnPos.Col--;
                        string boardPosition = ReturnBoardPosition(blackPawnPos.Row, blackPawnPos.Col);
                        Console.WriteLine($"Game over! Black capture on {boardPosition}.");
                        return;
                    }
                    else if (IsInBounds(blackPawnPos.Row + 1, blackPawnPos.Col + 1) && chessBoard[blackPawnPos.Row + 1, blackPawnPos.Col + 1] == 'w')
                    {
                        //Hit black pawn.
                        chessBoard[blackPawnPos.Row, blackPawnPos.Col] = '-';
                        chessBoard[blackPawnPos.Row + 1, blackPawnPos.Col + 1] = 'b';
                        blackPawnPos.Row++;
                        blackPawnPos.Col++;
                        string boardPosition = ReturnBoardPosition(blackPawnPos.Row, blackPawnPos.Col);
                        Console.WriteLine($"Game over! Black capture on {boardPosition}.");
                        return;
                    }
                    else
                    {
                        //Continue forward.
                        chessBoard[blackPawnPos.Row, blackPawnPos.Col] = '-';
                        chessBoard[blackPawnPos.Row + 1, blackPawnPos.Col] = 'b';
                        blackPawnPos.Row++;
                        if (blackPawnPos.Row == 7)
                        {
                            //Promote a queen.
                            string boardPosition = ReturnBoardPosition(blackPawnPos.Row, blackPawnPos.Col);
                            Console.WriteLine($"Game over! Black pawn is promoted to a queen at {boardPosition}.");
                            return;
                        }
                    }
                }
            }

        }
        static char[,] FillChessBoardWithPawns(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = input[col];
                }
            }
            return chessBoard;
        }
        static PawnPosition WhitePawnPosition(char[,] chessboard)
        {
            PawnPosition position = new PawnPosition();
            bool isFound = false;
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    if (chessboard[row, col] == 'w')
                    {
                        position.Row = row;
                        position.Col = col;
                        isFound = true;
                        break;
                    }
                }
            }
            return position;
        }
        static PawnPosition BlackPawnPosition(char[,] chessboard)
        {
            PawnPosition position = new PawnPosition();
            bool isFound = false;
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    if (chessboard[row, col] == 'b')
                    {
                        position.Row = row;
                        position.Col = col;
                        isFound = true;
                        break;
                    }
                }
            }
            return position;
        }
        static string ReturnBoardPosition(int row, int col)
        {
            string boardPosition = string.Empty;
            switch (col)
            {
                case 0:
                    boardPosition += "a";
                    break;
                case 1:
                    boardPosition += "b";
                    break;
                case 2:
                    boardPosition += "c";
                    break;
                case 3:
                    boardPosition += "d";
                    break;
                case 4:
                    boardPosition += "e";
                    break;
                case 5:
                    boardPosition += "f";
                    break;
                case 6:
                    boardPosition += "g";
                    break;
                case 7:
                    boardPosition += "h";
                    break;
            }
            switch (row)
            {
                case 0:
                    boardPosition += 8;
                    break;
                case 1:
                    boardPosition += 7;
                    break;
                case 2:
                    boardPosition += 6;
                    break;
                case 3:
                    boardPosition += 5;
                    break;
                case 4:
                    boardPosition += 4;
                    break;
                case 5:
                    boardPosition += 3;
                    break;
                case 6:
                    boardPosition += 2;
                    break;
                case 7:
                    boardPosition += 1;
                    break;
            }          
            return boardPosition;
        }
        static bool IsInBounds(int row, int col)
        {
            return row >= 0 && row <= 7 && col >= 0 && col <= 7;
        }
    }
    class PawnPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
