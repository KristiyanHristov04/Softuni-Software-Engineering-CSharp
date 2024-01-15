using HouseRentingSystem.Areas.Admin.Models;
using HouseRentingSystem.Extensions;
using HouseRentingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Areas.Admin.Controllers
{
    public class HouseController : AdminController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        public HouseController(
            IHouseService houseService,
            IAgentService agentService)
        {
            this.houseService = houseService;
            this.agentService = agentService;
        }
        
        public async Task<IActionResult> Mine()
        {
            MyHousesViewModel myHouses = new MyHousesViewModel();

            string adminUserId = this.User.Id();
            myHouses.AddedHouses = await houseService.AllHousesByUserIdAsync(adminUserId);
            
            int adminAgentId = agentService.GetAgentId(adminUserId);
            myHouses.AddedHouses = await houseService.AllHousesByAgentIdAsync(adminAgentId);

            return View(myHouses);
        }
    }
}
