using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
            => View();
    }
}
