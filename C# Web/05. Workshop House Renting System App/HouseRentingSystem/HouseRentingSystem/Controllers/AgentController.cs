using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Extensions;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;
        private readonly IApplicationUserService userService;
        public AgentController(
            IAgentService _agentService,
            IApplicationUserService userService)
        {
            this.agentService = _agentService;
            this.userService = userService;
        }

        public async Task<IActionResult> Become()
        {
            if (await this.agentService.ExistsById(User.Id()))
            {
                return BadRequest();
            }

            BecomeAgentFormModel model = new BecomeAgentFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            var userId = User.Id;

            if (await this.userService.UserHasRents(User.Id()))
            {
                ModelState.AddModelError("Error",
                   "You should have no rents to become an agent!");
            }

            if (await this.agentService.AgentWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber),
                   "Phone number already exists. Enter another one.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.agentService.Create(User.Id(), model.PhoneNumber);
            TempData["message"] = "You have successfully became an agent";

            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
