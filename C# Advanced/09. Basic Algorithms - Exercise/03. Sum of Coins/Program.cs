using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    public class Program
    {
        static void Main(string[] args)
        {
            var availableCoins = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var targetSum = Convert.ToInt32(Console.ReadLine());

            var selectedCoins = ChooseCoins(availableCoins, targetSum);
            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                if (selectedCoin.Value >= 1)
                {
                    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
                }    
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            int[] sortedCoins = coins.OrderByDescending(coin => coin).ToArray();
            Dictionary<int, int> chosenCoins = new Dictionary<int, int>();
            int currentSum = 0;
            int coinIndex = 0;
            while (currentSum != targetSum && coinIndex <sortedCoins.Length)
            {
                int currentCoinValue = sortedCoins[coinIndex];
                if (!chosenCoins.ContainsKey(currentCoinValue))
                {
                    chosenCoins.Add(currentCoinValue, 0);
                }
                int reminder = targetSum - currentSum;
                int numberOfCoins = reminder / currentCoinValue;
                if (currentSum + currentCoinValue <= targetSum)
                {
                    chosenCoins[currentCoinValue]++;
                    currentSum += currentCoinValue;
                }
                else
                {
                    coinIndex++;
                }                
            }
            if (currentSum != targetSum)
            {
                throw new InvalidOperationException("Error");
            }
            return chosenCoins;
        }
    }
}
