namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new Car("Volvo", "HD", 10, 45);
        }

        [Test]
        public void Validate_Constructor()
        {
            Assert.AreEqual("Volvo", car.Make);
            Assert.AreEqual("HD", car.Model);
            Assert.AreEqual(10, car.FuelConsumption);
            Assert.AreEqual(45, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Make_Property_Throws_Exception_When_Null(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(value, "HD", 10, 45);
            });
        }

        [Test]
        [TestCase("Volvo")]
        [TestCase("a")]
        [TestCase("Tesla")]
        public void Validate_Make_Property(string value)
        {
            Car car = new Car(value, "HD", 10, 45);
            Assert.That(car.Make == value);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Model_Property_Throws_Exception_When_Null(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Volvo", value, 10, 45);
            });
        }

        [Test]
        [TestCase("X6")]
        [TestCase("S3")]
        [TestCase("A3")]
        [TestCase("A")]
        [TestCase("a")]
        public void Validate_Model_Property(string value)
        {
            Car car = new Car("Volvo", value, 10, 45);
            Assert.That(car.Model == value);
        }

        [Test]
        [TestCase(-15)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-205)]
        public void Fuel_Consumption_Property_Throws_Exception_When_Less_Or_Equal_To_Zero(double value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Volvo", "HD", value, 45);
            });
        }

        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(0.1)]
        public void Validate_Fuel_Consumption_Property(double value)
        {
            Car car = new Car("Volvo", "HD", value, 45);
            Assert.That(car.FuelConsumption == value);
        }

        [Test]
        [TestCase(-15)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-205)]
        public void Fuel_Capacity_Property_Throws_Exception_When_Less_Or_Equal_To_Zero(double value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Volvo", "HD", 5, value);
            });
        }

        [Test]
        [TestCase(15.2)]
        [TestCase(60)]
        [TestCase(0.1)]
        [TestCase(1)]
        public void Validate_Fuel_Capacity_Property(double value)
        {
            Car car = new Car("Volvo", "HD", 10, value);
            Assert.That(car.FuelCapacity == value);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void Refuel_Method_Throws_Exception_When_Fuel_Is_Less_Than_Or_Equal_To_Zero(double value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(value);
            });
        }

        [Test]
        [TestCase(40)]
        [TestCase(30)]
        public void Validate_Refuel_Method(double value)
        {
            Car car = new Car("Volvo", "HD", 10, 45);
            car.Refuel(value);
            Assert.That(car.FuelAmount == value);
        }

        [Test]
        [TestCase(400)]
        [TestCase(300)]
        [TestCase(46)]
        [TestCase(50)]
        public void Validate_Refuel_Methodv2(double value)
        {
            Car car = new Car("Volvo", "HD", 10, 45);
            car.Refuel(value);
            Assert.That(car.FuelAmount == car.FuelCapacity);
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(1)]
        [TestCase(0.1)]
        public void Drive_Method_Throws_Exception_When_Needed_Fuel_Is_More_Than_The_Fuel_Amount(double value)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(value);
            });
        }

        [Test]
        public void Validate_Drive_Method()
        {
            Car car = new Car("Volvo", "HD", 10, 45);
            car.Refuel(45);
            car.Drive(200);
            Assert.That(car.FuelAmount == 25);
        }
    }
}