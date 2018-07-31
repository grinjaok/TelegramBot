using System;
using System.Collections.Generic;
using System.Linq;
using TelegramBot.Entities;
using TelegramBot.Interfaces;

namespace TelegramBot.Services
{
    public class StorageService : IStorageService
    {
        private List<IncomingEvent> eventsStore;
        private List<ChatHistory> chats;

        public StorageService()
        {
            this.eventsStore = new List<IncomingEvent>();
            this.chats = new List<ChatHistory>();
        }

        public void AddEventToStore(IncomingEvent incomingEvent)
        {
            this.eventsStore.Add(incomingEvent);
        }

        public List<IncomingEvent> GetNextEvents()
        {
            int minutesInterval = 5;
            int timeZoneShift = 3;
            // todo in future add synchronization for user and server timezones
            return this.eventsStore.Where(x => x.InvocationTime > DateTime.Now.AddHours(timeZoneShift) &&
                                               x.InvocationTime < DateTime.Now.AddMinutes(minutesInterval).AddHours(timeZoneShift)).ToList();
        }

        public void RemoveEvent(IncomingEvent incomingEvent)
        {
            this.eventsStore.Remove(incomingEvent);
        }

        public ChatHistory GetChatById(long chatId)
        {
            return this.chats.FirstOrDefault(x => x.ChatId == chatId);
        }

        public void AddNewChat(ChatHistory chatHistory)
        {
            this.chats.Add(chatHistory);
        }

        public void RemoveChat(ChatHistory chatHistory)
        {
            this.chats.Remove(chatHistory);
        }
    }
}