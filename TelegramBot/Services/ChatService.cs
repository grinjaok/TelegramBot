using Telegram.Bot.Types;
using TelegramBot.Interfaces;

namespace TelegramBot.Services
{
    public class ChatService : IChatService
    {
        private readonly IBotService botService;

        public ChatService(IBotService botService)
        {
            this.botService = botService;
        }

        public void IncomingMessage(Update update)
        {
            this.botService.Client.SendTextMessageAsync(update.Id, "yo!");
        }
    }
}