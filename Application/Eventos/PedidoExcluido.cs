using FollowMe.Domain.Enums;

namespace FollowMe.Application.Eventos
{
    public sealed record PedidoExcluido
    {
        public Guid CodPedido { get; set; }
        public string? CodRastreio { get; set; }
        public StatusPedido Status { get; set; }
        public object? Usuario { get; set; }
    }
}
