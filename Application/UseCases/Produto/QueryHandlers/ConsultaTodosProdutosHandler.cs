using FollowMe.Application.UseCases.Produto.Queries;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Produto.QueryHandlers
{
    public class ConsultaTodosProdutosHandler : IRequestHandler<ConsultaTodosProdutos, List<ReadProdutoResponse>>
    {
        private readonly IProdutoRepository _prodRepo;

        public ConsultaTodosProdutosHandler(IProdutoRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        public async Task<List<ReadProdutoResponse>> Handle(ConsultaTodosProdutos request, CancellationToken cancellationToken)
        {
            var produtos = await _prodRepo.ConsultaTodos(request.skip, request.take, cancellationToken);

            return (from produto in produtos select new ReadProdutoResponse 
            {
                CodProduto = produto.CodProduto,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
             
            }).ToList();
        }
    }
}
