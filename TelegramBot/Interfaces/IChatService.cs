using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBot.Interfaces
{
    public interface IChatService
    {
        Task IncomingMessage(Update update);
    }
}