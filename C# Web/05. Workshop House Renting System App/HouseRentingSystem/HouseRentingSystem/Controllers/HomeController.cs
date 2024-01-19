using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.Home;
using HouseRentingSystem.ViewModels.House;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static HouseRentingSystem.Common.DataConstants.AdminUser;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService houseService;
        public HomeController(IHouseService _houseService)
        {
            this.houseService = _houseService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRole))
            {
                return RedirectToAction("Index", "Home", new {area = "Admin"});
            }

            IEnumerable<HouseIndexViewModel> houses = await this.houseService.LastThreeHousesAsync();
            return View(houses);
        }

        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }
    }
}