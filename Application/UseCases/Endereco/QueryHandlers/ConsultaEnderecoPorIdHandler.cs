using FollowMe.Application.UseCases.Endereco.Queries;
using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Endereco.QueryHandlers
{
    public class ConsultaEnderecoPorIdHandler : IRequestHandler<ConsultaEnderecoPorId, ReadEnderecoResponse>
    {
        private readonly IEnderecoRepository _enderecoRepo;
        private readonly IUnityOfWork _work;

        public ConsultaEnderecoPorIdHandler(IEnderecoRepository enderecoRepo, IUnityOfWork work)
        {
            _enderecoRepo = enderecoRepo;
            _work = work;
        }

        public async Task<ReadEnderecoResponse> Handle(ConsultaEnderecoPorId request, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepo.ConsultaEnderecoPorId(request.EnderecoId, cancellationToken);

            if (endereco is null) return default;

            return new ReadEnderecoResponse
            {
                EnderecoId = endereco.EnderecoId,
                Cep = endereco.Cep,
                Rua = endereco.Rua,
                Bairro = endereco.Bairro,
                Numero = endereco.Numero,
            };
        }
    }
}
