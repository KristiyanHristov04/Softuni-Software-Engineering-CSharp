using System;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentPokePower = Convert.ToInt32(Console.ReadLine());
            int originalPokePower = currentPokePower;
            int distanceTargets = Convert.ToInt32(Console.ReadLine());
            int exhaustionFactor = Convert.ToInt32(Console.ReadLine());
            int slainEnimies = 0;

            if (currentPokePower < distanceTargets)
            {
                Console.WriteLine(currentPokePower);
                Console.WriteLine(slainEnimies);
            }
            else
            {
                while (currentPokePower >= distanceTargets)
                {
                    currentPokePower -= distanceTargets;
                    slainEnimies++;
                    if (currentPokePower == originalPokePower / 2 && exhaustionFactor != 0)
                    {
                        currentPokePower /= exhaustionFactor;
                    }
                }
            }            
            Console.WriteLine(currentPokePower);
            Console.WriteLine(slainEnimies);
        }
    }
}
