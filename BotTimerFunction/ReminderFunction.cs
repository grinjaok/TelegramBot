using System;
using System.Configuration;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace BotTimerFunction
{
    public static class ReminderFunction
    {
        [FunctionName("ReminderFunction")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            var botUrl = Environment.GetEnvironmentVariable("BotUrl");

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(botUrl);
                string endpoint = "/api/event-remind";
                httpClient.GetAsync(new Uri(endpoint));
            }
        }
    }
}
