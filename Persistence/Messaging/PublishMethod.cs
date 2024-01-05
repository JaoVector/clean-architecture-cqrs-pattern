using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FollowMe.Persistence.Messaging
{
    public static class PublishMethod
    {
        public async static void Publica(IBusControl bus, object payload, string routingKey) 
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonPayload = JsonSerializer.Serialize(payload, options);

            File.WriteAllText("testeJsonPedido.json", jsonPayload);

            var message = new SendMessage
            {
                RoutingKey = "pedido",
                Payload = jsonPayload
            };

            await bus.Publish<ISendMessage>(message);
        }
    }
}
