using FollowMe.Application.Shared.Exceptions;
using FollowMe.Application.UseCases.Produto.Queries;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Produto.QueryHandlers
{
    public class ConsultaProdutoPorIdHandler : IRequestHandler<ConsultaProdutoPorId, ReadProdutoResponse>
    {
        private readonly IProdutoRepository _produtoRepo;

        public ConsultaProdutoPorIdHandler(IProdutoRepository produtoRepo)
        {
            _produtoRepo = produtoRepo;
        }

        public async Task<ReadProdutoResponse> Handle(ConsultaProdutoPorId request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepo.Consulta(p => p.CodProduto == request.CodProduto, cancellationToken);

            if (produto is null) throw new ProdutoNotFound($"Produto de Id {request.CodProduto} não Encontrado");

            return new ReadProdutoResponse
            {
                CodProduto = produto.CodProduto,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
            };
        }
    }
}
