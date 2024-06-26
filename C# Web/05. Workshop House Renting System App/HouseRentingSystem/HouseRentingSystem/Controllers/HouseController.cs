﻿using HouseRentingSystem.Extensions;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static HouseRentingSystem.Common.DataConstants.AdminUser;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        private readonly IMemoryCache cache;
        public HouseController(
            IHouseService _houseService,
            IAgentService _agentService,
            IMemoryCache cache)
        {
            this.houseService = _houseService;
            this.agentService = _agentService;
            this.cache = cache;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllHousesQueryModel query)
        {
            var queryResult = this.houseService.All(query.Category, query.SearchTerm, query.Sorting, query.CurrentPage, AllHousesQueryModel.HousesPerPage);

            query.TotalHousesCount = queryResult.TotalHousesCount;
            query.Houses = queryResult.Houses;

            List<string> houseCategories = (List<string>)await this.houseService.AllCategoriesNamesAsync();
            query.Categories = houseCategories;

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
            IEnumerable<HouseViewModel> houses = null;

            string currentUserId = this.User.Id();

            if (this.User.IsInRole(AdminRole))
            {
                return RedirectToAction("Mine", "House", new { area = AreaName });
            }

            if (await this.agentService.ExistsById(currentUserId))
            {
                int agentId = this.agentService.GetAgentId(currentUserId);

                houses = await this.houseService.AllHousesByAgentIdAsync(agentId);
            }
            else
            {
                houses = await this.houseService.AllHousesByUserIdAsync(currentUserId);
            }

            return View(houses);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await this.houseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            HouseDetailsViewModel model = await this.houseService.HouseDetailsByIdAsync(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            if (await this.agentService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            HouseFormModel model = new HouseFormModel();
            model.Categories = await this.houseService.AllCategoriesAsync();
            return View(model);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            if (await this.agentService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            if (await this.houseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId),
                    "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await this.houseService.AllCategoriesAsync();
                return View(model);
            }

            int agentId = this.agentService.GetAgentId(User.Id());

            int newHouseId = await this.houseService.CreateAsync
                (model.Title, model.Address, model.Description,
                 model.ImageUrl, model.PricePerMonth, model.CategoryId,
                 agentId);

            TempData["message"] = "You have successfully added a house";
            return RedirectToAction(nameof(Details), new { id = newHouseId, information = model.GetInformation() });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (await this.houseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await this.houseService.HasAgentWithIdAsync(id, this.User.Id()) == false)
            {
                return Unauthorized();
            }

            HouseDetailsViewModel house = await this.houseService.HouseDetailsByIdAsync(id);

            int houseCategoryId = await this.houseService.GetHouseCategoryIdAsync(house.Id);

            HouseFormModel model = new HouseFormModel()
            {
                Title = house.Title,
                Address = house.Address,
                Description = house.Description,
                ImageUrl = house.ImageUrl,
                PricePerMonth = house.PricePerMonth,
                CategoryId = houseCategoryId,
                Categories = await this.houseService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormModel model)
        {
            if (await this.houseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await this.houseService.HasAgentWithIdAsync(id, this.User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await this.houseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId),
                    "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await this.houseService.AllCategoriesAsync();

                return View(model);
            }

            await this.houseService.EditAsync(id, model.Title, model.Address, model.Description, model.ImageUrl, model.PricePerMonth, model.CategoryId);
            TempData["message"] = "You have successfully edited the house!";

            return RedirectToAction(nameof(Details), new { id = id, information = model.GetInformation() });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await this.houseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await this.houseService.HasAgentWithIdAsync(id, this.User.Id()) == false)
            {
                return Unauthorized();
            }

            HouseDetailsViewModel house = await this.houseService.HouseDetailsByIdAsync(id);

            var model = new HouseDeleteViewModel()
            {
                Title = house.Title,
                Address = house.Address,
                ImageUrl = house.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HouseDeleteViewModel model)
        {
            if (await this.houseService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await this.houseService.HasAgentWithIdAsync(model.Id, this.User.Id()) == false)
            {
                return Unauthorized();
            }

            await this.houseService.DeleteAsync(model.Id);
            TempData["message"] = "You have successfully deleted the house!";

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if (await this.houseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await this.agentService.ExistsById(User.Id()))
            {
                return Unauthorized();
            }

            if (await this.houseService.IsRentedAsync(id))
            {
                return BadRequest();
            }

            await this.houseService.RentAsync(id, this.User.Id());
            this.cache.Remove(RentsCacheKey);
            TempData["message"] = "You have successfully rented the house!";

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (await this.houseService.ExistsAsync(id) == false || 
                await this.houseService.IsRentedAsync(id) == false)
            {
                return BadRequest();
            }

            if (await this.houseService.IsRentedByUserWithIdAsync(id, this.User.Id()) == false)
            {
                return Unauthorized();
            }

            await this.houseService.LeaveAsync(id);
            this.cache.Remove(RentsCacheKey);
            TempData["message"] = "You have successfully left the house!";

            return RedirectToAction(nameof(Mine));
        }
    }
}
