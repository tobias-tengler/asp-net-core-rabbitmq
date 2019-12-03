using System.Text;
using RabbitMQ.Client;

namespace Producer.Services
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private const string QueueName = "test-queue";
        private const string HostName = "localhost";

        private IConnection _connection;
        private IModel _channel;

        public void Setup()
        {
            var factory = new ConnectionFactory() { HostName = HostName };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: QueueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void Push(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "", routingKey: QueueName, body: body);
        }
    }
}