using FollowMe.Application.UseCases.Usuario.Requests;
using FollowMe.Domain.Entities;

namespace FollowMe.Application.Shared.Extensions
{
    public static class UsuarioExtensions
    {
        public static void AtualizaUsuario(this Usuario usuario, UpdateUserRequest request)
        {
            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
        }
    }
}
