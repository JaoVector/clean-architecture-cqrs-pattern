using FollowMe.Application.UseCases.Usuario.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.Commands
{
    public sealed record DeleteUserRequest(Guid UsuarioId) : IRequest<ReadAllUserResponse>;
}
