using FollowMe.Application.UseCases.Produto.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Produto.Commands
{
    public sealed record DeleteProdutoRequest(Guid? CodProduto) : IRequest<DeleteProdutoResponse>;
}
