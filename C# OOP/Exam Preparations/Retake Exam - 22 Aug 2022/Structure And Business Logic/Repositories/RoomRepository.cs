using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> rooms;
        public IReadOnlyCollection<IRoom> Rooms => rooms;
        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
            this.rooms.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return this.rooms;
        }

        public IRoom Select(string criteria)
        {
            return this.rooms.FirstOrDefault(room => room.GetType().Name == criteria);
        }
    }
}
