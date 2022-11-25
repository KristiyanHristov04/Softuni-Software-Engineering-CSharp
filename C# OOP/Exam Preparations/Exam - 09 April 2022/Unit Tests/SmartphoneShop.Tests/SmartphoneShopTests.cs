using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Validate_Constructor()
        {
            Shop shop = new Shop(5);
            Assert.That(shop.Capacity == 5);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Property_Capacity_Throws_Exception_When_Capacity_Is_Less_Than_Zero(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            });
        }

        [Test]
        public void Validate_Add_Method()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("IPhone", 100));
            Assert.That(shop.Count == 1);
        }

        [Test]
        public void Method_Add_Throws_Exception_When_Smartphone_Already_Exists()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("IPhone", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("IPhone", 100));
            });
        }

        [Test]
        public void Method_Add_Throws_Exception_When_Shop_Capacity_Is_Full()
        {
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("IPhone", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Samsung", 100));
            });
        }

        [Test]
        public void Validate_Remove_Method()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("IPhone", 100));
            shop.Remove("IPhone");
            Assert.That(shop.Count == 0);
        }

        [Test]
        public void Method_Remove_Throws_Exception_When_Phone_Model_Doesnt_Exist()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("IPhone", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Samsung");
            });
        }

        [Test]
        public void Validate_Test_Phone_Method()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("IPhone", 100);
            shop.Add(smartphone);
            shop.TestPhone("IPhone", 20);
            Assert.That(smartphone.CurrentBateryCharge == 80);
        }

        [Test]
        public void Method_Test_Phone_Throws_Exception_When_Phone_Model_Doesnt_Exist()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("IPhone", 100);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Samsung", 20);
            });
        }

        [Test]
        public void Method_Test_Phone_Throws_Exception_When_Phone_Battery_Is_Less_Than_Needed_For_The_Test()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("IPhone", 50);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("IPhone", 60);
            });
        }

        [Test]
        public void Validate_Charge_Phone_Method()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("IPhone", 100);
            shop.Add(smartphone);
            shop.TestPhone("IPhone", 50);
            shop.ChargePhone("IPhone");
            Assert.That(smartphone.CurrentBateryCharge == 100);
        }

        [Test]
        public void Method_Charge_Phone_Throws_Exception_When_Smartphone_Model_Doesnt_Exist()
        {
            Shop shop = new Shop(5);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("IPhone");
            });
        }
    }
}