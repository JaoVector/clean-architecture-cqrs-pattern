namespace FollowMe.Application.UseCases.Carrinho.Responses
{
    public sealed record CreateCarrinhoResponse
    {
        public Guid UsuarioId { get; set; }
        public Guid CarrinhoId { get; set; }
    }
}
