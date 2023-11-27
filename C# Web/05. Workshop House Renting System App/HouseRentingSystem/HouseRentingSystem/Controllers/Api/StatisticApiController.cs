using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.Statistic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers.Api
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticsService statisticService;
        public StatisticApiController(IStatisticsService _statisticService)
        {
            this.statisticService = _statisticService;
        }

        [HttpGet]
        public StatisticViewModel GetStatistics()
        {
            return this.statisticService.Total();
        }
    }
}
