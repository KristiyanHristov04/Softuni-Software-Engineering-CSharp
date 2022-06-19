using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();
            int sum = 0;
            int removedElement = 0;
            while (list.Count != 0)
            {
                int pokemonIndex = int.Parse(Console.ReadLine());

                int lastElement = list[list.Count - 1];
                int firstElement = list[0];

                if (pokemonIndex < 0)
                {
                    removedElement = firstElement;
                    list.RemoveAt(0);
                    list.Insert(0, lastElement);
                }
                else if (pokemonIndex > list.Count - 1)
                {
                    removedElement = lastElement;
                    list.RemoveAt(list.Count - 1);
                    list.Add(firstElement);
                }
                else
                {
                    removedElement = list[pokemonIndex];
                    list.RemoveAt(pokemonIndex);

                }
                sum += removedElement;

                for (int i = 0; i < list.Count; i++)
                {
                    int currentNumber = list[i];
                    if (currentNumber <= removedElement)
                    {
                        currentNumber += removedElement;
                        list[i] = currentNumber;
                    }
                    else
                    {
                        currentNumber -= removedElement;
                        list[i] = currentNumber;

                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}