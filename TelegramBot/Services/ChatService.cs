using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.Entities;
using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services
{
    public class ChatService : IChatService
    {
        private readonly IBotService botService;
        private readonly IChatStorageService chatStorageService;
        private readonly IConversationProcessorFactory conversationProcessorFactory;

        public ChatService(IBotService botService, IChatStorageService chatStorageService, IConversationProcessorFactory conversationProcessorFactory)
        {
            this.botService = botService;
            this.chatStorageService = chatStorageService;
            this.conversationProcessorFactory = conversationProcessorFactory;
        }

        public void IncomingMessage(Update update)
        {
            try
            {
                ChatHistory chat = this.chatStorageService.GetChatById(update.Message.Chat.Id) ?? this.CreateNewChat(update.Message.Chat.Id);
                IConversationProcessor processor = this.conversationProcessorFactory.GetConversationProcessor((ChatStatusEnum)chat.ChatProgress.Count);
                string responseMessage = processor.ProcessMessage(update.Message.Text, chat);
                this.botService.Client.SendTextMessageAsync(chat.Id, responseMessage);
            }
            catch (Exception e)
            {
            }
        }

        private ChatHistory CreateNewChat(long id)
        {
            return new ChatHistory()
            {
                Id = id
            };
        }
    }
}