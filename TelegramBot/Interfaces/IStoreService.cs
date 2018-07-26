using System.Collections.Generic;
using TelegramBot.Entites;

namespace TelegramBot.Interfaces
{
    public interface IStoreService
    {
        void AddEventToStore();

        List<IncomingEvent> GetNextEvents();
    }
}