using AutoMapper;
using FollowMe.Application.UseCases.Usuario.Commands;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Interfaces;
using FollowMe.Domain.Entities;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.CommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse> 
    {
        private readonly IUnityOfWork _unitOfWork;
        private readonly IUsuarioRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnityOfWork unitOfWork, IUsuarioRepository usuario, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = usuario;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.Usuario>(request);

            _userRepository.Cria(user);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
