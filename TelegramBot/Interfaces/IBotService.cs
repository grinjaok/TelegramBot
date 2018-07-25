using Telegram.Bot;

namespace TelegramBot.Interfaces
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}