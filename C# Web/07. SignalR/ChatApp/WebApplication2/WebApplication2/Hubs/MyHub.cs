using Microsoft.AspNetCore.SignalR;
using WebApplication2.Data;
using WebApplication2.Data.Models;

namespace WebApplication2.Hubs
{
    public class MyHub : Hub
    {
        private readonly ChatDbContext context;
        public MyHub(ChatDbContext context)
        {
            this.context = context;
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            ChatMessage newMessage = new ChatMessage()
            {
                Message = message,
                Username = user,
                Date = DateTime.Now
            };

            await this.context.ChatMessages.AddAsync(newMessage);
            await this.context.SaveChangesAsync();
        }
    }
}
