﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            services.AddScoped<IChatService, ChatService>();
            services.AddSingleton<IBotService, BotService>();
            services.AddSingleton<IStorageService, StorageService>();
            services.AddScoped<IConversationProcessorFactory , ConversationProcessorFactory>();
            services.AddScoped<IConversationProcessor, WelcomeMessageProcessor>();
            services.AddScoped<IConversationProcessor, DescriptionProcessor>();
            services.AddScoped<IConversationProcessor, DateProcessor>();
            services.AddScoped<IConversationProcessor, TimeProcessor>();
            services.AddScoped<IEventService, EventService>();
            services.Configure<BotConfiguration>(Configuration.GetSection("BotConfiguration"));
            
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
