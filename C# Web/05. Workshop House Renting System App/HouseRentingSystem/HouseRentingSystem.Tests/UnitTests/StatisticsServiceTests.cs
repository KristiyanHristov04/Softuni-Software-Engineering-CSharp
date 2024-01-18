using HouseRentingSystem.Services;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.Tests.Mocks;
using HouseRentingSystem.ViewModels.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Tests.UnitTests
{
    public class StatisticsServiceTests : UnitTestsBase
    {
        private IStatisticsService statisticsService;
        public StatisticsServiceTests()
        {
            this.statisticsService = new StatisticsService(this.data);
        }


        [Fact]
        public async Task Total_ShouldReturnCorrectCounts()
        {
            //Arrange

            //Act
            StatisticViewModel statistics = this.statisticsService.Total();

            //Assert
            int housesCount = this.data.Houses.Count();
            int rentedHouses = this.data.Houses.Where(h => h.RenterId != null).Count();

            Assert.NotNull(statistics);
            Assert.Equal(housesCount, statistics.TotalHouses);
            Assert.Equal(rentedHouses, statistics.TotalRents);
        }
    }
}
