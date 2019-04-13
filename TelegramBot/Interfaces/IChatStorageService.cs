using TelegramBot.Entities;

namespace TelegramBot.Interfaces
{
    public interface IChatStorageService
    {
        ChatHistory GetChatById(long chatId);

        void AddUpdateChat(ChatHistory chatHistory);

        void RemoveChat(ChatHistory chatHistory);
    }
}