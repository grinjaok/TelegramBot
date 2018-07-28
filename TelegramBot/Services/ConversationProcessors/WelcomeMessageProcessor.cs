using TelegramBot.Entities;
using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class WelcomeMessageProcessor : IConversationProcessor
    {
        private ChatStatusEnum chatStatus = ChatStatusEnum.HelloMessage;
        private readonly IStorageService storageService;

        public WelcomeMessageProcessor(IStorageService storageService)
        {
            this.storageService = storageService;
        }


        public bool CanProcess(ChatStatusEnum chatStatus)
        {
            return this.chatStatus == chatStatus;
        }

        public string ProcessMessage(string message, ChatHistory chat)
        {
            chat.ChatProgress.Add(ChatStatusEnum.HelloMessage, message);
            this.storageService.AddNewChat(chat);
            return Resource.ResponseMessages.WELCOME_RESPONSE_MESSAGE;
        }
    }
}