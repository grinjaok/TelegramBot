using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace TelegramBot.Configurations
{
    public class BotWebHookInit
    {
        private readonly BotConfiguration config;
        public BotWebHookInit(IOptions<BotConfiguration> config)
        {
            this.config = config.Value;
        }

        public void Initialize()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://api.telegram.org/");
                string endpoint = $"bot{this.config.BotToken}/setWebhook?url={this.config.BaseUrl}/api/inbox-message";
                httpClient.GetAsync(new Uri(endpoint));
            }
        }
    }
}