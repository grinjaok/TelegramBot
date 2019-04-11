using System;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using TelegramBot.Configurations;
using TelegramBot.Entities;
using TelegramBot.Interfaces;

namespace TelegramBot.Services
{
    public class EventStorageService : IEventStorageService
    {
        private readonly IRedisTypedClient<IncomingEvent> redisClient;

        public EventStorageService(IOptions<BotConfiguration> config, IRedisClientsManager redisClientsManager)
        {
            this.redisClient = redisClientsManager.GetClient().As<IncomingEvent>();
        }

        public void AddEventToStore(IncomingEvent incomingEvent)
        {
            var store =this.redisClient.Store(incomingEvent);
        }

        public List<IncomingEvent> GetNextEvents()
        {
            var allEvents = this.redisClient.GetAll();
            int minutesInterval = 1;
            int timeZoneShift = 3;
            // todo in future add synchronization for user and server timezones
            var events = allEvents.Where(x => x.InvocationTime > DateTime.Now.AddHours(timeZoneShift) &&
                                              x.InvocationTime < DateTime.Now.AddMinutes(minutesInterval).AddHours(timeZoneShift)).ToList();
            return events;
        }

        public void RemoveEvent(IncomingEvent incomingEvent)
        {
            this.redisClient.DeleteById(incomingEvent.Id);
        }
    }
}