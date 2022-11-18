using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Validate_Constructor()
        {
            Hotel hotel = new Hotel("Detelina", 2);
            List<Room> rooms = new List<Room>();
            List<Booking> bookings = new List<Booking>();

            Assert.That(hotel.FullName == "Detelina");
            Assert.That(hotel.Category == 2);
            CollectionAssert.AreEquivalent(rooms, hotel.Rooms);
            CollectionAssert.AreEquivalent(bookings, hotel.Bookings);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("           ")]
        [TestCase(null)]
        public void Full_Name_Throws_Exception_When_Null_Or_WhiteSpace_Or_Empty(string value)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(value, 2);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(6)]
        [TestCase(-1)]
        [TestCase(10)]
        public void Category_Throws_Exception_When_Less_Than_One_Or_Bigger_Than_Five(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Detelina", value);
            });
        }

        [Test]
        public void Validate_Add_Room_Method()
        {
            Hotel hotel = new Hotel("Detelina", 2);
            hotel.AddRoom(new Room(5, 25.60));
            hotel.AddRoom(new Room(6, 31.20));
            Assert.That(hotel.Rooms.Count == 2);
        }

        [Test]
        [TestCase(0, 2, 3, 500)]
        [TestCase(-1, 2, 3, 500)]
        [TestCase(-2, 2, 3, 500)]
        [TestCase(-10, 2, 3, 500)]
        public void Book_Room_Method_Throws_Exception_When_Adults_Are_Less_Or_Equal_To_Zero(int adults, int children, int residenceDuration, double budget)
        {
            Hotel hotel = new Hotel("Detelina", 2);
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adults, children, residenceDuration, budget);
            });
        }

        [Test]
        [TestCase(1, -1, 3, 500)]
        [TestCase(1, -5, 3, 500)]
        [TestCase(1, -2, 3, 500)]
        [TestCase(1, -10, 3, 500)]
        public void Book_Room_Method_Throws_Exception_When_Children_Are_Less_Than_Zero(int adults, int children, int residenceDuration, double budget)
        {
            Hotel hotel = new Hotel("Detelina", 2);
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adults, children, residenceDuration, budget);
            });
        }

        [Test]
        [TestCase(1, 0, 0, 500)]
        [TestCase(1, 1, -1, 500)]
        [TestCase(1, 2, -2, 500)]
        [TestCase(1, 3, -10, 500)]
        public void Book_Room_Method_Throws_Exception_When_Resident_Duration_Is_Less_Than_1_Day(int adults, int children, int residenceDuration, double budget)
        {
            Hotel hotel = new Hotel("Detelina", 2);
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adults, children, residenceDuration, budget);
            });
        }

        [Test]
        [TestCase(1, 2, 2, 500)]
        [TestCase(2, 2, 2, 500)]
        [TestCase(3, 4, 2, 1000)]
        [TestCase(3, 3, 2, 1000)]
        public void Validate_Book_Room_Method(int adults, int children, int duration, double budget)
        {
            Hotel hotel = new Hotel("Detelina", 2);
            int beds = 30;
            double pricePerNight = 30.4;
            Room room = new Room(beds, pricePerNight);
            hotel.AddRoom(room);
            Assert.That(hotel.Rooms.Count == 1);

            hotel.BookRoom(adults, children, duration, budget);
            Assert.That(hotel.Bookings.Count == 1);
            Assert.That(hotel.Turnover == duration * room.PricePerNight);
        }
    }
}