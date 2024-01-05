using FollowMe.Application.UseCases.Carrinho.Responses;
using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Application.UseCases.Produto.Responses;

namespace FollowMe.Application.UseCases.Usuario.Responses
{
    public sealed record ReadUserResponse
    {
        public Guid UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public ICollection<ReadEnderecoResponse>? Enderecos { get; set; } 
        public ReadCarrinhoResponse? Carrinho { get; set; }
    }
}
