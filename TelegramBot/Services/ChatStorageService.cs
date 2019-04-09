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
            return this.redisClient.GetById(chatId);
        }

        public void AddNewChat(ChatHistory chatHistory)
        {
            this.redisClient.Store(chatHistory);
        }

        public void RemoveChat(ChatHistory chatHistory)
        {
            this.redisClient.DeleteById(chatHistory.Id);
        }
    }
}