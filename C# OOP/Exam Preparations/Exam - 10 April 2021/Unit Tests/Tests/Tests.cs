namespace Aquariums.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    public class AquariumsTests
    {
        [Test]
        [TestCase("Aquarium1", 10)]
        [TestCase("Aquarium2", 5)]
        public void Validate_Constructor(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);
            Assert.That(aquarium.Name == name);
            Assert.That(aquarium.Capacity == capacity);
            Assert.That(aquarium.Count == 0);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Property_Name_Throws_Exception_When_Null_Or_Empty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 5);
            });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Property_Capacity_Throws_Exception_When_Less_Than_0(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Aquarium1", capacity);
            });
        }

        [Test]
        public void Method_Add_Throws_Exception_When_Aquarium_Is_Full()
        {
            Aquarium aquarium = new Aquarium("Aquarium1", 1);
            aquarium.Add(new Fish("Salmon"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("secondSalmon"));
            });
        }

        [Test]
        public void Validate_Method_Add()
        {
            Aquarium aquarium = new Aquarium("Aquarium1", 1);
            aquarium.Add(new Fish("Salmon"));
            Assert.That(aquarium.Count == 1);
        }

        [Test]
        public void Method_Remove_Fish_Throws_Exception_When_Fish_Doesnt_Exist()
        {
            Aquarium aquarium = new Aquarium("Aquarium1", 1);
            aquarium.Add(new Fish("Salmon"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Kristiyan");
            });
        }

        [Test]
        public void Validate_Method_Remove_Fish()
        {
            Aquarium aquarium = new Aquarium("Aquarium1", 1);
            aquarium.Add(new Fish("Salmon"));
            aquarium.RemoveFish("Salmon");
            Assert.That(aquarium.Count == 0);
        }

        [Test]
        public void Method_Sell_Fish_Throws_Exception_When_Fish_Doesnt_Exist()
        {
            Aquarium aquarium = new Aquarium("Aquarium1", 1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Kristiyan");
            });
        }

        //Need rework!!!
        [Test]
        public void Validate_Method_Sell_Fish()
        {
            Aquarium aquarium = new Aquarium("Aquarium1", 1);
            Fish fish = new Fish("Kristiyan");
            aquarium.Add(fish);
            Assert.That(aquarium.SellFish("Kristiyan") == fish);
        }

        [Test]
        public void Validate_Report_Method()
        {
            List<Fish> fish = new List<Fish>();
            Aquarium aquarium = new Aquarium("Aquarium", 5);
            Fish fish01 = new Fish("Kristiyan");
            Fish fish02 = new Fish("Ivan");
            fish.Add(fish01);
            fish.Add(fish02);
            aquarium.Add(fish01);
            aquarium.Add(fish02);
            string fishNames = string.Join(", ", fish.Select(f => f.Name));
            string tempReport = $"Fish available at {aquarium.Name}: {fishNames}";
            Assert.That(tempReport == aquarium.Report());
        }
    }
}
