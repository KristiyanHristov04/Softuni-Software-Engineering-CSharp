using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Football_Team_Generator
{
    public class Team
    {
        private readonly List<Player> numberOfPlayers;

        private string name;

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Rating
        {
            get
            {
                if (this.numberOfPlayers.Count == 0)
                {
                    return 0;
                }
                return (int)Math.Round(this.numberOfPlayers.Average(p => p.OverallRate()), 0);
            }
        }
        public Team(string name)
        {
            this.Name = name;
            this.numberOfPlayers = new List<Player>();
        }
        public void AddPlayer(Player player)
        {
            this.numberOfPlayers.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToDelete = this.numberOfPlayers.FirstOrDefault(p => p.Name == playerName);
            if (playerToDelete == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            this.numberOfPlayers.Remove(playerToDelete);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
