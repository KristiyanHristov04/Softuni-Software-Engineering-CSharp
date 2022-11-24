using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void Validate_Constructor()
            {
                Garage garage = new Garage("Wesley", 3);
                Assert.That(garage.Name == "Wesley");
                Assert.That(garage.MechanicsAvailable == 3);
            }

            [Test]
            [TestCase("")]
            [TestCase(null)]
            public void Property_Name_Throws_Exception_When_Value_Is_Null_Or_Empty(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, 2);
                });
            }

            [Test]
            [TestCase(0)]
            [TestCase(-1)]
            [TestCase(-5)]
            public void Property_Mechanics_Available_Throws_Exception_When_Mechanics_Are_Less_Or_Equal_To_Zero(int mechanicsAvailable)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("Wesley", mechanicsAvailable);
                });
            }

            [Test]
            public void Validate_Add_Car_Method()
            {
                Garage garage = new Garage("Wesley", 2);
                garage.AddCar(new Car("BMW", 1));
                Assert.That(garage.CarsInGarage == 1);
            }

            [Test]
            public void Method_Add_Car_Throws_Exception_When_Trying_To_Add_New_Car_And_There_Isnt_An_Available_Mechanic()
            {
                Garage garage = new Garage("Wesley", 2);
                garage.AddCar(new Car("BMW", 1));
                garage.AddCar(new Car("Mercedes", 2));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(new Car("Mazda", 5));
                });
            }

            [Test]
            public void Validate_Fix_Car_Method()
            {
                Garage garage = new Garage("Wesley", 4);
                garage.AddCar(new Car("BMW", 5));
                Car car = garage.FixCar("BMW");
                Assert.That(car.IsFixed == true);
            }

            [Test]
            public void Method_Fix_Car_Throws_Exception_When_Car_Doesnt_Exist_In_The_Garage()
            {
                Garage garage = new Garage("Wesley", 4);
                garage.AddCar(new Car("BMW", 5));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    Car car = garage.FixCar("Mazda");
                });
            }

            [Test]
            public void Validate_Remove_Fixed_Car_Method()
            {
                Garage garage = new Garage("Wesley", 5);
                Car car01 = new Car("BMW", 2);
                Car car02 = new Car("Mercedes", 5);
                garage.AddCar(car01);
                garage.AddCar(car02);
                garage.FixCar("BMW");
                garage.FixCar("Mercedes");
                garage.RemoveFixedCar();
                Assert.That(garage.CarsInGarage == 0);
            }

            [Test]
            public void Method_Remove_Fixed_Car_Throws_Exception_When_There_Are_No_Fixed_Cars()
            {
                Garage garage = new Garage("Wesley", 5);
                Car car01 = new Car("BMW", 2);
                Car car02 = new Car("Mercedes", 5);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            [Test]
            public void Validate_Report_Method()
            {
                Garage garage = new Garage("Wesley", 3);
                Car car01 = new Car("BMW", 2);
                Car car02 = new Car("Mercedes", 5);
                garage.AddCar(car01);
                garage.AddCar(car02);
                List<Car> carList = new List<Car>();
                carList.Add(car01);
                carList.Add(car02);
                var reportCars = carList.Where(x => x.IsFixed == false).Select(f => f.CarModel).ToList();
                string carsNames = string.Join(", ", reportCars);
                string report = $"There are {reportCars.Count} which are not fixed: {carsNames}.";
                Assert.AreEqual(garage.Report(),report);
            }
        }
    }
}