using FollowMe.Domain.Enums;

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
