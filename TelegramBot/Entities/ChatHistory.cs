using System.Collections.Generic;
using TelegramBot.Enums;

namespace TelegramBot.Entities
{
    public class ChatHistory
    {
        public long ChatId { get; set; }

        public Dictionary<ChatStatusEnum, string> ChatProgress { get; set; }

        public ChatHistory()
        {
            this.ChatProgress = new Dictionary<ChatStatusEnum, string>();
        }
    }
}