using FollowMe.Domain.Enums;

namespace FollowMe.Application.Eventos
{
    public sealed record AtualizaStatusPedido
    {
        public string? CodRastreio { get; set; }
        public StatusPedido Status { get; set; }
        public object? Usuario { get; set; }
    };
}
