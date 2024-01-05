using FollowMe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Pedido.Responses
{
    public sealed record CreatePedidoResponse
    {
        public Guid CodPedido { get; set; }
        public string? CodRastreio { get; set; }
        public StatusPedido Status { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid EnderecoId { get; set; }
    }
}
