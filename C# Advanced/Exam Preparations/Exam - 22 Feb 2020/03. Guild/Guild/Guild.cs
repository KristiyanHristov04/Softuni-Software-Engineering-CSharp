using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Roster.Count; } }
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Roster = new List<Player>();
        }
        public void AddPlayer(Player player)
        {
            if (this.Roster.Count + 1 <= this.Capacity)
            {
                Roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            bool doesExist = false;
            foreach (Player player in this.Roster)
            {
                if (player.Name == name)
                {
                    this.Roster.Remove(player);
                    doesExist = true;
                    return doesExist;
                }
            }
            return doesExist;
        }
        public void PromotePlayer(string name)
        {
            foreach (var player in this.Roster)
            {
                if (player.Name == name && player.Rank != "Member")
                {
                    player.Rank = "Member";
                }
            }
        }
        public void DemotePlayer(string name)
        {
            foreach (var player in this.Roster)
            {
                if (player.Name == name && player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                }
            }
        }
        public Player[] KickPlayersByClass(string class_)
        {
            Player[] kickedPlayers = this.Roster.Where(player => player.Class == class_).ToArray();
            this.Roster.RemoveAll(player => player.Class == class_);
            return kickedPlayers;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.Roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
