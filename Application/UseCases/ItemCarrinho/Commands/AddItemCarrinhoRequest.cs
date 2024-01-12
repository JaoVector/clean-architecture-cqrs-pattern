using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.ItemCarrinho.Commands
{
    public sealed record AddItemCarrinhoRequest(Guid carrinhoId, Guid codProduto, int Quantidade) : IRequest<AddItemCarrinhoResponse>;
}
