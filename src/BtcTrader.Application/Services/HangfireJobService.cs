using BtcTrader.Domain.Repositories;
using BtcTrader.Domain.Services;

using System;
using System.Threading.Tasks;

namespace BtcTrader.Application.Services
{
    public class HangfireJobService : IHangfireJobService
    {
        private readonly IOrderRepository orderRepository;
        private readonly INotificationHistoryRepository notificationHistoryRepository;

        public HangfireJobService(IOrderRepository orderRepository, INotificationHistoryRepository notificationHistoryRepository)
        {
            this.orderRepository = orderRepository;
            this.notificationHistoryRepository = notificationHistoryRepository;
        }
        public async Task BtcPurchasing(Guid id)
        {
            var order = await orderRepository.GetOrder(id);

            //Satın alma
            var random = new Random();
            var btcCount = random.Next(1, 100);

            var notificationText = $@"{order.Amount} değerinde {btcCount} adet bitcoin alınmıştır.";

            if (order.AllowPushNotification)
                throw new NotImplementedException();

            if (order.AllowSmsNotification)
                throw new NotImplementedException();

            if (order.AllowEmailNotification)
                throw new NotImplementedException();

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
