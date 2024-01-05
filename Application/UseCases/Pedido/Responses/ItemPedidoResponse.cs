using FollowMe.Application.UseCases.Produto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Pedido.Responses
{
    public sealed record ItemPedidoResponse
    {
        public Guid ItemPedidoId { get; set; }
        public ReadProdutoResponse? Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
