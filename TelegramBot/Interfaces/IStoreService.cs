using System.Collections.Generic;
using TelegramBot.Entities;

namespace TelegramBot.Interfaces
{
    public interface IStorageService
    {
        void AddEventToStore();

        List<IncomingEvent> GetNextEvents();

        ChatHistory GetChatById(long chatId);

        void AddNewChat(ChatHistory chatHistory);
    }
}