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

        public void AddEventToStore()
        {
        }

        public List<IncomingEvent> GetNextEvents()
        {
            throw new NotImplementedException();
        }

        public ChatHistory GetChatById(long chatId)
        {
            return this.chats.FirstOrDefault(x => x.ChatId == chatId);
        }

        public void AddNewChat(ChatHistory chatHistory)
        {
            this.chats.Add(chatHistory);
        }
    }
}