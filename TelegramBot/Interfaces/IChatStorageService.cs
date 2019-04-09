using TelegramBot.Entities;

namespace TelegramBot.Interfaces
{
    public interface IChatStorageService
    {
        ChatHistory GetChatById(long chatId);

        void AddNewChat(ChatHistory chatHistory);

        void RemoveChat(ChatHistory chatHistory);
    }
}