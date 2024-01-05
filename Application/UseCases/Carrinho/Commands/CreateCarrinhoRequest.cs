using FollowMe.Application.UseCases.Carrinho.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Carrinho.Commands
{
    public sealed record CreateCarrinhoRequest(Guid UsuarioId) : IRequest<CreateCarrinhoResponse>;
}
