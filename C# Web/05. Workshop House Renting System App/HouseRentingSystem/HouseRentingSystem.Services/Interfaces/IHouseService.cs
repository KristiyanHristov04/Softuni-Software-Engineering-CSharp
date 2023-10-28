using HouseRentingSystem.ViewModels.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Interfaces
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexViewModel>> LastThreeHousesAsync();
    }
}
