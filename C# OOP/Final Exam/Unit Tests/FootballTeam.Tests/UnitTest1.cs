using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Validate_Constructor()
        {
            FootballTeam team = new FootballTeam("Barcelona", 30);
            List<FootballPlayer> players = new List<FootballPlayer>();
            Assert.That(team.Name == "Barcelona");
            Assert.That(team.Capacity == 30);
            Assert.That(team.Players.Count == 0);
            Assert.That(team.Players != null);
            CollectionAssert.AreEqual(players, team.Players);
        }

        [Test]
        public void Property_Name_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(null, 30);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("", 30);
            });
        }

        [Test]
        public void Property_Capacity_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("Barcelona", 14);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("Barcelona", -1);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("Barcelona", 5);
            });
        }

        [Test]
        public void Validate_Players_Property()
        {
            FootballTeam team = new FootballTeam("Barcelona", 15);
            FootballPlayer player = new FootballPlayer("Messi", 10, "Goalkeeper");
            List<FootballPlayer> players = new List<FootballPlayer>();
            players.Add(player);
            team.AddNewPlayer(player);
            Assert.That(team.Players != null);
            Assert.That(team.Players.Count == 1);
            CollectionAssert.AreEqual(team.Players, players);
        }

        [Test]
        public void Validate_Add_New_Player_Method()
        {
            FootballTeam team = new FootballTeam("Barcelona", 30);
            FootballPlayer player = new FootballPlayer("Messi", 10, "Goalkeeper");
            Assert.That(team.AddNewPlayer(player) == $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}");
            Assert.That(team.Players.Count == 1);
        }

        [Test]
        public void Method_Add_New_Player_Throws_Exception_When_There_Is_No_Capacity()
        {
            FootballTeam team = new FootballTeam("Barcelona", 15);
            team.AddNewPlayer(new FootballPlayer("Messi", 1, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Ronaldo", 2, "Midfielder"));
            team.AddNewPlayer(new FootballPlayer("Nqkoi", 3, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Drug", 4, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Treti", 5, "Midfielder"));
            team.AddNewPlayer(new FootballPlayer("Peti", 6, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Shesti", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("5", 8, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("2", 9, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("3", 10, "Midfielder"));
            team.AddNewPlayer(new FootballPlayer("6", 11, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("gosho", 12, "Forward"));
            team.AddNewPlayer(new FootballPlayer("martin", 13, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("ivan", 14, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("tonkata", 15, "Midfielder"));
            Assert.That(team.AddNewPlayer(new FootballPlayer("Messi", 15, "Midfielder")) == "No more positions available!");
        }

        [Test]
        public void Validate_Pick_Player_Method()
        {
            FootballTeam team = new FootballTeam("Barcelona", 15);
            FootballPlayer player = new FootballPlayer("Messi", 10, "Goalkeeper");
            team.AddNewPlayer(player);
            Assert.That(team.PickPlayer("Messi") == player);
            Assert.That(team.PickPlayer("Messi") != null);
        }

        [Test]
        public void Validate_Player_Score_Method()
        {
            FootballTeam team = new FootballTeam("Barcelona", 15);
            FootballPlayer player = new FootballPlayer("Messi", 10, "Goalkeeper");
            FootballPlayer player02 = new FootballPlayer("Messi2", 15, "Forward");
            team.AddNewPlayer(player);
            team.AddNewPlayer(player02);
            team.PlayerScore(10);
            Assert.That(team.PlayerScore(10) == $"{player.Name} scored and now has {player.ScoredGoals} for this season!");
            Assert.That(player.ScoredGoals == 2);
        }

        [Test]
        public void Validate_Player_Constructor()
        {
            FootballPlayer player = new FootballPlayer("Messi", 10, "Goalkeeper");
            Assert.That(player.Name == "Messi");
            Assert.That(player.PlayerNumber == 10);
            Assert.That(player.Position == "Goalkeeper");
            Assert.That(player.ScoredGoals == 0);
        }

        [Test]
        public void Property_Name_Throws_Exception_When_Name_Is_Null_Or_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer(null, 10, "Goalkeeper");
            });

            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer("", 10, "Goalkeeper");
            });
        }

        [Test]
        public void Property_Player_Number_Throws_Exception_When_Number_Is_Not_Valid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer("Messi", 0, "Goalkeeper");
            });

            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer("Messi", 22, "Goalkeeper");
            });
        }

        [Test]
        public void Property_Position_Throws_Exception_When_Position_Is_Invalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer("Messi", 5, "Nqkakuv");
            });
        }

        [Test]
        public void Validate_Score_Property()
        {
            FootballPlayer player = new FootballPlayer("Messi", 5, "Forward");
            player.Score();
            player.Score();
            Assert.That(player.ScoredGoals == 2);
        }

        [Test]
        public void Validate_Score_Method()
        {
            FootballPlayer player = new FootballPlayer("Messi", 5, "Forward");
            player.Score();
            Assert.That(player.ScoredGoals == 1);
        }
    }
}