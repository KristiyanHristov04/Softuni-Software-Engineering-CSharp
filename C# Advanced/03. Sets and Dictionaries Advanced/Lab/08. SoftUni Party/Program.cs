using System;
using System.Collections.Generic;
using System.Linq;
namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> didntWentToParty = new HashSet<string>();
            HashSet<string> wentToParty = new HashSet<string>();

            bool isParty = false;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                if (input == "PARTY")
                {
                    isParty = true;
                }

                if(!isParty)
                {
                    didntWentToParty.Add(input);
                }
                if (isParty)
                {
                    if (didntWentToParty.Contains(input))
                    {
                        didntWentToParty.Remove(input);
                        wentToParty.Add(input);
                    }
                }
                
            }

            Console.WriteLine(didntWentToParty.Count);
            foreach (var person in didntWentToParty)
            {
                char[] ch = person.ToCharArray();
                if (char.IsDigit(ch[0]))
                {
                    Console.WriteLine(person);
                }
            }
            foreach (var person in didntWentToParty)
            {
                char[] ch = person.ToCharArray();
                if (char.IsLetter(ch[0]))
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}
