using FollowMe.Application.UseCases.Endereco.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Endereco.Commands
{
    public sealed record UpdateEnderecoRequest(Guid EnderecoId, string Cep, string Rua, string Bairro, int Numero, Guid UsuarioId) : IRequest<UpdateEnderecoResponse>;
}
