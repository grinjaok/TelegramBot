using Microsoft.Extensions.Options;
using Telegram.Bot;
using TelegramBot.Configurations;
using TelegramBot.Interfaces;

namespace TelegramBot.Services
{
    public class BotService : IBotService
    {
        public TelegramBotClient Client { get; }
        private readonly BotConfiguration config;

        public BotService(IOptions<BotConfiguration> config)
        {
            this.config = config.Value;
            this.Client = new TelegramBotClient(this.config.BotToken);
        }
    }
}