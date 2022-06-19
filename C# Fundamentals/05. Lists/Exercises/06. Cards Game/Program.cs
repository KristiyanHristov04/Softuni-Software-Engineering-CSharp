using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> player01Deck = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> player02Deck = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            while (true)
            {
                if (player01Deck[0] > player02Deck[0])
                {
                    player01Deck.Add(player02Deck[0]);
                    player01Deck.Add(player01Deck[0]);
                    player01Deck.RemoveAt(0);
                    player02Deck.RemoveAt(0);
                }
                else if(player01Deck[0] < player02Deck[0])
                {
                    player02Deck.Add(player01Deck[0]);
                    player02Deck.Add(player02Deck[0]);
                    player01Deck.RemoveAt(0);
                    player02Deck.RemoveAt(0);
                }
                else if(player01Deck[0] == player02Deck[0])
                {
                    player01Deck.RemoveAt(0);
                    player02Deck.RemoveAt(0);
                }
                if (player01Deck.Count == 0)
                {
                    break;
                }
                else if(player02Deck.Count == 0)
                {
                    break;
                }
            }
            int deck01Count = player01Deck.Count;
            int deck02Count = player02Deck.Count;
            if (deck01Count > deck02Count)
            {
                List<int> remainingCards = new List<int>();
                int sum = 0;
                for (int i = 0; i < player01Deck.Count; i++)
                {
                    sum += player01Deck[i];
                }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else if(deck01Count < deck02Count)
            {
                List<int> remainingCards = new List<int>();
                int sum = 0;
                for (int i = 0; i < player02Deck.Count; i++)
                {
                    sum += player02Deck[i];
                }
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
