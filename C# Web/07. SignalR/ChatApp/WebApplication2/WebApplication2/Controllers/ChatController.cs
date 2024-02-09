using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Data.Models;

namespace WebApplication2.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatDbContext context;
        public ChatController(ChatDbContext context)
        {
            this.context = context;   
        }

        public async Task<IActionResult> Index()
        {
            List<ChatMessage> messages = await this.context.ChatMessages.OrderByDescending(x => x.Id).ToListAsync();

            return View(messages);
        }
    }
}
