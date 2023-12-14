using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Persistence.Messaging
{
    public class RabbitMQService : IMessageBusService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string _exchange = "trackings-service";

        public RabbitMQService(IConnection connection, IModel channel)
        {
            var connectionFactory = new ConnectionFactory 
            {
                HostName = "localhost",
            };

            _connection = connectionFactory.CreateConnection("trackings-service-publisher");

            _channel = connection.CreateModel();
        }

        public void Publish(object data, string routingKey)
        {
            var type = data.GetType();

            var payload = JsonConvert.SerializeObject(data);
            var bytes = Encoding.UTF8.GetBytes(payload);

            Console.WriteLine($"{type.Name} Published");

            _channel.BasicPublish(_exchange, routingKey, null, bytes);
        }
    }
}
