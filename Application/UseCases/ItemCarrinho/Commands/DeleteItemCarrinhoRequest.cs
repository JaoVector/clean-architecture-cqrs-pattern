using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.ItemCarrinho.Commands
{
    public sealed record DeleteItemCarrinhoRequest(Guid ItemCarrinhoId) : IRequest<DeleteItemCarrinhoResponse>;
}
