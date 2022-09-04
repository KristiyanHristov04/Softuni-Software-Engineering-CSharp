using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, VloggerInformation> myDict = new Dictionary<string, VloggerInformation>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string typeOfOperation = commands[1];
                if (typeOfOperation == "joined")
                {
                    string vloggerName = commands[0];
                    if (!myDict.ContainsKey(vloggerName))
                    {
                        VloggerInformation vloggerInfo = new VloggerInformation(0);
                        myDict.Add(vloggerName, vloggerInfo);
                    }
                }
                else if(typeOfOperation == "followed")
                {
                    string firstVlogger = commands[0];
                    string secondVlogger = commands[2];
                    if (!myDict.ContainsKey(firstVlogger) || !myDict.ContainsKey(secondVlogger))
                    {
                        continue;
                    }
                    if (firstVlogger == secondVlogger)
                    {
                        continue;
                    }

                    if (!myDict[secondVlogger].Followers.Contains(firstVlogger))
                    {
                        myDict[secondVlogger].Followers.Add(firstVlogger);
                        myDict[firstVlogger].Following++;
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {myDict.Count} vloggers in its logs.");
            string mostFamousOne = string.Empty;
            foreach (var vlogger in myDict.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following))
            {
                if (vlogger.Value.Followers.Count > 0)
                {
                    Console.WriteLine($"1. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following} following");
                    vlogger.Value.Followers.Sort();
                    for (int i = 0; i < vlogger.Value.Followers.Count; i++)
                    {
                        Console.WriteLine($"*  {vlogger.Value.Followers[i]}");
                    }
                    mostFamousOne = vlogger.Key;
                    break;
                }
                else
                {
                    Console.WriteLine($"1. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following} following");
                    mostFamousOne = vlogger.Key;
                }    
            }
            myDict.Remove(mostFamousOne);
            int counter = 2;
            foreach (var vlogger in myDict.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following} following");
                counter++;
            }
        }
    }
    class VloggerInformation
    {
        public List<string> Followers { get; set; } = new List<string>();
        public int Following { get; set; }
        public VloggerInformation(int following)
        {
            this.Following = following;
        }
    }
}
