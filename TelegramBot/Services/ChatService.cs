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
        private readonly IStorageService storageService;
        private readonly IConversationProcessorFactory conversationProcessorFactory;

        public ChatService(IBotService botService, IStorageService storageService, IConversationProcessorFactory conversationProcessorFactory)
        {
            this.botService = botService;
            this.storageService = storageService;
            this.conversationProcessorFactory = conversationProcessorFactory;

        }

        public void IncomingMessage(Update update)
        {
            ChatHistory chat = this.storageService.GetChatById(update.Message.Chat.Id) ?? this.CreateNewChat(update.Message.Chat.Id);
            IConversationProcessor processor = this.conversationProcessorFactory.GetConversationProcessor((ChatStatusEnum)chat.ChatProgress.Count);
            string responseMessage = processor.ProcessMessage(update.Message.Text, chat);
            this.botService.Client.SendTextMessageAsync(chat.ChatId, responseMessage);
        }

        private ChatHistory CreateNewChat(long id)
        {
            return new ChatHistory()
            {
                ChatId = id
            };
        }
    }
}