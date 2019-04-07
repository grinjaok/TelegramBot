using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace BotTimerFunction
{
    public static class ReminderFunction
    {
        [FunctionName("ReminderFunction")]
        public static async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            var botUrl = Environment.GetEnvironmentVariable("BotUrl");

            using (HttpClient httpClient = new HttpClient())
            {
                string endpoint = "/api/event-remind";
                var response = await httpClient.GetAsync($"{botUrl}{endpoint}");
            }
        }
    }
}
