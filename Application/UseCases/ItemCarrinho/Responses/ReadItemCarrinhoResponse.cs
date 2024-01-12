using FollowMe.Application.UseCases.Produto.Responses;

namespace FollowMe.Application.UseCases.ItemCarrinho.Responses
{
    public sealed record ReadItemCarrinhoResponse
    {
        public Guid ItemCarrinhoId { get; set; }
        public ReadProdutoResponse? Produto { get; set; }
    }
}
