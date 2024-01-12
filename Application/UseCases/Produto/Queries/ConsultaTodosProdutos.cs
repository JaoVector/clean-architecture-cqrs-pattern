using FollowMe.Application.UseCases.Produto.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Produto.Queries
{
    public sealed record ConsultaTodosProdutos(int skip, int take) : IRequest<List<ReadProdutoResponse>>;
}
