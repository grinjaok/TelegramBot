using System;
using TelegramBot.Entities;
using TelegramBot.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot.Services.ConversationProcessors
{
    public class DateProcessor : IConversationProcessor
    {
        private ChatStatusEnum chatStatus = ChatStatusEnum.DateEntered;
        private readonly IChatStorageService chatStorageService;

        public DateProcessor(IChatStorageService chatStorageService)
        {
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
                var parsedDate = DateTime.Parse(message);
                if (parsedDate.Date < DateTime.Now.Date)
                {
                    return Resource.ResponseMessages.DATE_SMALLER_THAN_NOW;
                }

                chat.ChatProgress = ChatStatusEnum.DateEntered;
                chat.EventDate = parsedDate;
                this.chatStorageService.AddUpdateChat(chat);
                return Resource.ResponseMessages.DATE_RESPONSE_MESSAGE;
            }
            catch (Exception)
            {
                return Resource.ResponseMessages.CANNOT_PARSE_DATE_MESSAGE;
            }

        }
    }
}