using System;
using System.Collections.Generic;
namespace _03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PieceInformation> collection = new Dictionary<string, PieceInformation>();
            int numberOfPieces = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] pieces = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string piece = pieces[0];
                string composer = pieces[1];
                string key = pieces[2];
                PieceInformation currPieceInformation = new PieceInformation(composer, key);
                collection.Add(piece, currPieceInformation);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                string[] commands = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];
                string currentPiece = commands[1];
                switch (mainCommand)
                {
                    case "Add":
                        if (collection.ContainsKey(currentPiece))
                        {
                            Console.WriteLine($"{currentPiece} is already in the collection!");
                        }
                        else
                        {
                            string composer = commands[2];
                            string key = commands[3];
                            PieceInformation currPieceInformation = new PieceInformation(composer, key);
                            collection.Add(currentPiece, currPieceInformation);
                            Console.WriteLine($"{currentPiece} by {composer} in {key} added to the collection!");
                        }
                        break;
                    case "Remove":
                        if (collection.ContainsKey(currentPiece))
                        {
                            collection.Remove(currentPiece);
                            Console.WriteLine($"Successfully removed {currentPiece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {currentPiece} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        string newKey = commands[2];
                        if (collection.ContainsKey(currentPiece))
                        {
                            collection[currentPiece].Key = newKey;
                            Console.WriteLine($"Changed the key of {currentPiece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {currentPiece} does not exist in the collection.");
                        }
                        break;
                }
            }
            foreach (var piece in collection)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
        class PieceInformation
        {
            public string Composer { get; set; }
            public string Key { get; set; }
            public PieceInformation(string composer, string key)
            {
                this.Composer = composer; 
                this.Key = key;
            }
        }
    }
}
