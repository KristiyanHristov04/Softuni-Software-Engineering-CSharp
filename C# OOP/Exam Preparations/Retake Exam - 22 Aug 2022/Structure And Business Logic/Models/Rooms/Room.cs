using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        public int BedCapacity 
        { 
            get { return bedCapacity; }
            private set
            {
                this.bedCapacity = value;
            }
        }

        private double pricePerNight;
        public double PricePerNight
        {
            get { return pricePerNight; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                this.pricePerNight = value;
            }
        }

        public Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
            this.PricePerNight = 0;
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
