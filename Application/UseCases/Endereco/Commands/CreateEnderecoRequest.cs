using FollowMe.Application.UseCases.Endereco.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Endereco.Commands
{
    public sealed record CreateEnderecoRequest : IRequest<CreateEnderecoResponse>
    {
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
