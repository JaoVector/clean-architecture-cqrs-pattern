using FollowMe.Domain.Enums;

namespace FollowMe.Application.UseCases.Pedido.Responses
{
    public sealed record UpdateStatusPedidoResponse 
    {
        public string? CodRastreio { get; set; }
        public StatusPedido Status { get; set; }
    };
}
