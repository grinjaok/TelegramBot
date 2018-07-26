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

        public string ProcessMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}