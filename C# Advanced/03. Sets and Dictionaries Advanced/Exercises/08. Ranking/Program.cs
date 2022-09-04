using System;
using System.Collections.Generic;
using System.Linq;
namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestNameAndPassword = new Dictionary<string, string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }
                string[] tokens = input.Split(':',StringSplitOptions.RemoveEmptyEntries);
                string contestName = tokens[0];
                string contestPassword = tokens[1];
                if (!contestNameAndPassword.ContainsKey(contestName))
                {
                    contestNameAndPassword.Add(contestName, contestPassword);
                }
            }

            Dictionary<string, CandidateInformation> myDictionary = new Dictionary<string, CandidateInformation>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }
                string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contestName = tokens[0];
                string contestPassword = tokens[1];
                string username = tokens[2];
                int points = Convert.ToInt32(tokens[3]);

                if (contestNameAndPassword.ContainsKey(contestName))
                {
                    if (contestNameAndPassword[contestName] == contestPassword)
                    {
                        if (!myDictionary.ContainsKey(username))
                        {
                            CandidateInformation candInfo = new CandidateInformation();
                            myDictionary.Add(username, candInfo);
                            myDictionary[username].Contests.Add(contestName, points);
                        }
                        else
                        {
                            if (myDictionary[username].Contests.ContainsKey(contestName))
                            { 
                                if (myDictionary[username].Contests[contestName] < points)
                                {
                                    myDictionary[username].Contests[contestName] = points;
                                }
                            }
                            else
                            {
                                myDictionary[username].Contests.Add(contestName, points);
                            }
                        }
                    }
                }
            }

            string bestCandidate = string.Empty;
            int bestPoints = int.MinValue;

            foreach (var candidate in myDictionary)
            {
                int currPoints = 0;
                foreach (var item in candidate.Value.Contests)
                {
                    currPoints += item.Value;
                }
                if (currPoints > bestPoints)
                {
                    bestPoints = currPoints;
                    bestCandidate = candidate.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var candidate in myDictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidate.Key);
                foreach (var item in candidate.Value.Contests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
    class CandidateInformation
    {
        public Dictionary<string, int> Contests { get; set; } = new Dictionary<string, int>();
    }
}
