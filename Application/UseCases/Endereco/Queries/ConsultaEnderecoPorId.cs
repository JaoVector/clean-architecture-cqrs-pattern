using FollowMe.Application.UseCases.Endereco.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Endereco.Queries
{
    public sealed record ConsultaEnderecoPorId(Guid EnderecoId) : IRequest<ReadEnderecoResponse>;
}
