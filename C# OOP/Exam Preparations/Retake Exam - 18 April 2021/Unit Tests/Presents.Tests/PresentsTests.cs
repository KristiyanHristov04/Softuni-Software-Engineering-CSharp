namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            this.present = new Present("Podaruk", 14.6);
            this.bag = new Bag();
        }

        [Test]
        public void Validate_Present_Constructor()
        {
            Assert.That(this.present.Name == "Podaruk");
            Assert.That(this.present.Magic == 14.6);
        }

        [Test]
        public void Validate_Create_Method()
        {
            Assert.That(bag.Create(present) == $"Successfully added present {this.present.Name}.");
        }

        [Test]
        public void Method_Create_Throws_Exception_When_Present_Is_Nulll()
        {
            Present present = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Method_Create_Throws_Exception_When_Present_Already_Exists()
        {
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Validate_Remove_Method()
        {
            bag.Create(present);
            Assert.IsTrue(bag.Remove(present));
        }

        [Test]
        public void Validate_Get_Present_With_Least_Magic_Method()
        {
            bag.Create(present);
            bag.Create(new Present("Podaruk 2", 19));
            Assert.That(bag.GetPresentWithLeastMagic() == this.present);
        }

        [Test]
        public void Validate_Get_Present_Method()
        {
            bag.Create(present);
            bag.Create(new Present("Podaruk 2", 19));
            Assert.That(bag.GetPresent("Podaruk") == this.present);
        }

        [Test]
        public void Validate_Get_Presents_Method()
        {
            List<Present> myPresents = new List<Present>();
            myPresents.Add(present);
            bag.Create(present);
            CollectionAssert.AreEqual(myPresents, bag.GetPresents());
        }
    }
}
