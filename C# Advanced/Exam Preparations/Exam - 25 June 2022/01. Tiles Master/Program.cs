using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> furnitures = new Dictionary<string, int>()
            {
                ["Sink"] = 0,
                ["Oven"] = 0,
                ["Countertop"] = 0,
                ["Wall"] = 0,
                ["Floor"] = 0
            };
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> grayTiles = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (whiteTiles.Count > 0 && grayTiles.Count > 0)
            {
                int currentWhiteTile = whiteTiles.Peek();
                int currentGrayTile = grayTiles.Peek();
                int totalAreaSum = 0;
                if (currentWhiteTile == currentGrayTile)
                {
                    totalAreaSum = currentWhiteTile + currentGrayTile;
                    switch (totalAreaSum)
                    {
                        case 40:
                            furnitures["Sink"]++;
                            whiteTiles.Pop();
                            grayTiles.Dequeue();
                            break;
                        case 50:
                            furnitures["Oven"]++;
                            whiteTiles.Pop();
                            grayTiles.Dequeue();
                            break;
                        case 60:
                            furnitures["Countertop"]++;
                            whiteTiles.Pop();
                            grayTiles.Dequeue();
                            break;
                        case 70:
                            furnitures["Wall"]++;
                            whiteTiles.Pop();
                            grayTiles.Dequeue();
                            break;
                        default:
                            furnitures["Floor"]++;
                            whiteTiles.Pop();
                            grayTiles.Dequeue();
                            break;
                    }
                }
                else
                {
                    whiteTiles.Pop();
                    currentWhiteTile /= 2;
                    whiteTiles.Push(currentWhiteTile);
                    grayTiles.Dequeue();
                    grayTiles.Enqueue(currentGrayTile);
                }
            }
            if (whiteTiles.Count > 0)
            {
                Console.WriteLine("White tiles left: " + String.Join(", ", whiteTiles));
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (grayTiles.Count > 0)
            {
                Console.WriteLine("Grey tiles left: " + String.Join(", ", grayTiles));
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }
            foreach (var furniture in furnitures.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (furniture.Value > 0)
                {
                    Console.WriteLine($"{furniture.Key}: {furniture.Value}");
                }
            }
        }
    }
}
