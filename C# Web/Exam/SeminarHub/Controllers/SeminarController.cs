using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.ViewModels;
using System.Globalization;
using System.Security.Claims;
using static SeminarHub.Common.DataConstants.Seminar;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext context;
        public SeminarController(SeminarHubDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            SeminarFormModel model = new SeminarFormModel();
            model.Categories = await GetCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategoriesAsync();
                return View(model);
            }

            DateTime dateAndTime;

            bool isDateValid = DateTime.TryParseExact(model.DateAndTime, DateAndTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime);

            if (!isDateValid)
            {
                ModelState.AddModelError(string.Empty, $"Date format must be: {DateAndTimeFormat}");
                model.Categories = await GetCategoriesAsync();
                return View(model);
            }

            if (!this.context.Categories.Any(c => c.Id == model.CategoryId))
            {
                ModelState.AddModelError(string.Empty, $"Invalid Category!");
                model.Categories = await GetCategoriesAsync();
                return View(model);
            }

            Seminar newSeminar = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                OrganizerId = GetUserId(),
                DateAndTime = dateAndTime,
                Duration = model.Duration,
                CategoryId = model.CategoryId
            };

            await this.context.Seminars.AddAsync(newSeminar);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<SeminarViewModel> allSeminars = await this.context.Seminars
                .Select(s => new SeminarViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    DateAndTime = s.DateAndTime.ToString(DateAndTimeFormat),
                    Organizer = s.Organizer.UserName
                })
                .ToListAsync();

            return View(allSeminars);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Seminar? seminar = await this.context.Seminars.Where(s => s.Id == id).FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            SeminarFormModel seminarToEdit = new SeminarFormModel()
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Details,
                DateAndTime = seminar.DateAndTime.ToString(DateAndTimeFormat),
                Duration = seminar.Duration,
                CategoryId = seminar.CategoryId,
                Categories = await GetCategoriesAsync()
            };

            return View(seminarToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SeminarFormModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategoriesAsync();
                return View(model);
            }

            DateTime dateAndTime;

            bool isDateValid = DateTime.TryParseExact(model.DateAndTime, DateAndTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime);

            if (!isDateValid)
            {
                ModelState.AddModelError(string.Empty, $"Date format must be: {DateAndTimeFormat}");
                model.Categories = await GetCategoriesAsync();
                return View(model);
            }

            if (!this.context.Categories.Any(c => c.Id == model.CategoryId))
            {
                ModelState.AddModelError(string.Empty, $"Invalid Category!");
                model.Categories = await GetCategoriesAsync();
                return View(model);
            }

            Seminar seminar = await this.context.Seminars.Where(s => s.Id == id).FirstAsync();

            seminar.Topic = model.Topic;
            seminar.Lecturer = model.Lecturer;
            seminar.Details = model.Details;
            seminar.DateAndTime = dateAndTime;
            seminar.Duration = model.Duration;
            seminar.CategoryId = model.CategoryId;

            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            if (!this.context.SeminarsParticipants.Any(sp => sp.SeminarId == id &&
                sp.ParticipantId == GetUserId()))
            {
                SeminarParticipant seminarParticipant = new SeminarParticipant()
                {
                    SeminarId = id,
                    ParticipantId = GetUserId()
                };

                await this.context.SeminarsParticipants.AddAsync(seminarParticipant);
                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(Joined));
            }
            else
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            SeminarParticipant seminarParticipant = await this.context.SeminarsParticipants
                .Where(sp => sp.SeminarId == id && sp.ParticipantId == GetUserId())
                .FirstAsync();

            this.context.SeminarsParticipants.Remove(seminarParticipant);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string currentUserId = GetUserId();

            List<int> seminarsIds = await this.context.SeminarsParticipants
                .Where(sp => sp.ParticipantId == currentUserId)
                .Select(sp => sp.SeminarId)
                .ToListAsync();

            List<SeminarViewModel> seminars = await this.context.Seminars
                .Where(s => seminarsIds.Contains(s.Id))
                .Select(s => new SeminarViewModel()
                {
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    DateAndTime = s.DateAndTime.ToString(DateAndTimeFormat),
                    Id = s.Id
                })
                .ToListAsync();

            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Seminar? seminar = await this.context.Seminars.Where(s => s.Id == id)
                .Include(s => s.Organizer)
                .Include(s => s.Category)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            SeminarDetailsViewModel detailsModel = new SeminarDetailsViewModel()
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                DateAndTime = seminar.DateAndTime.ToString(DateAndTimeFormat),
                Id = seminar.Id,
                Organizer = seminar.Organizer.UserName,
                Category = seminar.Category.Name,
                Details = seminar.Details,
                Duration = seminar.Duration
            };

            return View(detailsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Seminar? seminar = await this.context.Seminars
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            SeminarDeleteViewModel seminarToDelete = new SeminarDeleteViewModel()
            {
                Id = seminar.Id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime
            };

            return View(seminarToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(SeminarDeleteViewModel model)
        {
            Seminar seminarToDelete = await this.context.Seminars
                .Where(s => s.Id == model.Id)
                .FirstAsync();

            var seminarsToDeleteFromMappTable = await this.context.SeminarsParticipants
                .Where(sp => sp.SeminarId == model.Id)
                .ToListAsync();

            foreach (var seminarParticipant in seminarsToDeleteFromMappTable)
            {
                this.context.SeminarsParticipants.Remove(seminarParticipant);
                await this.context.SaveChangesAsync();
            }

            this.context.Seminars.Remove(seminarToDelete);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        }

        private async Task<List<CategoryViewModel>> GetCategoriesAsync()
        {
            return await this.context.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
        }
    }
}
