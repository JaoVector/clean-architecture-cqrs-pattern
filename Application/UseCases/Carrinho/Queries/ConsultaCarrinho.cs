using FollowMe.Application.UseCases.Carrinho.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Carrinho.Queries
{
    public sealed record ConsultaCarrinho(Guid CarrinhoId) : IRequest<ReadCarrinhoResponse>;
}
