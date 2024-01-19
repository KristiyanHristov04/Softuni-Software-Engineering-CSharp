using HouseRentingSystem.Services;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.Tests.Mocks;
using HouseRentingSystem.ViewModels.House;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Tests.UnitTests
{
    public class HouseServiceTests : UnitTestsBase
    {
        private readonly IHouseService houseService;
        private readonly IApplicationUserService userService;
        public HouseServiceTests()
        {
            this.userService = new ApplicationUserService(this.data);
            this.houseService = new HouseService(this.data, userService);
        }

        [Fact]
        public void All_ShouldReturnHousesAndTheirCount()
        {
            //Arrange
            int expectedTotalHousesCount = this.data.Houses.Count();

            //Act
            var result = this.houseService.All();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedTotalHousesCount, result.TotalHousesCount);
        }

        [Fact]
        public async Task AllCategoriesAsync_ShouldWork_WithValidData()
        {
            //Arrange
            int expectedCategoriesCount = this.data.Categories.Count();

            //Act
            var result = await this.houseService.AllCategoriesAsync();
            var resultCount = result.Count();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCategoriesCount, resultCount);
        }

        [Fact]
        public async Task AllCategoriesNamesAsync_ShouldWork_WithValidData()
        {
            //Arrange
            var allCategoriesDistinct = await this.data.Categories.Distinct().ToListAsync();
            var allCategoriesCount = allCategoriesDistinct.Count();

            //Act
            var result = await this.houseService.AllCategoriesNamesAsync();
            var resultCount = result.Count();

            //Assert
            Assert.Equal(allCategoriesCount, resultCount);
        }

        [Fact]
        public async Task AllHousesByAgentIdAsync_ShouldWork_WithValidData()
        {
            //Arrange
            var agentHouses = await this.data.Houses
                .Where(h => h.AgentId == Agent.Id)
                .ToListAsync();

            var expectedAgentHousesCount = agentHouses.Count();

            //Act
            var result = await this.houseService.AllHousesByAgentIdAsync(Agent.Id);
            var resultHousesCount = result.Count();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAgentHousesCount, resultHousesCount);
        }

        [Fact]
        public async Task AllHousesByUserIdAsync_ShouldWork_WithValidData()
        {
            //Arrange
            var userHouses = await this.data.Houses
                .Where(h => h.User.Id == Renter.Id)
                .ToListAsync();

            var expectedUserHousesCount = userHouses.Count();

            //Act
            var result = await this.houseService.AllHousesByUserIdAsync(Renter.Id);
            var resultCount = result.Count();

            //Assert
            Assert.NotNull(userHouses);
            Assert.Equal(expectedUserHousesCount, resultCount);
        }

        [Fact]
        public async Task CategoryExistsAsync_ShouldReturnTrue_WithCorrectData()
        {
            //Arrange

            //Act
            bool result = await this.houseService.CategoryExistsAsync(1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CreateAsync_ShouldWork_WithValidData()
        {
            //Arrange
            int housesBefore = this.data.Houses.Count();

            string title = "Title";
            string address = "My address";
            string description = "This is a test description. This is a test description. This is a test description.";
            string imageUrl = "https://images.adsttc.com/media/images/629f/3517/c372/5201/650f/1c7f/large_jpg/hyde-park-house-robeson-architects_1.jpg?1654601149";
            decimal price = 100.50m;
            int categoryId = 1;
            int agentId = Agent.Id;

            //Act
            var houseId = await this.houseService.CreateAsync(title, address, description, imageUrl, price, categoryId, agentId);
            var house = await this.data.Houses.FindAsync(houseId);

            //Assert
            int housesAfter = this.data.Houses.Count();
            Assert.Equal(housesBefore + 1, housesAfter);
            Assert.Equal(title, house.Title);
            Assert.Equal(address, house.Address);
            Assert.Equal(description, house.Description);
            Assert.Equal(imageUrl, house.ImageUrl);
            Assert.Equal(price, house.PricePerMonth);
            Assert.Equal(categoryId, house.CategoryId);
            Assert.Equal(agentId, house.AgentId);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDelete_WithCorrectData()
        {
            //Arrange
            var housesCountBefore = this.data.Houses.Count();

            //Act
            await this.houseService.DeleteAsync(RentedHouse.Id);

            //Assert
            var housesAfter = this.data.Houses.Count();
            Assert.Equal(housesCountBefore - 1, housesAfter);
        }

        [Fact]
        public async Task EditAsync_ShouldWork_WithCorrectData()
        {
            //Arrange
            string title = "Title";
            string address = "My address";
            string description = "This is a test description. This is a test description. This is a test description.";
            string imageUrl = "https://images.adsttc.com/media/images/629f/3517/c372/5201/650f/1c7f/large_jpg/hyde-park-house-robeson-architects_1.jpg?1654601149";
            decimal price = 100.50m;
            int categoryId = 1;
            int agentId = Agent.Id;

            //Act
            await this.houseService.EditAsync(RentedHouse.Id, title, address, description, imageUrl, price, categoryId);

            //Assert
            Assert.Equal(title, RentedHouse.Title);
            Assert.Equal(address, RentedHouse.Address);
            Assert.Equal(description, RentedHouse.Description);
            Assert.Equal(imageUrl, RentedHouse.ImageUrl);
            Assert.Equal(price, RentedHouse.PricePerMonth);
            Assert.Equal(categoryId, RentedHouse.CategoryId);
            Assert.Equal(agentId, RentedHouse.AgentId);
        }

        [Fact]
        public async Task ExistsAsync_ShouldReturnTrue_WithValidData()
        {
            //Arrange

            //Act
            bool result = await this.houseService.ExistsAsync(RentedHouse.Id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetHouseCategoryIdAsync_ShouldReturnCorrectCategoryId_WithValidData()
        {
            //Arrange
            int categoryId = this.data.Categories.Where(c => c.Name == "Cottage").First().Id;

            //Act
            int resultCategoryId = await this.houseService.GetHouseCategoryIdAsync(RentedHouse.Id);

            //Assert
            Assert.Equal(categoryId, resultCategoryId);
        }

        [Fact]
        public async Task HasAgentWithIdAsync_ShouldReturnTrue_WithValidData()
        {
            //Arrange

            //Act
            bool result = await this.houseService.HasAgentWithIdAsync(RentedHouse.Id, Agent.User.Id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task HasAgentWithIdAsync_ShouldReturnFalseIfAgentIsNotOwnerOfTheHouse_WithValidData()
        {
            //Arrange

            //Act
            bool result = await this.houseService
                .HasAgentWithIdAsync(RentedHouse.Id, "Random Agent");

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task HouseDetailsByIdAsync_ShouldWork_WithCorrectData()
        {
            //Arrange

            //Act
            var result = await this.houseService.HouseDetailsByIdAsync(RentedHouse.Id);

            //Assert
            Assert.Equal(RentedHouse.Title, result.Title);
            Assert.Equal(RentedHouse.Address, result.Address);
            Assert.Equal(RentedHouse.Description, result.Description);
            Assert.Equal(RentedHouse.ImageUrl, result.ImageUrl);
            Assert.Equal(RentedHouse.PricePerMonth, result.PricePerMonth);
            Assert.Equal(RentedHouse.Category.Name, result.Category);
            Assert.Equal(RentedHouse.Agent.User.FirstName + " " + RentedHouse.Agent.User.LastName, result.Agent.FullName);
            Assert.Equal(RentedHouse.Agent.PhoneNumber, result.Agent.PhoneNumber);
            Assert.Equal(RentedHouse.Agent.User.Email, result.Agent.Email);
        }

        [Fact]
        public async Task IsRentedAsync_ShouldReturnTrue_IfHouseIsRented()
        {
            //Arrange

            //Act
            bool result = await this.houseService.IsRentedAsync(RentedHouse.Id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsRentedAsync_ShouldReturnFalse_IfHouseIsNotRented()
        {
            //Arrange
            var notRentedHouse = await this.data.Houses.Where(h => h.RenterId == null).FirstAsync();

            //Act
            bool result = await this.houseService.IsRentedAsync(notRentedHouse.Id);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task IsRentedByUserWithIdAsync_ShouldReturnTrue_IfUserIsOwnerOfTheHouse()
        {
            //Arrange

            //Act
            bool result = await this.houseService.IsRentedByUserWithIdAsync(RentedHouse.Id, Renter.Id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsRentedByUserWithIdAsync_ShouldReturnFalse_IfHouseDoesNotExist()
        {
            //Arrange

            //Act
            bool result = await this.houseService.IsRentedByUserWithIdAsync(60, Renter.Id);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task IsRentedByUserWithIdAsync_ShouldReturnFalse_IfHouseUserIdIsDifferentFromCurrentUser()
        {
            //Arrange

            //Act
            bool result = await this.houseService.IsRentedByUserWithIdAsync(RentedHouse.Id, "Another User Id");

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task LastThreeHousesAsync_ShouldReturnValidData()
        {
            //Arrange
            var totalHouses = await this.data.Houses.OrderByDescending(h => h.Id).Take(3).ToListAsync();

            //Act
            var lastHousesResult = await this.houseService.LastThreeHousesAsync();

            //Assert
            var firstHouse = totalHouses.FirstOrDefault();
            var firstHouseResult = lastHousesResult.FirstOrDefault();

            Assert.NotNull(lastHousesResult);
            Assert.Equal(totalHouses.Count(), lastHousesResult.Count());
            Assert.Equal(firstHouse.Id, firstHouseResult.Id);
        }

        [Fact]
        public async Task LeaveAsync_UserShouldLeaveTheHouse_WithCorrectHouseId()
        {
            //Arrange

            //Act
            await this.houseService.LeaveAsync(RentedHouse.Id);

            //Assert
            Assert.Null(RentedHouse.RenterId);
        }

        [Fact]
        public async Task RentAsync_UserShouldRentAHouse_WithCorrectValidData()
        {
            //Arrange
            var notRentedHouse = await this.data.Houses
                .Where(h => h.RenterId == null)
                .FirstAsync();

            //Act
            await this.houseService.RentAsync(notRentedHouse.Id, Renter.Id);

            //Assert
            Assert.Equal(Renter.Id, notRentedHouse.User.Id);
        }
    }
}
