namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void Validate_Constructor()
        {
            Book book = new Book("C# Programming", "Nakov");
            Assert.That(book.BookName == "C# Programming");
            Assert.That(book.Author == "Nakov");
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Property_Book_Name_Throws_Exception_When_Name_Is_Null_Or_Empty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, "Nakov");
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Property_Author_Throws_Exception_When_Name_Is_Null_Or_Empty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("C# Programming", name);
            });
        }

        [Test]
        public void Validate_Add_Footnote_Method()
        {
            Book book = new Book("C# Programming", "Nakov");
            book.AddFootnote(1, "Variables");
            Assert.That(book.FootnoteCount == 1);
        }

        [Test]
        public void Method_Add_Footnote_Throws_Exception_When_Footnote_Key_Already_Exists()
        {
            Book book = new Book("C# Programming", "Nakov");
            book.AddFootnote(1, "Variables");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "Variables");
            });
        }

        [Test]
        public void Validate_Find_Footnote_Method()
        {
            Book book = new Book("C# Programming", "Nakov");
            book.AddFootnote(1, "Variables");
            Assert.That(book.FindFootnote(1) == $"Footnote #1: Variables");
        }

        [Test]
        public void Method_Find_Footnote_Throws_Exception_When_Footnote_Doesnt_Exist()
        {
            Book book = new Book("C# Programming", "Nakov");
            book.AddFootnote(1, "Variables");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(15);
            });
        }

        [Test]
        public void Validate_Alter_Footnote_Method()
        {
            Book book = new Book("C# Programming", "Nakov");
            book.AddFootnote(1, "Variables");
            book.AlterFootnote(1, "Data types");
            Assert.That(book.FindFootnote(1) == $"Footnote #1: Data types");
        }

        [Test]
        public void Method_Alter_Footnote_Throws_Exception_When_Footnote_Number_Doesnt_Exist()
        {
            Book book = new Book("C# Programming", "Nakov");
            book.AddFootnote(1, "Variables");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(50, "C# Objects and Classes");
            });
        }
    }
}