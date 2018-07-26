using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.Entites;
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

        public async Task IncomingMessage(Update update)
        {
            ChatHistory chat = this.storageService.GetChatById(update.Id) ?? this.CreateNewChat(update.Id);
            IConversationProcessor processor = this.conversationProcessorFactory.GetConversationProcessor(chat.ChatProgress.Keys.Last());
            string responseMessage = processor.ProcessMessage(update.Message.Text);
            await this.botService.Client.SendTextMessageAsync(chat.ChatId, responseMessage);
        }

        private ChatHistory CreateNewChat(int id)
        {
            return new ChatHistory()
            {
                ChatId = id
            };
        }
    }
}