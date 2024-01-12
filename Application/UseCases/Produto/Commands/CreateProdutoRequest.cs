using FollowMe.Application.UseCases.Produto.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Produto.Commands
{
    public sealed record CreateProdutoRequest : IRequest<CreateProdutoResponse>
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double Preco { get; set; }
    }
}
