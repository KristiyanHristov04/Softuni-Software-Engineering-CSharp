using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.ApplicationUser;
using HouseRentingSystem.ViewModels.House;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

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
            IEnumerable<RentViewModel> rents
                = await rentService.AllRentedHousesAsync();

            return View(rents);
        }
    }
}
