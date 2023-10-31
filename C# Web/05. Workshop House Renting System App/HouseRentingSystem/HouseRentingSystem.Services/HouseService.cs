using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.Category;
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

        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
        {
            List<CategoryViewModel> categories = await this.context.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();

            return categories;
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await this.context.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(string title, string address, string description, string imageUrl, decimal price, int categoryId, int agentId)
        {
            House house = new House()
            {
                Title = title,
                Address = address,
                Description = description,
                ImageUrl = imageUrl,
                PricePerMonth = price,
                AgentId = agentId,
                CategoryId = categoryId
            };

            await this.context.Houses.AddAsync(house);
            await this.context.SaveChangesAsync();

            return house.Id;
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
