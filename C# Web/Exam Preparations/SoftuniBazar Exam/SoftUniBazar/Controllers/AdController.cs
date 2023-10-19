using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models.Ad;
using SoftUniBazar.Models.Category;
using System.Net;
using System.Security.Claims;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext context;
        public AdController(BazarDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IActionResult> All()
        {
            List<AdViewModel> adsViewModel = await context.Ads.Select(a => new AdViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Price = a.Price,
                Owner = a.Owner.UserName,
                ImageUrl = a.ImageUrl,
                CreatedOn = a.CreatedOn,
                Category = a.Category.Name
            })
            .ToListAsync();

            return View(adsViewModel);
        }

        public async Task<IActionResult> Add()
        {
            AdFormModel adFormModel = new AdFormModel();
            adFormModel.Categories = await GetCategories();
            return View(adFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel adFormModel)
        {
            if (!ModelState.IsValid)
            {
                adFormModel.Categories = await GetCategories();
                return View(adFormModel);
            }

            Ad ad = new Ad()
            {
                Name = adFormModel.Name,
                Description = adFormModel.Description,
                Price = adFormModel.Price,
                OwnerId = GetUserId(),
                ImageUrl = adFormModel.ImageUrl,
                CreatedOn = DateTime.Now,
                CategoryId = adFormModel.CategoryId
            };

            await context.Ads.AddAsync(ad);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id)
        {
            string currentUserId = GetUserId();

            Ad adToEdit = await context.Ads.FindAsync(id);

            if (adToEdit.OwnerId != currentUserId)
            {
                return BadRequest();
            }

            EditFormModel editFormModel = new EditFormModel()
            {
                Name = adToEdit.Name,
                Description = adToEdit.Description,
                Price = adToEdit.Price,
                ImageUrl = adToEdit.ImageUrl,
                CategoryId = adToEdit.CategoryId,
                Categories = await GetCategories()
            };

            return View(editFormModel);
        }

        public async Task<IActionResult> Cart()
        {
            string currentUserId = GetUserId();

            List<CartViewModel> currentUserAds = await context.AdsBuyers
                .Where(ab => ab.BuyerId == currentUserId)
                .Select(ab => new CartViewModel()
                {
                    Id = ab.AdId,
                    Name = ab.Ad.Name,
                    Description = ab.Ad.Description,
                    Price = ab.Ad.Price,
                    ImageUrl = ab.Ad.ImageUrl,
                    CreatedOn = ab.Ad.CreatedOn,
                    Owner = ab.Ad.Owner.UserName,
                    Category = ab.Ad.Category.Name
                })
                .ToListAsync();

            return View(currentUserAds);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            string currentUserId = GetUserId();

            if (context.AdsBuyers.Any(ab => ab.AdId == id && ab.BuyerId == currentUserId))
            {
                return RedirectToAction(nameof(All));
            }

            AdBuyer adBuyer = new AdBuyer()
            {
                AdId = id,
                BuyerId = currentUserId
            };

            await context.AdsBuyers.AddAsync(adBuyer);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Cart));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string currentUserId = GetUserId();
            AdBuyer removeAdBuyer = context.AdsBuyers.First(ab => ab.AdId == id && currentUserId == ab.BuyerId);

            context.AdsBuyers.Remove(removeAdBuyer);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditFormModel editFormModel)
        {
            if (!ModelState.IsValid)
            {
                editFormModel.Categories = await GetCategories();
                return View(editFormModel);
            }

            Ad editedAd = await context.Ads.FindAsync(id);
            editedAd.Name = editFormModel.Name;
            editedAd.Description = editFormModel.Description;
            editedAd.Price = editFormModel.Price;
            editedAd.ImageUrl = editFormModel.ImageUrl;
            editedAd.CategoryId = editFormModel.CategoryId;

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private async Task<List<CategoryViewModel>> GetCategories()
        {
            List<CategoryViewModel> categories = await context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
            .ToListAsync();

            return categories;
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        }
    }
}
