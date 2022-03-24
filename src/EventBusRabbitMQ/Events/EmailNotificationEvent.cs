using EventBusRabbitMQ.Events.Interfaces;

namespace EventBusRabbitMQ.Events
{
    public class EmailNotificationEvent : BaseNotificationEvent
    {
        public EmailNotificationEvent()
        {

        }
        public EmailNotificationEvent(string notificationText) : base(notificationText)
        {

        }
    }
}
