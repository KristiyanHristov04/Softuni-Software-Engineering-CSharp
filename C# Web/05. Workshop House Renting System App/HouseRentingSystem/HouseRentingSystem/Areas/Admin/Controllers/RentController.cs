using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.ApplicationUser;
using HouseRentingSystem.ViewModels.House;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static HouseRentingSystem.Common.DataConstants.AdminUser;

namespace HouseRentingSystem.Areas.Admin.Controllers
{
    public class RentController : AdminController
    {
        private readonly IRentService rentService;
        private readonly IMemoryCache cache;
        public RentController(
            IRentService rentService,
            IMemoryCache cache)
        {
            this.rentService = rentService;
            this.cache = cache;
        }

        public async Task<IActionResult> All()
        {
            var rents = this.cache.Get(RentsCacheKey);

            if (rents == null)
            {
                rents = await this.rentService.AllRentedHousesAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                this.cache.Set(RentsCacheKey, rents, cacheOptions);
            }

            return View(rents);
        }
    }
}
