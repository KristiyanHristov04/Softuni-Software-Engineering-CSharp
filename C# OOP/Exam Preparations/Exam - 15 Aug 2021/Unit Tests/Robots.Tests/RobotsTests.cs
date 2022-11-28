namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        [Test]
        public void Validate_Robot_Constructor()
        {
            Robot robot = new Robot("Sashko", 20);
            Assert.That(robot.Name == "Sashko");
            Assert.That(robot.Battery == 20);
            Assert.That(robot.MaximumBattery == 20);
        }

        [Test]
        public void Validate_Robot_Manager_Constructor()
        {
            RobotManager robotManager = new RobotManager(5);
            Assert.That(robotManager.Capacity == 5);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Property_Capacity_Throws_Exception_When_Capacity_Value_Is_Less_Than_Zero(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(capacity);
            });
        }

        [Test]
        public void Validate_Add_Method()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(new Robot("Ivan", 100));
            Assert.That(robotManager.Count == 1);
        }

        [Test]
        public void Method_Add_Throws_Exception_When_Robot_With_That_Name_Already_Exists()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(new Robot("Ivan", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("Ivan", 100));
            });
        }

        [Test]
        public void Method_Add_Throws_Exception_When_There_Is_No_More_Capacity()
        {
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(new Robot("Ivan", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("George", 100));
            });
        }

        [Test]
        public void Validate_Remove_Method()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(new Robot("Ivan", 100));
            robotManager.Remove("Ivan");
            Assert.That(robotManager.Count == 0);
        }

        [Test]
        public void Method_Remove_Throws_Exception_When_Robot_With_That_Name_Doesnt_Exist()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(new Robot("Ivan", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("George");
            });
        }

        [Test]
        public void Validate_Work_Method()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot = new Robot("Ivan", 100);
            robotManager.Add(robot);
            robotManager.Work("Ivan", "Mestena na skafove", 50);
            Assert.That(robot.Battery == 50);
        }

        [Test]
        public void Method_Work_Throws_Exception_When_Robot_With_That_Name_Doesnt_Exist()
        {
            RobotManager robotManager = new RobotManager(5);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Ivan", "Mestena na skafove", 50);
            });
        }

        [Test]
        public void Method_Work_Throws_Exception_When_Robot_Doesnt_Have_Enough_Battery_To_Do_The_Job()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(new Robot("Ivan", 25));
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Ivan", "Mestena na skafove", 50);
            });
        }

        [Test]
        public void Validate_Charge_Method()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot = new Robot("Ivan", 100);
            robotManager.Add(robot);
            robotManager.Work("Ivan", "Mestene na shkafove", 50);
            robotManager.Charge("Ivan");
            Assert.That(robot.Battery == 100);
        }

        [Test]
        public void Method_Charge_Throws_Exception_When_Robot_With_That_Name_Doesnt_Exist()
        {
            RobotManager robotManager = new RobotManager(5);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Pesho");
            });
        }
    }
}
