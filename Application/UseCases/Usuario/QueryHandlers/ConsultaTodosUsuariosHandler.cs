using AutoMapper;
using FollowMe.Application.UseCases.Usuario.Queries;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.QueryHandlers
{
    public class ConsultaTodosUsuariosHandler : IRequestHandler<ConsultaTodosUsuarios, List<ReadAllUserResponse>>
    {
        private readonly IUsuarioRepository _usuarioRepo;
       
        public ConsultaTodosUsuariosHandler(IUsuarioRepository usuario, IMapper mapper)
        {
            _usuarioRepo = usuario;
        }

        public async Task<List<ReadAllUserResponse>> Handle(ConsultaTodosUsuarios request, CancellationToken cancellationToken)
        {

            var usuarios = await _usuarioRepo.ConsultaTodos(request.skip, request.take, cancellationToken);

            return (from u in usuarios select new ReadAllUserResponse 
            { 
               UsuarioId = u.UsuarioId,
               Nome = u.Nome,
               Email = u.Email

            }).ToList(); 
        }
    }
}
