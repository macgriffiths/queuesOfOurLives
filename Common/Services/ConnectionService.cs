using Common.Constants;
using Common.Helpers;
using Common.Services.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Common.Services
{
    public class ConnectionService : IConnectionService
    {
        private ConnectionFactory _rabbitConnection;

        public ConnectionService()
        {}

        /// <summary>
        /// Publishes messages to the specified queue.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="queque"></param>
        public bool PublishMessage(string message, string queque)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(queque))
                return false;

            using (var connection = RabbitConnection.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queque, false, false, false, null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", queque, null, body);
            }

            return true;
        }

        /// <summary>
        /// Listens on the specified queue for incoming messages.
        /// </summary>
        /// <param name="queue"></param>
        public void ReceiveMessage(string queue)
        {
            if (string.IsNullOrEmpty(queue))
                return;

            using (var connection = RabbitConnection.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    Console.WriteLine($"Hello {StringHelper.GetNameAfterCharacter(message, ',')}, I am your father!");
                };
                channel.BasicConsume(queue, true, consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Connection to our server.
        /// </summary>
        public ConnectionFactory RabbitConnection
        {
            get
            {
                if (_rabbitConnection == null)
                    _rabbitConnection = new ConnectionFactory() { HostName = Config.ChannelHost };
                return _rabbitConnection;
            }
            set
            {
                if (_rabbitConnection == value)
                    return;

                _rabbitConnection = value;
            }
        }
    }
}
