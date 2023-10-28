using HouseRentingSystem.Models;
using HouseRentingSystem.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(new IndexViewModel());
        }
    }
}