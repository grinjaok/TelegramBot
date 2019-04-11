using System;
using System.Linq;
using TelegramBot.Entities;
using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class TimeProcessor : IConversationProcessor
    {
        private readonly IEventStorageService eventStorageService;
        private readonly IChatStorageService chatStorageService;
        private ChatStatusEnum chatStatus = ChatStatusEnum.TimeEntered;

        public TimeProcessor(IEventStorageService eventStorageService, IChatStorageService chatStorageService)
        {
            this.eventStorageService = eventStorageService;
            this.chatStorageService = chatStorageService;
        }

        public bool CanProcess(ChatStatusEnum chatStatus)
        {
            return this.chatStatus == chatStatus;
        }

        public string ProcessMessage(string message, ChatHistory chat)
        {
            try
            {
                var parsedTime = DateTime.ParseExact(message, "HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture);
                int minutesMultiplier = 60;
                DateTime eventDate = chat.EventDate.AddMinutes(parsedTime.Hour * minutesMultiplier + parsedTime.Minute);
                if (eventDate < DateTime.Now.Date)
                {
                    return Resource.ResponseMessages.TIME_SMALLER_THAN_NOW;
                }

                var eventToAdd = new IncomingEvent()
                {
                    Id = chat.Id,
                    Description = chat.Description,
                    InvocationTime = eventDate
                };

                this.eventStorageService.AddEventToStore(eventToAdd);
                this.chatStorageService.RemoveChat(chat);
                return Resource.ResponseMessages.TIME_RESPONSE_MESSAGE;
            }
            catch (Exception)
            {
                return Resource.ResponseMessages.TIME_CANNOT_PARSE;
            }
        }
    }
}