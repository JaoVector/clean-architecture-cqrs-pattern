using FollowMe.Application.UseCases.Endereco.Commands;
using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Endereco.CommandHandlers
{
    public class CreateEnderecoHandler : IRequestHandler<CreateEnderecoRequest, CreateEnderecoResponse>
    {

        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUnityOfWork _work;

        public CreateEnderecoHandler(IEnderecoRepository enderecoRepository, IUnityOfWork work)
        {
            _enderecoRepository = enderecoRepository;
            _work = work;
        }

        public async Task<CreateEnderecoResponse> Handle(CreateEnderecoRequest request, CancellationToken cancellationToken)
        {
            var endereco = new Domain.Entities.Endereco
            {
                EnderecoId = new Guid(),
                Cep = request.Cep,
                Rua = request.Rua,
                Bairro = request.Bairro,
                Numero= request.Numero,
                UsuarioId = request.UsuarioId

            };

            _enderecoRepository.Cria(endereco);

            await _work.Commit(cancellationToken);

            return new CreateEnderecoResponse() 
            {
                EnderecoId = endereco.EnderecoId,
                Cep = endereco.Cep,
                Rua = endereco.Rua,
                Bairro= endereco.Bairro,
                Numero = endereco.Numero,
                UsuarioId = endereco.UsuarioId,
                DataCriacao = endereco.DataCriacao.ToString("dd/MM/yyyy - HH:mm:ss")
            };
        }
    }
}
