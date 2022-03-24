using BtcTrader.Application.Consumers;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BtcTrader.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static EventBusEmailNotificationConsumer EmailListener { get; set; }
        public static EventBusSmsNotificationConsumer SmsListener { get; set; }
        public static EventBusPushNotificationConsumer PushListener { get; set; }

        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            EmailListener = app.ApplicationServices.GetService<EventBusEmailNotificationConsumer>();
            SmsListener = app.ApplicationServices.GetService<EventBusSmsNotificationConsumer>();
            PushListener = app.ApplicationServices.GetService<EventBusPushNotificationConsumer>();
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            EmailListener.Consume();
            SmsListener.Consume();
            PushListener.Consume();
        }

        private static void OnStopping()
        {
            EmailListener.Disconnect();
            SmsListener.Disconnect();
            PushListener.Disconnect();
        }
    }
}
