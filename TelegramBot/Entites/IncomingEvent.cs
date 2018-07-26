using System;

namespace TelegramBot.Entites
{
    public class IncomingEvent
    {
        public string Description { get; set; }

        public DateTime InvocationTime { get; set; }
    }
}