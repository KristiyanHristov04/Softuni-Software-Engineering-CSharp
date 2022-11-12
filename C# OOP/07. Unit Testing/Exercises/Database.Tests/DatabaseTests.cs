namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void Check_If_Capacity_Has_16_Numbers()
        {
            Database db = new Database(new int[16]);
            Assert.AreEqual(16, db.Count);
        }

        [Test]
        public void Array_Doesnt_Have_16_Numbers()
        {
            Database db = new Database(new int[16]);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(2);
            });
        }

        [Test]
        [TestCase(6)]
        [TestCase(8)]
        [TestCase(10)]
        public void Add_New_Element_At_Next_Free_Cell(int count)
        {
            Database db = new Database();
            for (int i = 0; i < count; i++)
            {
                db.Add(i);
            }
            Assert.AreEqual(count, db.Count);
        }

        [Test]
        public void Trying_To_Add_More_Than_16_Numbers()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(new int[17]);
            });
        }

        [Test]
        public void Trying_To_Remove_From_An_Empty_Collection()
        {
            Database db = new Database(new int[0]);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 , 5 })]
        public void Remove_Element_At_Last_Index(int[] numbers)
        {
            Database db = new Database(numbers);
            db.Remove();
            Assert.AreEqual(db.Fetch().Length, numbers.Length - 1);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 1 })]
        public void Check_If_Fetch_Works_Fine(int[] array)
        {
            Database db = new Database(array);
            CollectionAssert.AreEqual(array, db.Fetch());
        }
    }
}
