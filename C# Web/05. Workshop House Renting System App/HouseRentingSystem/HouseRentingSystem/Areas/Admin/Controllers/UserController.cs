using HouseRentingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IApplicationUserService userService;
        public UserController(IApplicationUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> All()
        {
            var users = await userService.AllAsync();
            return View(users);
        }
    }
}
