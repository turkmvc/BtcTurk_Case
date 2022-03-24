namespace BtcTrader.Domain.Dto
{
    public class NewOrderDto
    {
        public int UserId { get; set; }
        public byte DayOfMonth { get; set; }
        public int Amount { get; set; }
        public bool AllowSmsNotification { get; set; }
        public bool AllowEmailNotification { get; set; }
        public bool AllowPushNotification { get; set; }
    }
}
