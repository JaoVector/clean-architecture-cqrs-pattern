namespace FollowMe.Application.UseCases.Produto.Responses
{
    public sealed record CreateProdutoResponse
    {
        public Guid CodProduto { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double Preco { get; set; }
        public string? DataCriacao { get; set; }
    }
}
