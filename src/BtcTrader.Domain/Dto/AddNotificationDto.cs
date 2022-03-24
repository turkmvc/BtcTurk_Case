using System;

namespace BtcTrader.Domain.Dto
{
    public class AddNotificationDto
    {
        public DateTime SendDate { get; set; }
        public string NotificationText { get; set; }
        public bool IsSendSms { get; set; }
        public bool IsSendEmail { get; set; }
        public bool IsSendPushNotification { get; set; }
        public Guid OrderId { get; set; }
    }
}
