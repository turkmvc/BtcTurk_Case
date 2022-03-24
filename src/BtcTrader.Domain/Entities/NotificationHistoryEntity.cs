using System;

namespace BtcTrader.Domain.Entities
{
    public class NotificationHistoryEntity
    {
        public Guid Id { get; set; }
        public DateTime SendDate { get; set; }
        public int NotificationText { get; set; }
        public bool IsSendSms { get; set; }
        public bool IsSendEmail { get; set; }
        public bool IsSendPushNotification { get; set; }
        #region FK
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; }
        #endregion
    }


}
