using HouseRentingSystem.Common.Enums;
using HouseRentingSystem.ViewModels.Category;
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

        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(string title, string address, string description, string imageUrl, decimal price, int categoryId, int agentId);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        HouseQueryViewModel All(string category = null, string searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1);

        Task<IEnumerable<HouseViewModel>> AllHousesByAgentIdAsync(int agentId);

        Task<IEnumerable<HouseViewModel>> AllHousesByUserIdAsync(string userId);

        Task<bool> ExistsAsync(int id);

        Task<HouseDetailsViewModel> HouseDetailsByIdAsync(int id);

        Task EditAsync(int houseId, string title, string address, string description, string imageUrl, decimal price, int categoryId);

        Task<bool> HasAgentWithIdAsync(int houseId, string currentUserId);

        Task<int> GetHouseCategoryIdAsync(int houseId);

        Task DeleteAsync(int houseId);

        Task<bool> IsRentedAsync(int id);

        Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId);

        Task RentAsync(int houseId, string userId);
        Task LeaveAsync(int houseId);
    }
}
