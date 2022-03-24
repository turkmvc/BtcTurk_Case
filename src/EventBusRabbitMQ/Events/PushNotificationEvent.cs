using EventBusRabbitMQ.Events.Interfaces;

namespace EventBusRabbitMQ.Events
{
    public class PushNotificationEvent : BaseNotificationEvent
    {
        public PushNotificationEvent()
        {

        }
        public PushNotificationEvent(string notificationText) : base(notificationText)
        {

        }
    }
}
