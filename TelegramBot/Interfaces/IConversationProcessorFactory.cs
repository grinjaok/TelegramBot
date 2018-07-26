using TelegramBot.Enums;

namespace TelegramBot.Interfaces
{
    public interface IConversationProcessorFactory
    {
        IConversationProcessor GetConversationProcessor(ChatStatusEnum chatStatus);
    }
}