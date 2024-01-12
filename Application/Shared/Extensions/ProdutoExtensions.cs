using FollowMe.Application.UseCases.Produto.Commands;
using FollowMe.Domain.Entities;

namespace FollowMe.Application.Shared.Extensions
{
    public static class ProdutoExtensions
    {
        public static void AtualizaProduto(this Produto produto, UpdateProdutoRequest request) 
        {
            produto.Nome = request.nome;
            produto.Descricao = request.descricao;
            produto.Preco = request.preco;

        }
    }
}
