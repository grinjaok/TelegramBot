using TelegramBot.Entities;
using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class DescriptionProcessor : IConversationProcessor
    {
        private ChatStatusEnum chatStatus = ChatStatusEnum.DescriptionEntered;

        public bool CanProcess(ChatStatusEnum chatStatus)
        {
            return this.chatStatus == chatStatus;
        }

        public string ProcessMessage(string message, ChatHistory chat)
        {
            chat.ChatProgress.Add(ChatStatusEnum.DescriptionEntered, message);
            return Resource.ResponseMessages.DESCRIPTION_RESPONSE_MESSAGE;
        }
    }
}