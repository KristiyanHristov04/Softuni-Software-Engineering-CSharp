using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly HouseRentingDbContext context;
        public StatisticsService(HouseRentingDbContext _context)
        {
            this.context = _context;
        }

        public StatisticViewModel Total()
        {
            int totalHouses = this.context.Houses.Count();
            int totalRents = this.context.Houses.Where(h => h.RenterId != null).Count();

            StatisticViewModel statistics = new StatisticViewModel()
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents
            };

            return statistics;
        }
    }
}
