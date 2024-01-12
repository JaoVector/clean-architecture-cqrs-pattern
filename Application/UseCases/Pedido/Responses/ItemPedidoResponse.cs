using FollowMe.Application.UseCases.Produto.Responses;

namespace FollowMe.Application.UseCases.Pedido.Responses
{
    public sealed record ItemPedidoResponse
    {
        public Guid ItemPedidoId { get; set; }
        public ReadProdutoResponse? Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
