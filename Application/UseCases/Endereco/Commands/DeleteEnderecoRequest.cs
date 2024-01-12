using FollowMe.Application.UseCases.Endereco.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Endereco.Commands
{
    public sealed record DeleteEnderecoRequest(Guid EnderecoId) : IRequest<ReadEnderecoResponse>;
}
