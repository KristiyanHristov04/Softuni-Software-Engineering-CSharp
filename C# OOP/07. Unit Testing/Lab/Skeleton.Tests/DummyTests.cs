using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_If_Dummy_Loses_Health_When_Attacked()
        {
            Axe axe = new Axe(5, 10); //attack durability
            Dummy dummy = new Dummy(10, 20); //health experience

            dummy.TakeAttack(axe.AttackPoints);
            Assert.That(dummy.Health == 5);
        }

        [Test]
        public void Test_If_Dummy_Throws_Exception_When_Attacked()
        {
            Axe axe = new Axe(5, 10); //attack durability
            Dummy dummy = new Dummy(0, 20); //health experience

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(axe.AttackPoints);
            });


        }

        [Test]
        public void Test_If_Dummy_Can_Give_XP_When_Dead()
        {
            Axe axe = new Axe(5, 10); //attack durability
            Dummy dummy = new Dummy(5, 20); //health experience

            dummy.TakeAttack(axe.AttackPoints);

            Assert.AreEqual(20, dummy.GiveExperience());
        }

        [Test]
        public void Test_If_Dummy_Can_Give_XP_When_Alive()
        {
            Dummy dummy = new Dummy(10, 20); //health experience

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}