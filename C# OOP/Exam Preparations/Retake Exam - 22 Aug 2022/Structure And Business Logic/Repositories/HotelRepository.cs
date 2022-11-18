using BookingApp.Repositories.Contracts;
using BookingApp.Models.Hotels.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> hotels;
        public IReadOnlyCollection<IHotel> Hotels => this.hotels;

        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            this.hotels.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return this.hotels;
        }

        public IHotel Select(string criteria)
        {
            return this.hotels.FirstOrDefault(hotel => hotel.FullName == criteria);
        }
    }
}
