using FollowMe.Application.UseCases.Usuario.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.Queries
{
    public sealed record ConsultaTodosUsuarios(int skip, int take) : IRequest<List<ReadAllUserResponse>>; 
}
