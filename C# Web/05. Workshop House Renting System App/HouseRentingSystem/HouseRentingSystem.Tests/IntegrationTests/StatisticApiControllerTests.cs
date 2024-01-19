using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Controllers.Api;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.Statistic;
using Moq;

namespace HouseRentingSystem.Tests.IntegrationTests
{
    public class StatisticApiControllerTests
    {
        private readonly StatisticApiController statisticApiController;
        private Mock<IStatisticsService> mockStatisticsService;
        public StatisticApiControllerTests()
        {
            mockStatisticsService = new Mock<IStatisticsService>();
            mockStatisticsService.Setup(x => x.Total())
                .Returns(new StatisticViewModel()
                {
                    TotalHouses = 6,
                    TotalRents = 1
                });

            this.statisticApiController = new StatisticApiController(mockStatisticsService.Object);
        }

        [Fact]
        public void GetStatistics_ShouldReturnCorrectCounts()
        {
            //Arrange

            //Act
            var result = this.statisticApiController.GetStatistics();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(6, result.TotalHouses);
            Assert.Equal(1, result.TotalRents);
        }
    }
}
