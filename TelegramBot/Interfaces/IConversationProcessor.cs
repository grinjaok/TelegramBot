using TelegramBot.Entities;
using TelegramBot.Enums;

namespace TelegramBot.Interfaces
{
    public interface IConversationProcessor
    {
        bool CanProcess(ChatStatusEnum chatStatus);

        string ProcessMessage(string message, ChatHistory chat);
    }
}