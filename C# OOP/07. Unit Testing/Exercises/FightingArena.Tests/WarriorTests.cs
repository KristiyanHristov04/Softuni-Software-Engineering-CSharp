namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        [TestCase("Gladiator", 50, 100)]
        [TestCase("Ivan", 30, 75)]
        public void Validate_Constructor(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Assert.That(warrior.Name == name);
            Assert.That(warrior.Damage == damage);
            Assert.That(warrior.HP == hp);
        }

        [Test]
        [TestCase("Gladiator")]
        [TestCase("Ivan")]
        [TestCase("I")]
        public void Validate_Name_Property(string name)
        {
            Warrior warrior = new Warrior(name, 50, 100);
            Assert.That(warrior.Name == name);
        }

        [Test]
        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]
        public void Name_Property_Throws_Exception_When_Null_Or_Empty(string name)
        {
           Assert.Throws<ArgumentException>(() =>
           {
               Warrior warrior = new Warrior(name, 50, 100);
           });

        }

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(50)]
        public void Validate_Damage_Property(int damage)
        {
            Warrior warrior = new Warrior("John", damage, 100);
            Assert.That(warrior.Damage == damage);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-50)]
        public void Damage_Property_Throws_Exception_When_Less_Or_Equal_To_Zero(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("John", damage, 100);
            });       
        }

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(50)]
        public void Validate_HP_Property(int hp)
        {
            Warrior warrior = new Warrior("John", 50, hp);
            Assert.That(warrior.HP == hp);
        }

        [Test]
        [TestCase(-2)]
        [TestCase(-1)]
        [TestCase(-50)]
        public void HP_Property_Throws_Exception_When_Less_Than_Zero(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("John", 50, hp);
            });
        }

        [Test]
        [TestCase(29)]
        [TestCase(28)]
        [TestCase(0)]
        [TestCase(1)]
        public void Attack_Method_Throws_Exception_When_Warrior_HP_Is_Less_Than_30(int hp)
        {
            Warrior warrior = new Warrior("John", 50, hp);
            Warrior secondWarrior = new Warrior("Gladiator", 100, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(secondWarrior);
            });
        }

        [Test]
        [TestCase(29)]
        [TestCase(28)]
        [TestCase(0)]
        [TestCase(1)]
        public void Attack_Method_Throws_Exception_When_Other_Warrior_HP_Is_Less_Than_30(int hp)
        {
            Warrior warrior = new Warrior("John", 50, 100);
            Warrior secondWarrior = new Warrior("Gladiator", 100, hp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(secondWarrior);
            });
        }

        [Test]
        [TestCase(39)]
        [TestCase(28)]
        [TestCase(0)]
        [TestCase(1)]
        public void Attack_Method_Throws_Exception_When_Warrior_Tries_To_Attack_Stronger_Warrior(int hp)
        {
            Warrior warrior = new Warrior("John", 50, hp);
            Warrior secondWarrior = new Warrior("Gladiator", 40, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(secondWarrior);
            });
        }

        [Test]
        public void Attack_Method_Validate()
        {
            Warrior warrior = new Warrior("John", 15, 100);
            Warrior secondWarrior = new Warrior("Gladiator", 20, 100);

            warrior.Attack(secondWarrior);
            Assert.That(warrior.HP == 80);
        }

        [Test]
        public void Attack_Method_Validatev2()
        {
            Warrior warrior = new Warrior("John", 60, 40);
            Warrior secondWarrior = new Warrior("Gladiator", 20, 50);

            warrior.Attack(secondWarrior);
            Assert.That(secondWarrior.HP == 0);
        }

        [Test]
        public void Attack_Method_Validatev3()
        {
            Warrior warrior = new Warrior("John", 40, 40);
            Warrior secondWarrior = new Warrior("Gladiator", 20, 50);

            warrior.Attack(secondWarrior);
            Assert.That(secondWarrior.HP == 10);
        }
    }
}