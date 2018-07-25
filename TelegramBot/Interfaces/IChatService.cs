using Telegram.Bot.Types;

namespace TelegramBot.Interfaces
{
    public interface IChatService
    {
        void IncomingMessage(Update update);
    }
}