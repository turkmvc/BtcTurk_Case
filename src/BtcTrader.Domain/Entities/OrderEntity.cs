using System;

namespace BtcTrader.Domain.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public long UserId { get; set; }
        public byte DayOfMonth { get; set; }
        public int Amount { get; set; }
        public bool AllowSmsNotification { get; set; }
        public bool AllowEmailNotification { get; set; }
        public bool AllowPushNotification { get; set; }
    }
}
