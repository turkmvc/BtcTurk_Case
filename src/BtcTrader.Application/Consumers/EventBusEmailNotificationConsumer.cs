
using EventBusRabbitMQ;
using EventBusRabbitMQ.Core;
using EventBusRabbitMQ.Events;

using Newtonsoft.Json;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Net.Sockets;
using System.Text;

namespace BtcTrader.Application.Consumers
{
    public class EventBusEmailNotificationConsumer
    {
        private readonly IRabbitMQPersistentConnection _persistentConnection;

        public EventBusEmailNotificationConsumer(IRabbitMQPersistentConnection persistentConnection)
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
            channel.CallbackException += Channel_CallbackException;
            channel.QueueDeclare(queue: EventBusConstants.emailNotification, durable: false, exclusive: false, autoDelete: false, arguments: null);
            
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue: EventBusConstants.emailNotification, autoAck: true, consumer: consumer);
        }

        private void Channel_CallbackException(object sender, CallbackExceptionEventArgs e)
        {
            //TODO: Exception handle
        }

        private void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.Span);
            var @event = JsonConvert.DeserializeObject<EmailNotificationEvent>(message);
            //Send email notification codes
        }

        public void Disconnect()
        {
            _persistentConnection.Dispose();
        }
    }
}
