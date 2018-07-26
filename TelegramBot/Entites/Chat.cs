using System.Collections.Generic;
using TelegramBot.Enums;

namespace TelegramBot.Entites
{
    public class ChatHistory
    {
        public int ChatId { get; set; }

        public Dictionary<ChatStatusEnum, string> ChatProgress { get; set; }

        public ChatHistory()
        {
            this.ChatProgress = new Dictionary<ChatStatusEnum, string>()
            {
                { ChatStatusEnum.HelloMessage, string.Empty }
            };
        }
    }
}