using MediatR;

using System;

namespace BtcTrader.Application.Commands
{
    public class NewOrderCommand : IRequest<Guid>
    {
        /// <summary>
        /// Talepte bulunun kullanıcı numarası. WebApi tarafından token üzerinden çözülerek gelmektedir.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Talimatın gerçkleşecek gün. Her ayın belirtilen gününde talimat çalışır. (1-28)
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Alınacak bitcoinin TL tutarı
        /// </summary>
        public int Amount { get; set; }

        #region Notification
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
        #endregion
    }
}
