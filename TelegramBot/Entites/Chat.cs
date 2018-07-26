using System.Collections.Generic;
using TelegramBot.Enums;

namespace TelegramBot.Entites
{
    public class Chat
    {
        public long ChatId { get; set; }

        public Dictionary<ChatStatusEnum, string> ChatProgress { get; set; }
    }
}