using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string queueName = "test-queue";
            const string hostName = "localhost";

            var factory = new ConnectionFactory() { HostName = hostName };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, eventArgs) =>
            {
                var message = Encoding.UTF8.GetString(eventArgs.Body);

                Console.WriteLine($"Received: \"{message}\"");
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            Console.ReadLine();
        }
    }
}
