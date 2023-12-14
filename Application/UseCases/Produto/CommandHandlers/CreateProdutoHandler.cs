using AutoMapper;
using FollowMe.Application.UseCases.Produto.Commands;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Produto.CommandHandlers
{
    public class CreateProdutoHandler : IRequestHandler<CreateProdutoRequest, ReadProdutoResponse>
    {

        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnityOfWork _work;
        private readonly IMapper _mapper;

        public CreateProdutoHandler(IProdutoRepository produtoRepository, IUnityOfWork work, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _work = work;
            _mapper = mapper;
        }

        public async Task<ReadProdutoResponse> Handle(CreateProdutoRequest request, CancellationToken cancellationToken)
        {
            var produto = _mapper.Map<Domain.Entities.Produto>(request);

            _produtoRepository.Cria(produto);

            await _work.Commit(cancellationToken);

            return _mapper.Map<ReadProdutoResponse>(produto);
        }
    }
}
