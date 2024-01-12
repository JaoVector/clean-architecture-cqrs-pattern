using FollowMe.Application.UseCases.Pedido.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Pedido.Commands
{
    public sealed record UpdateStatusPedidoRequest(Guid CodPedido) : IRequest<UpdateStatusPedidoResponse>;
}
