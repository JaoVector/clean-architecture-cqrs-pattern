using FollowMe.Application.UseCases.ItemCarrinho.Responses;

namespace FollowMe.Application.UseCases.Carrinho.Responses
{
    public sealed record ReadCarrinhoResponse
    {
        public Guid CarrinhoId { get; set; }
        public ICollection<ReadItemCarrinhoResponse>? Itens { get; set; }
    }
}
