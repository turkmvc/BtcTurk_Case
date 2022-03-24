using BtcTrader.Application.Mapper;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;
using BtcTrader.Domain.Services;
using BtcTrader.Application.Services;
using BtcTrader.Application.Consumers;
using EventBusRabbitMQ.Producer;

namespace BtcTrader.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IHangfireJobService, HangfireJobService>();

            services.AddSingleton<EventBusEmailNotificationConsumer>();
            services.AddSingleton<EventBusPushNotificationConsumer>();
            services.AddSingleton<EventBusSmsNotificationConsumer>();
            services.AddSingleton<EventBusRabbitMQProducer>();


            #region Mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<OrderProfile>();
            });
            config.CreateMapper();
            #endregion

            return services;
        }
    }
}
