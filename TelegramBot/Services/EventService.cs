using TelegramBot.Interfaces;

namespace TelegramBot.Services
{
    public class EventService : IEventService
    {
        private readonly IBotService botService;
        private readonly IStorageService storageService;

        public EventService(IBotService botService, IStorageService storageService)
        {
            this.botService = botService;
            this.storageService = storageService;
        }

        public void RemindNextEvents()
        {
            var nextEvents = this.storageService.GetNextEvents();
            nextEvents.ForEach(x =>
            {
                this.botService.Client.SendTextMessageAsync(x.ChatId, x.Description);
                this.storageService.RemoveEvent(x);
            });
        }
    }
}