using FollowMe.Application.UseCases.Produto.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Produto.Queries
{
    public sealed record ConsultaProdutoPorId(Guid CodProduto) : IRequest<ReadProdutoResponse>;
}
