using System;

namespace TelegramBot.Entities
{
    public class IncomingEvent
    {
        public string Description { get; set; }

        public DateTime InvocationTime { get; set; }
    }
}