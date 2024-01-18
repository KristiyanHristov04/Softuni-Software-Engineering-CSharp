using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace HouseRentingSystem.Tests.Mocks
{
    public class UnitTestsBase : IDisposable
    {
        protected HouseRentingDbContext data;
        public UnitTestsBase()
        {
            var dbContextOptions = new DbContextOptionsBuilder<HouseRentingDbContext>()
                    .UseInMemoryDatabase("HouseRentingSystemInMemoryDB" + DateTime.Now.Ticks.ToString())
                    .Options;
            this.data = new HouseRentingDbContext(dbContextOptions, false);

            SeedDatabase();
        }

        public ApplicationUser Renter { get; set; }
        public Agent Agent { get; set; }
        public House RentedHouse { get; set; }
        private void SeedDatabase()
        {
            Renter = new ApplicationUser()
            {
                Id = "RenterUserId",
                Email = "rent@er.bg",
                FirstName = "Renter",
                LastName = "User"
            };

            data.Users.Add(Renter);

            Agent = new Agent()
            {
                PhoneNumber = "+359111111111",
                User = new ApplicationUser()
                {
                    Id = "TestUserId",
                    Email = "test@test.bg",
                    FirstName = "Test",
                    LastName = "Tester"
                }
            };

            data.Agents.Add(Agent);

            RentedHouse = new House()
            {
                Title = "First Test House",
                Address = "Test, 201 Test",
                Description = "This is a test description. This is a test description. This is a test description.",
                ImageUrl = "https://www.bhg.com/thmb/0Fg0imFSA6HVZMS2DFWPvjbYDoQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg",
                RenterId = "RenterUserId",
                Agent = Agent,
                Category = new Category() { Name = "Cottage" }
            };

            data.Houses.Add(RentedHouse);

            var nonRentedHouse = new House()
            {
                Title = "Second Test House",
                Address = "Test, 204 Test",
                Description = "This is a test description. This is a test description. This is a test description.",
                ImageUrl = "https://images.adsttc.com/media/images/629f/3517/c372/5201/650f/1c7f/large_jpg/hyde-park-house-robeson-architects_1.jpg?1654601149",
                RenterId = null,
                Agent = Agent,
                Category = new Category() { Name = "Single-Family" }
            };

            data.Houses.Add(nonRentedHouse);
            data.SaveChanges();
        }

        public void Dispose()
        {
            
        }
    }
}
