using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Football_Team_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = tokens[0];
                string teamName = tokens[1];
                try
                {
                    switch (mainCommand)
                    {
                        case "Team":
                            Team newTeam = new Team(teamName);
                            teams.Add(newTeam);
                            break;
                        case "Add":
                            Team team = teams.FirstOrDefault(t => t.Name == teamName);

                            if (team == null)
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            string playerName = tokens[2];
                            int endurance = int.Parse(tokens[3]);
                            int sprint = int.Parse(tokens[4]);
                            int dribble = int.Parse(tokens[5]);
                            int passing = int.Parse(tokens[6]);
                            int shooting = int.Parse(tokens[7]);
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            team.AddPlayer(player);
                            break;
                        case "Remove":
                            team = teams.FirstOrDefault(t => t.Name == teamName);
                            if (team == null)
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            playerName = tokens[2];
                            team.RemovePlayer(playerName);
                            break;
                        case "Rating":
                            team = teams.FirstOrDefault(t => t.Name == teamName);
                            if (team == null)
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            Console.WriteLine(team);
                            break;
                    }
                    input = Console.ReadLine();
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                    input = Console.ReadLine();
                }
            }
        }
    }
}
