using FollowMe.Application.UseCases.Produto.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Produto.Commands
{
    public sealed record UpdateProdutoRequest(Guid CodProduto, string nome, string descricao, double preco) : IRequest<UpdateProdutoResponse>;
}
