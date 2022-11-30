using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        public void Validate_Add_Item_Method()
        {
            Item item = new Item("Kristiyan", "2022");
            Assert.That(this.bankVault.AddItem("A1", item) == $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void Method_Add_Item_Throws_Exception_When_Cell_Doesnt_Exist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("H1", new Item("Kristiyan", "2022"));
            });
        }

        [Test]
        public void Method_Add_Item_Throws_Exception_When_Cell_Is_Not_Empty()
        {
            this.bankVault.AddItem("A1", new Item("Ivan", "2018"));
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("A1", new Item("Kristiyan", "2022"));
            });
        }

        [Test]
        public void Method_Add_Item_Throws_Exception_When_Item_Already_Exists_In_Another_Cell()
        {
            Item item = new Item("Kristiyan", "2022");
            this.bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.bankVault.AddItem("A2", item);
            });
        }

        [Test]
        public void Validate_Remove_Item_Method()
        {
            Item item = new Item("Kristiyan", "2022");
            this.bankVault.AddItem("A1", item);
            Assert.That(this.bankVault.RemoveItem("A1", item) == $"Remove item:{item.ItemId} successfully!");
        }

        [Test]
        public void Method_Remove_Item_Throws_Exception_When_Cell_Doesnt_Exist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("D1", new Item("Kristiyan", "2022"));
            });
        }

        [Test]
        public void Method_Remove_Item_Throws_Exception_When_In_That_Cell_The_Item_Doesnt_Exist()
        {
            Item item = new Item("Kristiyan", "2022");
            Item item02 = new Item("George", "2020");
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("A1", item02);
            });
        }
    }
}