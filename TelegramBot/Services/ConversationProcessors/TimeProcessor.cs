using System;
using System.Linq;
using TelegramBot.Entities;
using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class TimeProcessor : IConversationProcessor
    {
        private readonly IStorageService storageService;
        private ChatStatusEnum chatStatus = ChatStatusEnum.TimeEntered;

        public TimeProcessor(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        public bool CanProcess(ChatStatusEnum chatStatus)
        {
            return this.chatStatus == chatStatus;
        }

        public string ProcessMessage(string message, ChatHistory chat)
        {
            try
            {
                var parsedTime = DateTime.ParseExact("message", "HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture);
                var parsedDate =
                    DateTime.Parse(chat.ChatProgress.First(x => x.Key == ChatStatusEnum.DateEntered).Value);
                int minutesMultiplier = 60;
                DateTime eventDate = parsedDate.AddMinutes(parsedTime.Hour * minutesMultiplier + parsedTime.Minute);
                if (eventDate < DateTime.Now.Date)
                {
                    return Resource.ResponseMessages.TIME_SMALLER_THAN_NOW;
                }

                var eventToAdd = new IncomingEvent()
                {
                    ChatId = chat.ChatId,
                    Description = chat.ChatProgress.First(x => x.Key == ChatStatusEnum.DescriptionEntered).Value,
                    InvocationTime = eventDate
                };

                this.storageService.AddEventToStore(eventToAdd);
                this.storageService.RemoveChat(chat);
                return Resource.ResponseMessages.TIME_RESPONSE_MESSAGE;
            }
            catch (Exception)
            {
                return Resource.ResponseMessages.TIME_CANNOT_PARSE;
            }
        }
    }
}