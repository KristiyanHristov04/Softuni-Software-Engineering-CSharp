using HouseRentingSystem.Common.Extensions;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;
        public AgentController(IAgentService _agentService)
        {
            this.agentService = _agentService;
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
            if (await this.agentService.ExistsById(User.Id()))
            {
                return BadRequest();
            }

            if (await this.agentService.UserHasRents(User.Id()))
            {
                ModelState.AddModelError("Error",
                   "You should have no rents to become an agent!");
            }

            if (await this.agentService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber),
                   "Phone number already exists. Enter another one.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.agentService.Create(User.Id(), model.PhoneNumber);

            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
