using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using ServiceStack.Redis;
using TelegramBot.Configurations;
using TelegramBot.Interfaces;
using TelegramBot.Services;
using TelegramBot.Services.ConversationProcessors;

namespace TelegramBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connetionString = Configuration.GetValue<string>("BotConfiguration:RedisCacheConnectionString");
            services.AddScoped<IChatService, ChatService>();
            services.AddSingleton<IBotService, BotService>();
            services.AddScoped<IEventStorageService, EventStorageService>();
            services.AddScoped<IChatStorageService, ChatStorageService>();
            services.AddScoped<IConversationProcessorFactory , ConversationProcessorFactory>();
            services.AddScoped<IConversationProcessor, WelcomeMessageProcessor>();
            services.AddScoped<IConversationProcessor, DescriptionProcessor>();
            services.AddScoped<IConversationProcessor, DateProcessor>();
            services.AddScoped<IConversationProcessor, TimeProcessor>();
            services.AddScoped<IEventService, EventService>();
            services.Configure<BotConfiguration>(Configuration.GetSection("BotConfiguration"));
            services.AddSingleton<IRedisClientsManager>(c =>
                new RedisManagerPool(connetionString));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
