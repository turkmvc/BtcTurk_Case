namespace EventBusRabbitMQ.Events.Interfaces
{
    public class BaseNotificationEvent : IEvent
    {
        public string NotificationText { get; set; }
        public BaseNotificationEvent()
        {

        }
        public BaseNotificationEvent(string notificationText)
        {
            NotificationText = notificationText;
        }
    }
}
