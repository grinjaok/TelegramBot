using System;
using System.Collections.Generic;
using TelegramBot.Enums;

namespace TelegramBot.Entities
{
    public class ChatHistory
    {
        public long Id { get; set; }

        public ChatStatusEnum ChatProgress { get; set; }

        public string Description { get; set; }

        public DateTime EventDate { get; set; }
        
    }
}