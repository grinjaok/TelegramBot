using System.Collections.Generic;
using TelegramBot.Entities;

namespace TelegramBot.Interfaces
{
    public interface IStorageService
    {
        void AddEventToStore(IncomingEvent incomingEvent);

        List<IncomingEvent> GetNextEvents();

        void RemoveEvent(IncomingEvent incomingEvent);

        ChatHistory GetChatById(long chatId);

        void AddNewChat(ChatHistory chatHistory);

        void RemoveChat(ChatHistory chatHistory);
    }
}