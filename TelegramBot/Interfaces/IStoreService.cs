using System.Collections.Generic;
using TelegramBot.Entites;

namespace TelegramBot.Interfaces
{
    public interface IStorageService
    {
        void AddEventToStore();

        List<IncomingEvent> GetNextEvents();

        ChatHistory GetChatById(int chatId);

        void AddUpdateChat(ChatHistory chatHistory);
    }
}