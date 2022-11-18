using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        public string FullName 
        {
            get 
            {  
                return fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                this.fullName = value;
            }
        }

        private int category;
        public int Category 
        {
            get 
            { 
                return category;
            }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                this.category = value;
            }
        }

        public double Turnover => Math.Round(this.Bookings.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight), 2);

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.Rooms = new RoomRepository();
            this.Bookings = new BookingRepository();
        }

        public IRepository<IRoom> Rooms { get; set; }

        public IRepository<IBooking> Bookings { get; set; }
    }
}
