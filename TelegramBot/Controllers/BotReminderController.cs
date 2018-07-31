using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBot.Interfaces;

namespace TelegramBot.Controllers
{
    public class BotReminderController : Controller
    {
        private readonly IChatService chatService;
        private readonly IEventService eventService;

        public BotReminderController(IChatService chatService, IEventService eventService)
        {
            this.chatService = chatService;
            this.eventService = eventService;
        }
        [HttpPost]
        [Route("api/inbox-message")]
        public IActionResult InboxMessage([FromBody]Update update)
        {
            this.chatService.IncomingMessage(update);
            return this.Ok();
        }

        [HttpGet]
        [Route("api/event-remind")]
        public IActionResult EventRemind()
        {
            this.eventService.RemindNextEvents();
            return this.Ok();
        }
    }
}