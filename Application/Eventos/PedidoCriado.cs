using FollowMe.Application.UseCases.Pedido.Responses;
using FollowMe.Domain.Enums;

namespace FollowMe.Application.Eventos
{
    public sealed record PedidoCriado
    {
        public string? CodRastreio { get; set; }
        public StatusPedido Status { get; set; }
        public object? Usuario { get; set; }
        public ICollection<ItemPedidoResponse>? ItensPedio { get; set; }
    }
}
