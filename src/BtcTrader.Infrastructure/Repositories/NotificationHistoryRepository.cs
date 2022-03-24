using BtcTrader.Domain.Dto;
using BtcTrader.Domain.Entities;
using BtcTrader.Domain.Repositories;
using BtcTrader.Infrastructure.Context;
using BtcTrader.Infrastructure.Repositories.Base;

using System.Data;
using System.Threading.Tasks;

namespace BtcTrader.Infrastructure.Repositories
{
    public class NotificationHistoryRepository : RepositoryBase, INotificationHistoryRepository
    {
        public NotificationHistoryRepository(BtcTraderContext context) : base(context)
        {

        }

        public Task AddNotificationHistory(AddNotificationDto notificationDto)
        {
            var entity = new NotificationHistoryEntity()
            {
                IsSendSms = notificationDto.IsSendSms,
                IsSendEmail = notificationDto.IsSendEmail,
                IsSendPushNotification = notificationDto.IsSendPushNotification,
                NotificationText = notificationDto.NotificationText,
                OrderId = notificationDto.OrderId,
                SendDate = notificationDto.SendDate
            };

            context.NotificationHistories.Add(entity);
            return context.SaveChangesAsync();
        }
    }
}
