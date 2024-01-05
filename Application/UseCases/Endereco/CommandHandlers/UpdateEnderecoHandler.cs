using FollowMe.Application.Shared.Extensions;
using FollowMe.Application.UseCases.Endereco.Commands;
using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Endereco.CommandHandlers
{
    public class UpdateEnderecoHandler : IRequestHandler<UpdateEnderecoRequest, UpdateEnderecoResponse>
    {
        private readonly IEnderecoRepository _enderecoRepo;
        private readonly IUnityOfWork _work;

        public UpdateEnderecoHandler(IEnderecoRepository enderecoRepo, IUnityOfWork work)
        {
            _enderecoRepo = enderecoRepo;
            _work = work;
        }

        public async Task<UpdateEnderecoResponse> Handle(UpdateEnderecoRequest request, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepo.ConsultaEnderecoPorId(request.EnderecoId, cancellationToken);

            if (endereco is null) return default;

            endereco.AtualizaEndereco(request);

            _enderecoRepo.Atualiza(endereco);

            await _work.Commit(cancellationToken);

            return new UpdateEnderecoResponse
            {
                EnderecoId = endereco.EnderecoId,
                Cep = endereco.Cep,
                Rua = endereco.Rua,
                Bairro = endereco.Bairro,
                Numero = endereco.Numero,
                UsuarioId = endereco.UsuarioId,
                DataAtualizacao = endereco.DataAtualizacao?.ToString("dd/MM/yyyy - HH:mm:ss")
            };
        }
    }
}
