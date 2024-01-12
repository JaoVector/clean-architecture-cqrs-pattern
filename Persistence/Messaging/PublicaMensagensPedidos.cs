using FollowMe.Application.Eventos;
using FollowMe.Application.Shared.Exceptions;
using FollowMe.Application.UseCases.Pedido.Responses;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Entities;
using MassTransit;

namespace FollowMe.Persistence.Messaging
{
    public static class PublicaMensagensPedidos
    {
        
        public static void PublicaStatusPedido(IBusControl bus, Pedido payload) 
        {
            try
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
            catch (Exception ex)
            {

                throw new ErroAoGerarMensagemPedido($"Erro ao Gerar mensagem de Status Pedido {ex}");
            }
            
        }

        public static void PublicaPedido(IBusControl bus, Pedido payload) 
        {
            try
            {
                var pedido = new PedidoCriado
                {
                    CodRastreio = payload.CodRastreio,
                    Status = payload.Status,
                    Usuario = new
                    {
                        payload.Usuario.Email,
                        payload.Usuario.Nome
                    },

                    ItensPedio = (from item in payload.ItensPedido
                                  select new ItemPedidoResponse
                                  {
                                      ItemPedidoId = item.ItemPedidoId,
                                      Produto = new ReadProdutoResponse
                                      {
                                          CodProduto = item.Produto.CodProduto,
                                          Nome = item.Produto?.Nome,
                                          Descricao = item.Produto?.Descricao,
                                          Preco = item.Produto.Preco
                                      },

                                      Quantidade = item.Quantidade,

                                  }).ToList(),

                };

                PublishMethod.Publica(bus, pedido, "pedido");
            }
            catch (Exception ex)
            {

                throw new ErroAoGerarMensagemPedido($"Erro ao Gerar mensagem de Pedido Criado {ex}");
            }
            
        }

        public static void PedidoExcluido(IBusControl bus, Pedido payload) 
        {
            try
            {
                var pedido = new PedidoExcluido
                {
                    CodPedido = payload.CodPedido,
                    CodRastreio = payload.CodRastreio,
                    Status = payload.Status,
                    Usuario = new
                    {
                        payload.Usuario.Nome,
                        payload.Usuario.Email
                    }
                };

                PublishMethod.Publica(bus, pedido, "pedido");
            }
            catch (Exception ex)
            {

                throw new ErroAoGerarMensagemPedido($"Erro ao Gerar mensagem de Pedido Excluido {ex}");
            }
        }
    }
}

//https://wrapt.dev/blog/building-an-event-driven-dotnet-application-setting-up-masstransit-and-rabbitmq

/*
 * 
 * 
 * var itens = (ICollection<ItemPedido> values) =>
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
 * 
 * 
 * 
 * 
 *  var pedido = new CriaPedido
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
 * 
 * 
 * 
 * 
 * 
 * public static string GeraJsonPayload(object payload) 
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(payload, options);

            File.WriteAllText("testeJsonPedido.json", json);

            return json;
        }
 * 
 */