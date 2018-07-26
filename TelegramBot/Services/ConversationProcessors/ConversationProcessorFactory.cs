using System.Collections.Generic;
using System.Linq;
using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class ConversationProcessorFactory : IConversationProcessorFactory
    {
        private readonly List<IConversationProcessor> conversationProcessors;

        public ConversationProcessorFactory(IEnumerable<IConversationProcessor> conversationProcessors)
        {
            this.conversationProcessors = conversationProcessors as List<IConversationProcessor> ?? conversationProcessors.ToList();
        }

        public IConversationProcessor GetConversationProcessor(ChatStatusEnum chatStatus)
        {
            return this.conversationProcessors.FirstOrDefault(x => x.CanProcess(chatStatus));
        }
    }
}