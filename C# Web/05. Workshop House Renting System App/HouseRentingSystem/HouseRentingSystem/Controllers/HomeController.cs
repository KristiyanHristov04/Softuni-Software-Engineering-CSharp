using HouseRentingSystem.Models;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.Home;
using HouseRentingSystem.ViewModels.House;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            IEnumerable<HouseIndexViewModel> houses = await this.houseService.LastThreeHousesAsync();
            return View(houses);
        }
    }
}