using FollowMe.Domain.Enums;

namespace FollowMe.Application.UseCases.Pedido.Responses
{
    public sealed record DeletePedidoResponse
    {
        public Guid CodPedido { get; set; }
        public string? CodRastreio { get; set; }
        public StatusPedido Status { get; set; }
    }
}
