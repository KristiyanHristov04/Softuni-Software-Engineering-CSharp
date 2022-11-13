namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using ExtendedDatabase;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        [SetUp]
        public void SetUp()
        {
            Person[] people = new Person[]
            {
                new Person(10, "Kristiyan"),
                new Person(20, "Ivan"),
                new Person(30, "Koceto")
            };
            db = new Database(people);
        }

        [Test]
        public void Array_Cannot_Have_More_Throws()
        {
            Database db2 = new Database();
            db2.Add(new Person(1, "1"));
            db2.Add(new Person(2, "2"));
            db2.Add(new Person(3, "3"));
            db2.Add(new Person(4, "4"));
            db2.Add(new Person(5, "5"));
            db2.Add(new Person(6, "6"));
            db2.Add(new Person(7, "7"));
            db2.Add(new Person(8, "8"));
            db2.Add(new Person(9, "9"));
            db2.Add(new Person(10, "10"));
            db2.Add(new Person(11, "11"));
            db2.Add(new Person(12, "12"));
            db2.Add(new Person(13, "13"));
            db2.Add(new Person(14, "14"));
            db2.Add(new Person(15, "15"));
            db2.Add(new Person(16, "16"));
            Assert.Throws<InvalidOperationException>(() => db2.Add(new Person(17, "17")));
        }

        [Test]
        public void Add_New_Person()
        {
            int startingCount = db.Count;
            db.Add(new Person(2051, "George"));
            Assert.AreEqual(startingCount + 1, db.Count);
        }

        [Test]
        public void Throw_Exception_If_User_Already_Exists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(15, "Kristiyan"));
            });
        }

        [Test]
        public void Throw_Exception_If_ID_Already_Exists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(10, "Stanislav"));
            });
        }

        [Test]
        public void Throw_Exception_Trying_To_Remove_From_Empty_Array()
        {
            Database db = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void Check_Count_After_Removing()
        {
            int startingCount = db.Count;
            db.Remove();
            Assert.AreEqual(startingCount - 1, db.Count);
        }

        [Test]
        public void Username_Doesnt_Exist_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("Marian");
            });
        }

        [Test]
        public void Username_Parameter_Is_Null_Throws_Exception()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(null);
            });
        }

        [Test]
        public void Find_And_Return_Correct_Person_With_Username()
        {
            Person person = db.FindByUsername("Ivan");
            Assert.AreEqual("Ivan", person.UserName);
        }

        [Test]
        public void ID_Doesnt_Exist_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(515);
            });
        }

        [Test]
        public void Negative_ID_Throws_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-10);
            });
        }

        [Test]
        public void Find_And_Return_Correct_Person_With_ID()
        {
            Person person = db.FindById(10);
            Assert.AreEqual(10, person.Id);
        }
    }
}