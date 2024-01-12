using FollowMe.Application.UseCases.Usuario.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.Queries
{
    public sealed record ConsultaUsuarioPorId(Guid UsuarioId) : IRequest<ReadUserResponse>;
}
