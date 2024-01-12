using FollowMe.Application.Shared.Exceptions;
using FollowMe.Application.UseCases.Endereco.Commands;
using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Endereco.CommandHandlers
{
    public class DeleteEnderecoHandler : IRequestHandler<DeleteEnderecoRequest, ReadEnderecoResponse>
    {
        private readonly IEnderecoRepository _enderecoRepo;
        private readonly IUnityOfWork _work;

        public DeleteEnderecoHandler(IEnderecoRepository enderecoRepo, IUnityOfWork work)
        {
            _enderecoRepo = enderecoRepo;
            _work = work;
        }

        public async Task<ReadEnderecoResponse> Handle(DeleteEnderecoRequest request, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepo.ConsultaEnderecoPorId(request.EnderecoId, cancellationToken);

            if (endereco is null) throw new EnderecoNotFound($"Endereco de Id {request.EnderecoId} não Encontrado");

            _enderecoRepo.Exclui(endereco);

            await _work.Commit(cancellationToken);

            return new ReadEnderecoResponse 
            {
                EnderecoId = endereco.EnderecoId,
                Cep = endereco.Cep,
                Rua = endereco.Rua,
                Bairro = endereco.Bairro,
                Numero = endereco.Numero
            };
        }
    }
}
