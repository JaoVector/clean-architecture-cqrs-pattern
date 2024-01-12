using FollowMe.Application.UseCases.Endereco.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Endereco.Queries
{
    public sealed record ConsultaTodosEnderecos(int skip, int take) : IRequest<List<ReadEnderecoResponse>>;
}
