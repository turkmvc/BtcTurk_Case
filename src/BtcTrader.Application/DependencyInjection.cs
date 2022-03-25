using AutoMapper;

using BtcTrader.Application.Consumers;
using BtcTrader.Application.Mapper;
using BtcTrader.Application.Services;
using BtcTrader.Domain.Services;

using EventBusRabbitMQ.Producer;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

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
