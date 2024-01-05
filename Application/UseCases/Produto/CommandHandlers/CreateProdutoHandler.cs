using FollowMe.Application.UseCases.Produto.Commands;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Produto.CommandHandlers
{
    public class CreateProdutoHandler : IRequestHandler<CreateProdutoRequest, CreateProdutoResponse>
    {

        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnityOfWork _work;

        public CreateProdutoHandler(IProdutoRepository produtoRepository, IUnityOfWork work)
        {
            _produtoRepository = produtoRepository;
            _work = work;
        }

        public async Task<CreateProdutoResponse> Handle(CreateProdutoRequest request, CancellationToken cancellationToken)
        {
            var produto = new Domain.Entities.Produto 
            {
                CodProduto = new Guid(),
                Nome = request.Nome,
                Descricao = request.Descricao,
                Preco = request.Preco,
                
            };

            _produtoRepository.Cria(produto);

            await _work.Commit(cancellationToken);

            return new CreateProdutoResponse
            {
                CodProduto = produto.CodProduto,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                DataCriacao = produto.DataCriacao.ToString("dd/MM/yyyy - HH:mm:ss")
            };
        }
    }
}

/*
 * 
 * 
 * 
 * _mapper.Map<Domain.Entities.Produto>(request);
 * 
 * _mapper.Map<ReadProdutoResponse>(produto);
 * 
 * 
 */