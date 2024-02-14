using Contacts.Data;
using Contacts.Data.Models;
using Contacts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly ContactsDbContext context;
        public ContactsController(ContactsDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<ContactViewModel> contacts = await this.context.Contacts
                .Select(c => new ContactViewModel()
                {
                    ContactId = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Website = c.Website
                })
                .ToListAsync();

            return View(contacts);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Contact newContact = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Website = model.Website
            };

            await this.context.Contacts.AddAsync(newContact);
            await this.context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int contactId)
        {
            Contact? contactToEdit = await this.context.Contacts.FirstOrDefaultAsync(c => c.Id == contactId);

            if (contactToEdit == null)
            {
                return BadRequest();
            }

            ContactFormModel model = new ContactFormModel()
            {
                ContactId = contactId,
                FirstName = contactToEdit.FirstName,
                LastName = contactToEdit.LastName,
                Email = contactToEdit.Email,
                PhoneNumber = contactToEdit.PhoneNumber,
                Address = contactToEdit.Address,
                Website = contactToEdit.Website
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactFormModel model)
        {
            Contact? contactToEdit = await this.context.Contacts.FirstOrDefaultAsync(c => c.Id == model.ContactId);

            if (contactToEdit == null)
            {
                return BadRequest();
            }

            contactToEdit.FirstName = model.FirstName;
            contactToEdit.LastName = model.LastName;
            contactToEdit.Email = model.Email;
            contactToEdit.Address = model.Address;
            contactToEdit.Website = model.Website;
            contactToEdit.PhoneNumber = model.PhoneNumber;

            await this.context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int contactId)
        {
            string currentUserId = GetCurrentUserId();

            if (!await this.context.ApplicationUserContacts
                .AnyAsync(auc => auc.ContactId == contactId && auc.ApplicationUserId == currentUserId))
            {
                ApplicationUserContact newUserContact = new ApplicationUserContact()
                {
                    ContactId = contactId,
                    ApplicationUserId = currentUserId
                };

                await this.context.ApplicationUserContacts.AddAsync(newUserContact);
                await this.context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int contactId)
        {
            string currentUserId = GetCurrentUserId();

            ApplicationUserContact? userContactToRemove = await this.context.ApplicationUserContacts
                .FirstOrDefaultAsync(auc => auc.ContactId == contactId && auc.ApplicationUserId == currentUserId);

            if (userContactToRemove == null)
            {
                return BadRequest();
            }

            this.context.ApplicationUserContacts.Remove(userContactToRemove);
            await this.context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Team));
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {
            string currentUserId = GetCurrentUserId();

            List<ContactViewModel> contacts = await this.context.ApplicationUserContacts.Where(auc => auc.ApplicationUserId == currentUserId)
                .Select(auc => new ContactViewModel()
                {
                    ContactId = auc.ContactId,
                    FirstName = auc.Contact.FirstName,
                    LastName = auc.Contact.LastName,
                    Email = auc.Contact.Email,
                    PhoneNumber = auc.Contact.PhoneNumber,
                    Address = auc.Contact.Address,
                    Website = auc.Contact.Website
                })
                .ToListAsync();

            return View(contacts);
        }

        private string GetCurrentUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        }
    }
}
