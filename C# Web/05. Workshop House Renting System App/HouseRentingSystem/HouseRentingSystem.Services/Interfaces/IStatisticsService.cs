using HouseRentingSystem.ViewModels.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Interfaces
{
    public interface IStatisticsService
    {
        StatisticViewModel Total();
    }
}
