using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Validate_Weapon_Constructor()
            {
                Weapon weapon = new Weapon("AK-47", 2900, 5);
                Assert.That(weapon.Name == "AK-47");
                Assert.That(weapon.Price == 2900);
                Assert.That(weapon.DestructionLevel == 5);
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-0.9)]
            [TestCase(-0.1)]
            public void Property_Price_Throws_Exception_When_Value_Is_Less_Than_Zero(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("AK-47", price, 5);
                });
            }

            [Test]
            public void Validate_Increase_Destruction_Level_Method()
            {
                Weapon weapon = new Weapon("AK-47", 2900, 5);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.DestructionLevel == 6);
            }

            [Test]
            public void Validate_Planet_Constructor()
            {
                Planet planet = new Planet("Earth", 50);
                Assert.That(planet.Name == "Earth");
                Assert.That(planet.Budget == 50);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void Property_Name_Throws_Exception_When_Value_Is_Null_Or_Empty(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 50);
                });
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-0.9)]
            [TestCase(-0.1)]
            public void Property_Budget_Throws_Exception_When_Value_Is_Less_Than_Zero(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Earth", budget);
                });
            }

            [Test]
            public void Validate_Profit_Method()
            {
                Planet planet = new Planet("Earth", 50);
                planet.Profit(50);
                Assert.That(planet.Budget == 100);
            }

            [Test]
            public void Validate_Spend_Funds_Method()
            {
                Planet planet = new Planet("Earth", 50);
                planet.SpendFunds(50);
                Assert.That(planet.Budget == 0);
            }

            [Test]
            [TestCase(51)]
            [TestCase(100)]
            public void Method_Spend_Funds_Throws_Exception_When_Budget_Not_Enough(double amount)
            {
                Planet planet = new Planet("Earth", 50);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(amount);
                });
            }

            [Test]
            public void Validate_Add_Weapon_Method()
            {
                Planet planet = new Planet("Earth", 3000);
                planet.AddWeapon(new Weapon("AK-47", 2900, 5));
                Assert.That(planet.Weapons.Count == 1);
            }

            [Test]
            public void Method_Add_Weapon_Throws_Exception_When_Weapon_Already_Exists()
            {
                Planet planet = new Planet("Earth", 6000);
                planet.AddWeapon(new Weapon("AK-47", 2900, 5));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(new Weapon("AK-47", 2900, 5));
                });
            }

            [Test]
            public void Validate_Remove_Weapon_Method()
            {
                Planet planet = new Planet("Earth", 3000);
                planet.AddWeapon(new Weapon("AK-47", 2900, 5));
                planet.RemoveWeapon("AK-47");
                Assert.That(planet.Weapons.Count == 0);
            }

            [Test]
            public void Validate_Upgrade_Weapon_Method()
            {
                Planet planet = new Planet("Earth", 3000);
                planet.AddWeapon(new Weapon("AK-47", 2900, 5));
                planet.UpgradeWeapon("AK-47");
                Weapon weapon = planet.Weapons.FirstOrDefault(weapon => weapon.Name == "AK-47");
                Assert.That(weapon.DestructionLevel == 6);
            }

            [Test]
            public void Method_Upgrade_Weapon_Throws_Exception_When_Weapon_Does_Not_Exist()
            {
                Planet planet = new Planet("Earth", 6000);
                planet.AddWeapon(new Weapon("AK-47", 2900, 5));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("M4A1");
                });
            }

            [Test]
            public void Validate_Destruct_Opponent_Method()
            {
                Planet planet01 = new Planet("Earth", 6000);
                Planet planet02 = new Planet("Mars", 6000);
                planet01.AddWeapon(new Weapon("AK-47", 2900, 10));
                planet02.AddWeapon(new Weapon("M4A1", 2900, 2));
                Assert.That(planet01.DestructOpponent(planet02) == $"{planet02.Name} is destructed!");
            }

            [Test]
            public void Method_Destruct_Opponent_Throws_Exception_When_Enemy_Planet_Is_Stronger()
            {
                Planet planet01 = new Planet("Earth", 6000);
                Planet planet02 = new Planet("Mars", 6000);
                planet01.AddWeapon(new Weapon("AK-47", 2900, 10));
                planet02.AddWeapon(new Weapon("M4A1", 2900, 2));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet02.DestructOpponent(planet01);
                });
            }

            [Test]
            public void Validate_Double_Military_Power_Ratio_Property()
            {
                Planet planet = new Planet("Earth", 10000);
                planet.AddWeapon(new Weapon("AK-47", 2900, 5));
                planet.AddWeapon(new Weapon("M4A1", 3100, 11));
                planet.AddWeapon(new Weapon("Deagle", 1500, 7));
                Assert.That(planet.MilitaryPowerRatio == 23);
            }

            [Test]
            public void Validate_Is_Nuclear_Property()
            {
                Weapon weapon = new Weapon("AK-47", 2900, 15);
                Assert.That(weapon.IsNuclear == true);
            }
        }
    }
}
