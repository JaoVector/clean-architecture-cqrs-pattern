using FollowMe.Application.Shared.Exceptions;
using MassTransit;
using System.Text.Json;

namespace FollowMe.Persistence.Messaging
{
    public static class PublishMethod
    {
        public async static void Publica(IBusControl bus, object payload, string routingKey) 
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };

                string jsonPayload = JsonSerializer.Serialize(payload, options);

                File.WriteAllText("testeJsonPedido.json", jsonPayload);

                var message = new SendMessage
                {
                    RoutingKey = routingKey,
                    Payload = jsonPayload
                };

                await bus.Publish<ISendMessage>(message);
            }
            catch (Exception ex)
            {

                throw new MessageExceptions($"Erro ao Publicar as Mensagens no RabbitMQ {ex}");
            }
        }
    }
}
