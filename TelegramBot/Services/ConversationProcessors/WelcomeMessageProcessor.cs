using TelegramBot.Entities;
using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class WelcomeMessageProcessor : IConversationProcessor
    {
        private ChatStatusEnum chatStatus = ChatStatusEnum.HelloMessage;
        private readonly IChatStorageService chatStorageService;

        public WelcomeMessageProcessor(IChatStorageService chatStorageService)
        {
            this.chatStorageService = chatStorageService;
        }


        public bool CanProcess(ChatStatusEnum chatStatus)
        {
            return this.chatStatus == chatStatus;
        }

        public string ProcessMessage(string message, ChatHistory chat)
        {
            this.chatStorageService.AddNewChat(chat);
            return Resource.ResponseMessages.WELCOME_RESPONSE_MESSAGE;
        }
    }
}