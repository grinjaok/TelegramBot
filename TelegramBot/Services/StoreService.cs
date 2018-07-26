using System;
using System.Collections.Generic;
using TelegramBot.Entites;
using TelegramBot.Interfaces;

namespace TelegramBot.Services
{
    public class StoreService : IStoreService
    {
        private List<IncomingEvent> eventsStore;
        private List<Chat> chats;

        public StoreService()
        {
            this.eventsStore = new List<IncomingEvent>();
            this.chats = new List<Chat>();
        }

        public void AddEventToStore()
        {
        }

        public List<IncomingEvent> GetNextEvents()
        {
            throw new NotImplementedException();
        }

        public Chat GetChatById(long chatId)
        {
            throw new NotImplementedException();
        }

        public void AddUpdateChat(Chat chat)
        {

        }
    }
}