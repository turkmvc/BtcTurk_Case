using BtcTrader.Domain.Repositories;
using BtcTrader.Domain.Services;

using EventBusRabbitMQ.Core;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;

using System;
using System.Threading.Tasks;

namespace BtcTrader.Application.Services
{
    public class HangfireJobService : IHangfireJobService
    {
        private readonly IOrderRepository orderRepository;
        private readonly INotificationHistoryRepository notificationHistoryRepository;
        private readonly EventBusRabbitMQProducer _eventBus;
        public HangfireJobService(IOrderRepository orderRepository, INotificationHistoryRepository notificationHistoryRepository, EventBusRabbitMQProducer eventBus)
        {
            this.orderRepository = orderRepository;
            this.notificationHistoryRepository = notificationHistoryRepository;
            _eventBus = eventBus;
        }
        public async Task BtcPurchasing(Guid id)
        {
            var order = await orderRepository.GetOrder(id);

            //Satın alma
            var random = new Random();
            var btcCount = random.Next(1, 100);

            var notificationText = $@"{order.Amount} değerinde {btcCount} adet bitcoin alınmıştır.";

            if (order.AllowPushNotification)
                _eventBus.Publish(EventBusConstants.pushNotification, new PushNotificationEvent(notificationText));

            if (order.AllowSmsNotification)
                _eventBus.Publish(EventBusConstants.smsNotification, new SmsNotificationEvent(notificationText));

            if (order.AllowEmailNotification)
                _eventBus.Publish(EventBusConstants.emailNotification, new EmailNotificationEvent(notificationText));

            await this.notificationHistoryRepository.AddNotificationHistory(new Domain.Dto.AddNotificationDto()
            {
                IsSendEmail = order.AllowEmailNotification,
                IsSendPushNotification = order.AllowPushNotification,
                IsSendSms = order.AllowSmsNotification,
                NotificationText = notificationText,
                SendDate = DateTime.UtcNow
            });
        }
    }
}
