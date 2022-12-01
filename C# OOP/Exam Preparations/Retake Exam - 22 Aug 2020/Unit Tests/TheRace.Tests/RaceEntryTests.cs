using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void Validate_Add_Driver_Method()
        {
            UnitCar car = new UnitCar("Porsche", 200, 100);
            UnitDriver driver = new UnitDriver("Ivan", car);
            Assert.That(this.raceEntry.AddDriver(driver) == $"Driver {driver.Name} added in race.");
        }

        [Test]
        public void Method_Add_Driver_Throws_Exception_When_Driver_Is_Null()
        {
            UnitDriver driver = null;
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.AddDriver(driver);
            });
        }

        [Test]
        public void Method_Add_Driver_Throws_Exception_When_Driver_With_That_Name_Already_Exists()
        {
            UnitCar car = new UnitCar("Porsche", 200, 100);
            UnitDriver driver = new UnitDriver("Ivan", car);
            this.raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.AddDriver(driver);
            });
        }

        [Test]
        public void Validate_Calculate_Average_Horse_Power_Method()
        {
            UnitCar car01 = new UnitCar("Porsche", 200, 100);
            UnitCar car02 = new UnitCar("Lamborghini", 310, 150);
            UnitDriver driver01 = new UnitDriver("Ivan", car01);
            UnitDriver driver02 = new UnitDriver("Georgi", car02);
            this.raceEntry.AddDriver(driver01);
            this.raceEntry.AddDriver(driver02);
            double averageHorsePower = (driver01.Car.HorsePower + driver02.Car.HorsePower) / 2;
            Assert.That(averageHorsePower == this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void Method_Calculate_Average_Horse_Power_Throws_Exception_When_There_Are_Less_Than_Two_Participants()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.CalculateAverageHorsePower();
            });
        }
    }
}