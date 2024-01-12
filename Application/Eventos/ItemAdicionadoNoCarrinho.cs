using FollowMe.Application.UseCases.ItemCarrinho.Responses;

namespace FollowMe.Application.Eventos
{
    public sealed record ItemAdicionadoNoCarrinho
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public ReadItemCarrinhoResponse? Item { get; set; }
    }
}
