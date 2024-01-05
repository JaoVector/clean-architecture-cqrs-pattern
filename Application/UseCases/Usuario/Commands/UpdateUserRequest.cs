using FollowMe.Application.UseCases.Usuario.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.Requests
{
    public sealed record UpdateUserRequest(Guid UsuarioId, string Nome, string Email) : IRequest<UpdateUserResponse>;
}
