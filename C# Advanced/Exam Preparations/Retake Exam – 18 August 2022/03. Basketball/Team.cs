using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get { return this.Players.Count; } }
        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            this.Players = new List<Player>();
        }
        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            if (this.OpenPositions <= 0)
            {
                return "There are no more open positions.";
            }
            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            this.Players.Add(player);
            this.OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }
        public bool RemovePlayer(string name)
        {
            bool doesExist = false;
            foreach (Player player in this.Players)
            {
                if (player.Name == name)
                {
                    doesExist = true;
                    this.Players.Remove(player);
                    this.OpenPositions++;
                    return doesExist;
                }
            }
            return doesExist;
        }
        public int RemovePlayerByPosition(string position)
        {
            int count = 0;
            foreach (var player in this.Players)
            {
                if (player.Position == position)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return 0;
            }
            else
            {
                this.Players.RemoveAll(player => player.Position == position);
                this.OpenPositions += count;
                return count;
            }
        }
        public Player RetirePlayer(string name)
        {
            foreach (var player in this.Players)
            {
                if (player.Name == name)
                {
                    player.Retired = true;
                    return player;
                }
            }
            return null;
        }
        public List<Player> AwardPlayers(int games)
        {
            List<Player> playersParticipatedInGames = this.Players.Where(player => player.Games >= games).ToList();
            return playersParticipatedInGames;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach (var player in this.Players)
            {
                if (!player.Retired)
                {
                    sb.AppendLine(player.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
