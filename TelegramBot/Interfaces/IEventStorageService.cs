using System.Collections.Generic;
using TelegramBot.Entities;

namespace TelegramBot.Interfaces
{
    public interface IEventStorageService
    {
        void AddEventToStore(IncomingEvent incomingEvent);

        List<IncomingEvent> GetNextEvents();

        void RemoveEvent(IncomingEvent incomingEvent);
    }
}