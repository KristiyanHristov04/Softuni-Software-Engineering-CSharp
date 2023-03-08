using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }
        public int GameId { get; set; }
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }


        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public decimal HomeTeamBetRate { get; set; }

        [Required]
        public decimal AwayTeamBetRate { get; set; }

        [Required]
        public decimal DrawBetRate { get; set; }

        [Required]
        public int Result { get; set; }

        public ICollection<PlayerStatistic> PlayersStatistics { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}
