using Homies.Data;
using Homies.Data.Models;
using Homies.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext context;
        public EventController(HomiesDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<EventViewModel> events = await this.context.Events.Select(e => new EventViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start,
                Type = e.Type.Name,
                Organiser = e.Organiser.UserName
            })
                .ToListAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventFormModel model = new EventFormModel();
            model.Types = await GetTypesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Types = await GetTypesAsync();
                return View(model);
            }

            string currentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            Event newEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                OrganiserId = currentUserId,
                CreatedOn = DateTime.Now,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId
            };

            await this.context.Events.AddAsync(newEvent);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string currentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var allEventsCurrentUserParticipatesIn = await this.context.EventParticipant
                .Where(ep => ep.HelperId == currentUserId)
                .Select(ep => ep.EventId)
                .ToListAsync();

            List<EventViewModel> allJoinedEvents = await this.context.Events
                .Where(e => allEventsCurrentUserParticipatesIn.Contains(e.Id))
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();

            return View(allJoinedEvents);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            Event? joinEvent = await this.context.Events.FindAsync(id);

            string currentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            if (this.context.EventParticipant
                .Any(ep => ep.HelperId == currentUserId && ep.EventId == joinEvent.Id))
            {
                return RedirectToAction(nameof(All));
            }

            EventParticipant newEventParticipant = new EventParticipant()
            {
                HelperId = currentUserId,
                EventId = joinEvent.Id
            };

            await context.EventParticipant.AddAsync(newEventParticipant);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            EventParticipant? eventToLeave = await this.context.EventParticipant
                .Where(ep => ep.EventId == id)
                .FirstAsync();

            this.context.Remove(eventToLeave);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            EventDetailsViewModel eventDetails = await this.context.Events
                .Where(e => e.Id == id)
                .Select(e => new EventDetailsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    Organiser = e.Organiser.UserName,
                    CreatedOn = e.CreatedOn,
                    Type = e.Type.Name
                }).FirstAsync();

            return View(eventDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string currentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            Event? eventToEdit = await this.context.Events.FindAsync(id);

            if (eventToEdit == null)
            {
                return BadRequest();
            }

            if (eventToEdit.OrganiserId != currentUserId)
            {
                return Unauthorized();
            }

            EventFormModel model = await this.context.Events
                .Where(e => e.Id == id)
                .Select(e => new EventFormModel()
                {
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    TypeId = e.TypeId
                })
                .FirstAsync();

            model.Types = await GetTypesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormModel model)
        {
            Event eventToEdit = await this.context.Events.FindAsync(id);
            eventToEdit.Name = model.Name;
            eventToEdit.Description = model.Description;
            eventToEdit.Start = model.Start;
            eventToEdit.End = model.End;
            eventToEdit.TypeId = model.TypeId;

            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private async Task<List<TypeViewModel>> GetTypesAsync()
        {
            List<TypeViewModel> types = await this.context.Types
                .Select(t => new TypeViewModel
            {
                Id = t.Id,
                Name = t.Name
            })
                .ToListAsync();

            return types;
        }
    }
}
