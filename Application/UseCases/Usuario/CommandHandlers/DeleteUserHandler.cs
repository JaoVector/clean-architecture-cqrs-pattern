using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Application.UseCases.Usuario.Commands;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.CommandHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, ReadAllUserResponse>
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IUnityOfWork _work;

        public DeleteUserHandler(IUsuarioRepository usuarioRepo, IUnityOfWork work)
        {
            _usuarioRepo = usuarioRepo;
            _work = work;
        }

        public async Task<ReadAllUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepo.ConsultaUsuarioPorId(request.UsuarioId, cancellationToken);

            _usuarioRepo.Exclui(usuario);

            await _work.Commit(cancellationToken);

            return new ReadAllUserResponse 
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }
    }
}
