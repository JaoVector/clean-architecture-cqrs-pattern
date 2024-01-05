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
    public class ConsultaTodosEnderecosHandler : IRequestHandler<ConsultaTodosEnderecos, List<ReadEnderecoResponse>>
    {

        private readonly IEnderecoRepository _enderecoRepo;
        
        public ConsultaTodosEnderecosHandler(IEnderecoRepository enderecoRepo, IUnityOfWork work)
        {
            _enderecoRepo = enderecoRepo;
            
        }

        public async Task<List<ReadEnderecoResponse>> Handle(ConsultaTodosEnderecos request, CancellationToken cancellationToken)
        {
            var enderecos = await _enderecoRepo.ConsultaTodos(request.skip, request.take, cancellationToken);

            return (from e in enderecos select new ReadEnderecoResponse 
            {
                EnderecoId = e.EnderecoId,
                Cep = e.Cep,
                Rua = e.Rua,
                Bairro = e.Bairro,
                Numero = e.Numero

            }).ToList();
        }
    }
}
