using ChatApp.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> sMessages =
            new List<KeyValuePair<string, string>>();
        
        public IActionResult Show()
        {
            if (sMessages.Count() < 1)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = sMessages
                        .Select(m => new MessageViewModel()
                        {
                            Sender = m.Key,
                            MessageText = m.Value
                        })
                        .ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;
            sMessages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));
            return RedirectToAction("Show");
        }
    }
}
