using HouseRentingSystem.Common.Enums;
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

        public HouseQueryViewModel All(string category = null, string searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            List<House> housesQuery = this.context.Houses.ToList();

            if (!string.IsNullOrWhiteSpace(category))
            {
                housesQuery = this.context.Houses.Where(h => h.Category.Name == category).ToList();
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                housesQuery = housesQuery
                    .Where(h =>
                    h.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Address.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Description.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            switch (sorting)
            {
                case HouseSorting.Price:
                    housesQuery = housesQuery.OrderBy(h => h.PricePerMonth).ToList();
                    break;
                case HouseSorting.NotRentedFirst:
                    housesQuery = housesQuery.OrderBy(h => h.RenterId != null)
                        .ThenByDescending(h => h.Id).ToList();
                    break;
                case HouseSorting.Newest:
                    housesQuery = housesQuery.OrderByDescending(h => h.Id).ToList();
                    break;
            }

            List<HouseViewModel> houses = housesQuery
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(h => new HouseViewModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null ? true : false,
                    PricePerMonth = h.PricePerMonth
                })
                .ToList();

            int totalHouses = housesQuery.Count();

            return new HouseQueryViewModel()
            {
                Houses = houses,
                TotalHousesCount = totalHouses
            };
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

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await this.context.Categories.Select(c => c.Name).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<HouseViewModel>> AllHousesByAgentIdAsync(int agentId)
        {
            List<HouseViewModel> agentHouses = await this.context.Houses
                .Where(h => h.AgentId == agentId)
                .Select(h => new HouseViewModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null ? true : false
                })
                .ToListAsync();

            return agentHouses;
        }

        public async Task<IEnumerable<HouseViewModel>> AllHousesByUserIdAsync(string userId)
        {
            List<HouseViewModel> userHouses = await this.context.Houses
                .Where(h => h.RenterId == userId)
                .Select(h => new HouseViewModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null ? true : false
                })
                .ToListAsync();

            return userHouses;
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
