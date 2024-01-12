using FollowMe.Application.UseCases.Usuario.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.Commands
{
    public sealed record CreateUserRequest(string Nome, string Email) : IRequest<CreateUserResponse>;
}
