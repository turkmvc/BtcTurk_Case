using EventBusRabbitMQ.Events.Interfaces;

namespace EventBusRabbitMQ.Events
{
    public class SmsNotificationEvent : BaseNotificationEvent
    {
        public SmsNotificationEvent()
        {

        }
        public SmsNotificationEvent(string notificationText) : base(notificationText)
        {

        }
    }
}
