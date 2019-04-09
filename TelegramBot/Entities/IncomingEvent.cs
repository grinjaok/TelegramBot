using System;

namespace TelegramBot.Entities
{
    public class IncomingEvent
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public DateTime InvocationTime { get; set; }
    }
}