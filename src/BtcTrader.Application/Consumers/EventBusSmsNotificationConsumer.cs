
using EventBusRabbitMQ;
using EventBusRabbitMQ.Core;
using EventBusRabbitMQ.Events;

using Newtonsoft.Json;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Text;

namespace BtcTrader.Application.Consumers
{
    public class EventBusSmsNotificationConsumer
    {
        private readonly IRabbitMQPersistentConnection _persistentConnection;

        public EventBusSmsNotificationConsumer(IRabbitMQPersistentConnection persistentConnection)
        {
            _persistentConnection = persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
        }

        public void Consume()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.smsNotification, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue: EventBusConstants.smsNotification, autoAck: true, consumer: consumer);
        }

        private void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.Span);
            var @event = JsonConvert.DeserializeObject<SmsNotificationEvent>(message);

            //Send sms notification codes
        }

        public void Disconnect()
        {
            _persistentConnection.Dispose();
        }
    }
}
