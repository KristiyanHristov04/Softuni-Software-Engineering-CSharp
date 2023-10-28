using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.House;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext context;
        public HouseService(HouseRentingDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<HouseIndexViewModel>> LastThreeHousesAsync()
        {
            List<HouseIndexViewModel> houses =
                await this.context.Houses
                .OrderByDescending(h => h.Id)
                .Select(h => new HouseIndexViewModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl
                })
                .Take(3)
                .ToListAsync();

            return houses;                          
        }
    }
}
