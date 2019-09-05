using TelegramBot.Interfaces;

namespace TelegramBot.Services
{
    public class EventService : IEventService
    {
        private readonly IBotService botService;
        private readonly IEventStorageService eventStorageService;

        public EventService(IBotService botService, IEventStorageService eventStorageService)
        {
            this.botService = botService;
            this.eventStorageService = eventStorageService;
        }

        public void RemindNextEvents()
        {
            var nextEvents = this.eventStorageService.GetNextEvents();
            nextEvents.ForEach(x =>
            {
                this.botService.Client.SendTextMessageAsync(x.ChatId, x.Description);
                this.eventStorageService.RemoveEvent(x);
            });
        }
    }
}