using Microsoft.AspNetCore.Mvc;

namespace TelegramBot.Controllers
{
    public class BotReminderController : Controller
    {
        public IActionResult Index()
        {
            return this.Ok();
        }
    }
}