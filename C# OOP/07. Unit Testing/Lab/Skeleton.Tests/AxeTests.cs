using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_If_Weapon_Durability_Lowers_After_Each_Attack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints == 9);
        }

        [Test]
        public void Test_If_Throws_Invalid_Operation_When_Attacks_With_Less_Or_Zero_Durability()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}