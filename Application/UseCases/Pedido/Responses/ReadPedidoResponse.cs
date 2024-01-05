using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Pedido.Responses
{
    public sealed record ReadPedidoResponse
    {
        public Guid CodPedido { get; set; }
        public string? CodRastreio { get; set; }
        public StatusPedido Status { get; set; }
        public ReadUserPedidoResponse? Usuario { get; set; }
        public ReadEnderecoResponse? Endereco { get; set; }
        public ICollection<ItemPedidoResponse>? ItensPedido { get; set; }

    }
}
