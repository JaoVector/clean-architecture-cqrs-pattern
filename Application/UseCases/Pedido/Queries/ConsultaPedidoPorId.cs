using FollowMe.Application.UseCases.Pedido.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Pedido.Queries
{
    public sealed record ConsultaPedidoPorId(Guid PedidoId) : IRequest<ReadPedidoResponse>;
}
