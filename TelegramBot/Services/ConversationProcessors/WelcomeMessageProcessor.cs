using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class WelcomeMessageProcessor : IConversationProcessor
    {
        private ChatStatusEnum chatStatus = ChatStatusEnum.HelloMessage;

        public bool CanProcess(ChatStatusEnum chatStatus)
        {
            return this.chatStatus == chatStatus;
        }

        public string ProcessMessage(string message)
        {
            return message;
        }
    }
}