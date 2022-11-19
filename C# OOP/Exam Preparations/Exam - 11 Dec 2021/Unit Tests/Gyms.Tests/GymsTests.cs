namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GymsTests
    {
        // Implement unit tests here
        [Test]
        [TestCase("Jamaica", 55)]
        [TestCase("PowerGym", 120)]
        public void Validate_Constructor(string name, int size)
        {
            Gym gym = new Gym(name, size);
            List<Athlete> athletes = new List<Athlete>();

            Assert.That(gym.Name == name);
            Assert.That(gym.Capacity == size);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Property_Name_Throws_Exception_When_Null_Or_Empty(string value)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(value, 50);
            });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-2)]
        public void Property_Capacity_Throws_Exception_When_Less_Than_Zero(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("PowerGym", value);
            });
        }

        [Test]
        public void Method_Add_Athlete_Throws_Exception_When_Gym_Is_Full()
        {
            Gym gym = new Gym("PowerGym", 1);
            gym.AddAthlete(new Athlete("Georgi"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(new Athlete("Misho"));
            });
        }

        [Test]
        public void Validate_Add_Athlete_Method()
        {
            Gym gym = new Gym("PowerGym", 2);
            gym.AddAthlete(new Athlete("Georgi"));
            Assert.That(gym.Count == 1);
        }

        [Test]
        public void Method_Remove_Athlete_Throws_Exception_When_Athlete_Doesnt_Exist()
        {
            Gym gym = new Gym("PowerGym", 2);
            gym.AddAthlete(new Athlete("Ivan"));
            gym.AddAthlete(new Athlete("Kristiyan"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Georgi");
            });
        }

        [Test]
        public void Validate_Method_Remove_Athlete()
        {
            Gym gym = new Gym("PowerGym", 2);
            gym.AddAthlete(new Athlete("Ivan"));
            gym.AddAthlete(new Athlete("Kristiyan"));
            gym.RemoveAthlete("Kristiyan");
            Assert.That(gym.Count == 1);
        }

        [Test]
        public void Method_Injure_Athlete_Throws_Exception_When_Athlete_Doesnt_Exist()
        {
            Gym gym = new Gym("PowerGym", 2);
            gym.AddAthlete(new Athlete("Ivan"));
            gym.AddAthlete(new Athlete("Kristiyan"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Georgi");
            });
        }

        [Test]
        public void Validate_Injure_Athlete_Method()
        {
            Gym gym = new Gym("PowerGym", 2);
            gym.AddAthlete(new Athlete("Ivan"));
            gym.AddAthlete(new Athlete("Kristiyan"));
            Assert.That(gym.InjureAthlete("Kristiyan").IsInjured == true);
        }

        [Test]
        public void Validate_Report_Method()
        {
            List<Athlete> athletes = new List<Athlete>();
            Gym gym = new Gym("PowerGym", 2);
            Athlete athlete01 = new Athlete("Ivan");
            Athlete athlete02 = new Athlete("Kristiyan");
            gym.AddAthlete(athlete01);
            gym.AddAthlete(athlete02);
            athletes.Add(athlete01);
            athletes.Add(athlete02);
            string temp = string.Join(", ", athletes.Select(f => f.FullName));
            string tempReport = $"Active athletes at {gym.Name}: {temp}";
            Assert.That(gym.Report() == tempReport);
        }
    }
}
