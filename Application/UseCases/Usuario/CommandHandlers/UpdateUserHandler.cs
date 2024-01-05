using FollowMe.Application.Shared.Extensions;
using FollowMe.Application.UseCases.Usuario.Requests;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.CommandHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {

        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IUnityOfWork _work;

        public UpdateUserHandler(IUsuarioRepository usuarioRepository, IUnityOfWork work)
        {
            _usuarioRepo = usuarioRepository;
            _work = work;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {

            var usuario = await _usuarioRepo.ConsultaUsuarioPorId(request.UsuarioId, cancellationToken);

            if (usuario is null) return default;

            usuario.AtualizaUsuario(request);
            
            _usuarioRepo.Atualiza(usuario);

            await _work.Commit(cancellationToken);
            
            return new UpdateUserResponse 
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataAtualizacao = usuario.DataAtualizacao?.ToString("dd/MM/yyyy - HH:mm:ss")
            };
        }
    }
}
