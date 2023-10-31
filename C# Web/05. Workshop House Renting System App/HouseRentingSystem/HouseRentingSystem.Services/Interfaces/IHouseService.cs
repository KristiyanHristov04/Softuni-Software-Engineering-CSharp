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
    }
}
