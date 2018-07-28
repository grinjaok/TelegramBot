using TelegramBot.Entities;
using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class DateProcessor : IConversationProcessor
    {
        private ChatStatusEnum chatStatus = ChatStatusEnum.DateEntered;

        public bool CanProcess(ChatStatusEnum chatStatus)
        {
            return this.chatStatus == chatStatus;
        }

        public string ProcessMessage(string message, ChatHistory chat)
        {
            throw new System.NotImplementedException();
        }
    }
}