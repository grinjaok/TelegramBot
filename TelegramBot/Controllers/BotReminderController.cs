using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBot.Interfaces;

namespace TelegramBot.Controllers
{
    public class BotReminderController : Controller
    {
        private readonly IChatService chatService;

        public BotReminderController(IChatService chatService)
        {
            this.chatService = chatService;
        }
        [HttpPost]
        [Route("api/inbox-message")]
        public async Task<IActionResult> InboxMessage([FromBody]Update update)
        {
            await this.chatService.IncomingMessage(update);
            return this.Ok();
        }
    }
}