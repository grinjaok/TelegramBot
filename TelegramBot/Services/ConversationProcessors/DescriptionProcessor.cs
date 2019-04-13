using TelegramBot.Entities;
using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class DescriptionProcessor : IConversationProcessor
    {
        private ChatStatusEnum chatStatus = ChatStatusEnum.DescriptionEntered;
        private readonly IChatStorageService chatStorageService;

        public DescriptionProcessor(IChatStorageService chatStorageService)
        {
            this.chatStorageService = chatStorageService;
        }

        public bool CanProcess(ChatStatusEnum chatStatus)
        {
            return this.chatStatus == chatStatus;
        }

        public string ProcessMessage(string message, ChatHistory chat)
        {
            chat.ChatProgress = ChatStatusEnum.DescriptionEntered;
            chat.Description = message;
            this.chatStorageService.AddUpdateChat(chat);
            return Resource.ResponseMessages.DESCRIPTION_RESPONSE_MESSAGE;
        }
    }
}