using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class TimeProcessor : IConversationProcessor
    {
        private ChatStatusEnum chatStatus = ChatStatusEnum.TimeEntered;

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