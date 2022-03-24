namespace BtcTrader.Application.Responses
{
    public class OrderDetailResponse
    {
        /// <summary>
        /// Sms bilgilendirmesi yapılacak mı?
        /// </summary>
        public bool AllowSmsNotification { get; set; }

        /// <summary>
        /// Email bilgilendirmesi yapılacak mı?
        /// </summary>
        public bool AllowEmailNotification { get; set; }
        /// <summary>
        /// PushNotification bilgilendirmesi yapılacak mı?
        /// </summary>
        public bool AllowPushNotification { get; set; }
    }
}
