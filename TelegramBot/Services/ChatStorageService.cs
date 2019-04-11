using Microsoft.Extensions.Options;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using TelegramBot.Configurations;
using TelegramBot.Entities;
using TelegramBot.Interfaces;

namespace TelegramBot.Services
{
    public class ChatStorageService : IChatStorageService
    {
        private readonly IRedisTypedClient<ChatHistory> redisClient;

        public ChatStorageService(IOptions<BotConfiguration> config, IRedisClientsManager redisClientsManager)
        {
            this.redisClient = redisClientsManager.GetClient().As<ChatHistory>();
        }

        public ChatHistory GetChatById(long chatId)
        {
            var chat = this.redisClient.GetById(chatId);
            return chat;
        }

        public void AddNewChat(ChatHistory chatHistory)
        {
            var createdChat = this.redisClient.Store(chatHistory);
        }

        public void RemoveChat(ChatHistory chatHistory)
        {
            this.redisClient.DeleteById(chatHistory.Id);
        }
    }
}