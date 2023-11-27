using HouseRentingSystem.Common.Enums;
using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.Agent;
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

        public async Task DeleteAsync(int houseId)
        {
            House house = await this.context.Houses.FindAsync(houseId);

            this.context.Remove(house);
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync(int houseId, string title, string address, string description, string imageUrl, decimal price, int categoryId)
        {
            House houseToEdit = this.context.Houses.Find(houseId);

            houseToEdit.Title = title;
            houseToEdit.Address = address;
            houseToEdit.Description = description;
            houseToEdit.ImageUrl = imageUrl;
            houseToEdit.PricePerMonth = price;
            houseToEdit.CategoryId = categoryId;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            bool result = await this.context.Houses.AnyAsync(h => h.Id == id);
            return result;
        }

        public async Task<int> GetHouseCategoryIdAsync(int houseId)
        {
            House house = await this.context.Houses.FindAsync(houseId);
            return house.CategoryId;
        }

        public async Task<bool> HasAgentWithIdAsync(int houseId, string currentUserId)
        {
            House house = await this.context.Houses.FindAsync(houseId);
            Agent agent = await this.context.Agents.FirstOrDefaultAsync(a => a.Id == house.AgentId);

            if (agent == null)
            {
                return false;
            }

            if (agent.UserId != currentUserId)
            {
                return false;
            }

            return true;
        }

        public async Task<HouseDetailsViewModel> HouseDetailsByIdAsync(int id)
        {
            return await this.context.Houses
                    .Where(h => h.Id == id)
                    .Select(h => new HouseDetailsViewModel()
                    {
                        Id = h.Id,
                        Title = h.Title,
                        Address = h.Address,
                        Description = h.Description,
                        ImageUrl = h.ImageUrl,
                        PricePerMonth = h.PricePerMonth,
                        IsRented = h.RenterId != null ? true : false,
                        Category = h.Category.Name,
                        Agent = new AgentViewModel()
                        {
                            PhoneNumber = h.Agent.PhoneNumber,
                            Email = h.Agent.User.Email
                        }
                    })
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> IsRentedAsync(int id)
        {
            House house = await this.context.Houses.FindAsync(id);

            bool result = house.RenterId != null ? true : false;

            return result;
        }

        public async Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId)
        {
            House house = await this.context.Houses.FindAsync(houseId);

            if (house == null)
            {
                return false;
            }

            if (house.RenterId != userId)
            {
                return false;
            }

            return true;
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
                    ImageUrl = h.ImageUrl,
                    Address = h.Address
                })
                .Take(3)
                .ToListAsync();

            return houses;
        }

        public async Task LeaveAsync(int houseId)
        {
            var house = await this.context.Houses.FindAsync(houseId);

            house.RenterId = null;
            await this.context.SaveChangesAsync();
        }

        public async Task RentAsync(int houseId, string userId)
        {
            House house = await this.context.Houses.FindAsync(houseId);

            house.RenterId = userId;
            await this.context.SaveChangesAsync();
        }
    }
}
