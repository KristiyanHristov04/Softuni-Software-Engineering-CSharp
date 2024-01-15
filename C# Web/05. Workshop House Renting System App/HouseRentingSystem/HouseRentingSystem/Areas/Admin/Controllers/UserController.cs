using HouseRentingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static HouseRentingSystem.Common.DataConstants.AdminUser;

namespace HouseRentingSystem.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IApplicationUserService userService;
        private readonly IMemoryCache cache;
        public UserController(
            IApplicationUserService userService,
            IMemoryCache cache)
        {
            this.userService = userService;
            this.cache = cache;
        }

        public async Task<IActionResult> All()
        {
            var users = cache.Get(UsersCacheKey);

            if (users == null)
            {
                users = await userService.AllAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                cache.Set(UsersCacheKey, users, cacheOptions);
            }

            return View(users);
        }
    }
}
