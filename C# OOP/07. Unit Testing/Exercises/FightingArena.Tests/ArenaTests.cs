namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void Validate_Enroll_Method()
        {
            List<Warrior> myList = new List<Warrior>();

            Warrior warrior1 = new Warrior("Jordan1", 50, 100);
            Warrior warrior2 = new Warrior("Jordan2", 50, 100);
            this.arena.Enroll(warrior1);
            myList.Add(warrior1);
            this.arena.Enroll(warrior2);
            myList.Add(warrior2);

            this.arena.Enroll(new Warrior("Jordan3", 50, 100));
            myList.Add(new Warrior("Jordan3", 50, 100));
            Assert.AreEqual(myList.Count, arena.Count);
        }

        [Test]
        public void Enroll_Method_Throws_Exception_When_Warrior_With_That_Name_Already_Exists()
        {
            Warrior warrior1 = new Warrior("Jordan1", 50, 100);
            Warrior warrior2 = new Warrior("Jordan2", 50, 100);
            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(new Warrior("Jordan2", 50, 100));
            });
        }

        [Test]
        [TestCase("Ivan", "Strahil")]
        [TestCase("Dragan", "Mitko")]
        public void Validate_Fight_Method(string attackerName, string defenderName)
        {
            Warrior attacker = new Warrior(attackerName, 20, 50);
            Warrior defender = new Warrior(defenderName, 20, 50);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attackerName, defenderName);

            Assert.AreEqual(30, attacker.HP);
            Assert.AreEqual(30, defender.HP);
        }

        [Test]
        public void Fight_Method_Throws_Exception_When_Attacker_Is_Missing()
        {
            Warrior deffender = new Warrior("John", 20, 50);
            arena.Enroll(deffender);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Kristiyan", "John");
            });
        }

        [Test]
        public void Fight_Method_Throws_Exception_When_Deffender_Is_Missing()
        {
            Warrior attacker = new Warrior("Kristiyan", 20, 50);
            arena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Kristiyan", "John");
            });
        }
    }
}
