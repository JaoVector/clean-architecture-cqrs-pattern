using AutoMapper;
using FollowMe.Application.UseCases.Usuario.Commands;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.CommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse> 
    {
        private readonly IUnityOfWork _unitOfWork;
        private readonly IUsuarioRepository _userRepository;
        
        public CreateUserHandler(IUnityOfWork unitOfWork, IUsuarioRepository usuario)
        {
            _unitOfWork = unitOfWork;
            _userRepository = usuario;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.Usuario
            {
                UsuarioId = new Guid(),
                Nome = request.Nome,
                Email = request.Email,
            };

            _userRepository.Cria(user);

            await _unitOfWork.Commit(cancellationToken);

            return new CreateUserResponse() 
            {
                UsuarioId = user.UsuarioId,
                Nome = user.Nome,
                Email = user.Email,
                DataCriacao= user.DataCriacao.ToString("dd/MM/yyyy - HH:mm:ss")
            };
        }
    }
}
