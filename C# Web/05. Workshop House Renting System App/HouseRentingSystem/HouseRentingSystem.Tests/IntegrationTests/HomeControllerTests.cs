using HouseRentingSystem.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Tests.IntegrationTests
{
    public class HomeControllerTests
    {
        private readonly HomeController homeController;
        public HomeControllerTests()
        {
            this.homeController = new HomeController(null);
        }

        [Fact]
        public void Error_WithCode400_ShouldReturnCorrectView()
        {
            //Arrange
            var statusCode = 400;

            //Act
            var result = (ViewResult)this.homeController.Error(statusCode);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Error400", result!.ViewName);
        }

        [Fact]
        public void Error_WithCode401_ShouldReturnCorrectView()
        {
            //Arrange
            var statusCode = 401;

            //Act
            var result = (ViewResult)this.homeController.Error(statusCode);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Error401", result!.ViewName);
        }

        [Fact]
        public void Error_WithCode404_ShouldReturnCorrectView()
        {
            //Arrange
            var statusCode = 404;

            //Act
            var result = (ViewResult)this.homeController.Error(statusCode);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Error404", result!.ViewName);
        }
    }
}
