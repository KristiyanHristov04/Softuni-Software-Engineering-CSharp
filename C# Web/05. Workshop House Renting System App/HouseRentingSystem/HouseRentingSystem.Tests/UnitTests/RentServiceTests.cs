using HouseRentingSystem.Services;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Tests.UnitTests
{
    public class RentServiceTests : UnitTestsBase
    {
        private IRentService rentService;
        public RentServiceTests()
        {
            this.rentService = new RentService(this.data);
        }

        [Fact]
        public async Task AllRentedHousesAsync_ShouldReturnCorrectData()
        {
            //Arrange

            //Act
            var rentedHouses = this.data.Houses.Where(h => h.RenterId != null).ToList();
            var result = await this.rentService.AllRentedHousesAsync();
            //Assert
            Assert.Equal(rentedHouses.Count(), result.Count());
            var rentedHouse = result.Where(r => r.HouseTitle == RentedHouse.Title).First();
            Assert.NotNull(rentedHouse);
            Assert.Equal(RentedHouse.Agent.User.Email, rentedHouse.AgentEmail);
            Assert.Equal(Renter.Email, rentedHouse.RenterEmail);
            Assert.Equal(RentedHouse.Agent.User.FirstName + " " + RentedHouse.Agent.User.LastName, rentedHouse.AgentFullName);
        }
    }
}
