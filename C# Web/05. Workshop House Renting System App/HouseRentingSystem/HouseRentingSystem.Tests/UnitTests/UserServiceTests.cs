using HouseRentingSystem.Services;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Tests.UnitTests
{
    public class UserServiceTests : UnitTestsBase
    {
        private readonly IApplicationUserService userService;
        public UserServiceTests()
        {
            this.userService = new ApplicationUserService(this.data);
        }

        [Fact]
        public async Task UserHasRents_ShouldReturnTrue_WithValidData()
        {
            //Arrange

            //Act
            bool result = await this.userService.UserHasRents(Renter.Id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task UserFullName_ShouldReturnFullName()
        {
            //Arrange

            //Act
            string result = await this.userService.UserFullNameAsync(Renter.Id);

            //Assert
            Assert.Equal($"{Renter.FirstName} {Renter.LastName}", result);
        }

        [Fact]
        public async Task UserFullName_ShouldReturnNull_WithInvalidUserId()
        {
            //Arrange

            //Act
            string result = await this.userService.UserFullNameAsync("fake");

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AllAsync_ShouldReturnCorrectCount_WithValidData()
        {
            //Arrange
            int usersCount = this.data.Users.Count();

            //Act
            var allUsers = await this.userService.AllAsync();
            var result = allUsers.Count();

            //Assert
            Assert.Equal(usersCount, result);
        }
    }
}
