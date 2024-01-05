using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Entities;
using FollowMe.Domain.Eventos;
using MassTransit;
using System.Text.Json;

namespace FollowMe.Persistence.Messaging
{
    public static class PublicaMensagemPedidos
    {
        private static ICollection<object> itensPedido;

        public static void PublicaStatusPedido(IBusControl bus, Pedido payload) 
        {
           
            var pedido = new AtualizaStatusPedido 
            {
                CodRastreio = payload.CodRastreio,
                Status = payload.Status,
                Usuario = new  
                {
                    payload.Usuario.Email,
                    payload.Usuario.Nome
                }
            };

            PublishMethod.Publica(bus, pedido, "pedido");
        }

        public static async void PublicaPedido(IBusControl bus, Pedido payload) 
        {

            var itens = (ICollection<ItemPedido> values) =>
            {
                
                foreach (var item in values)
                {
                    var itemPedido = new
                    {
                        item.ItemPedidoId,
                        Produto = item.Produto = new Produto 
                        {
                            CodProduto = item.Produto.CodProduto,
                            Nome = item.Produto.Nome,
                            Descricao= item.Produto.Descricao,
                            Preco = item.Produto.Preco,
                        },
                        item.Quantidade
                    };

                    itensPedido.Add(itemPedido);
                }

                return itensPedido;
            };

            var pedido = new CriaPedido
            {
                CodRastreio = payload.CodRastreio,
                Status = payload.Status,
                Usuario = new
                {
                    payload.Usuario.Email,
                    payload.Usuario.Nome
                },

                ItensPedio = itens(payload.ItensPedido)
                
            };


            PublishMethod.Publica(bus, pedido, "pedido");
        }

        //https://wrapt.dev/blog/building-an-event-driven-dotnet-application-setting-up-masstransit-and-rabbitmq

        public static string GeraJsonPayload(object payload) 
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(payload, options);

            File.WriteAllText("testeJsonPedido.json", json);

            return json;
        }

    }
}
