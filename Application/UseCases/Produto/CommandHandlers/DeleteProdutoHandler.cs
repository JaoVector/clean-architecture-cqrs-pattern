using FollowMe.Application.Shared.Exceptions;
using FollowMe.Application.UseCases.Produto.Commands;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Produto.CommandHandlers
{
    public class DeleteProdutoHandler : IRequestHandler<DeleteProdutoRequest, DeleteProdutoResponse>
    {
        private readonly IProdutoRepository _produtoRepo;
        private readonly IUnityOfWork _work;

        public DeleteProdutoHandler(IProdutoRepository produtoRepo, IUnityOfWork work)
        {
            _produtoRepo = produtoRepo;
            _work = work;
        }

        public async Task<DeleteProdutoResponse> Handle(DeleteProdutoRequest request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepo.Consulta(p => p.CodProduto == request.CodProduto, cancellationToken);

            if (produto is null) throw new ProdutoNotFound($"Produto de Id {request.CodProduto} não Encontrado");

            _produtoRepo.ExcluiProduto(produto);

            await _work.Commit(cancellationToken);

            return new DeleteProdutoResponse
            {
                CodProduto = produto.CodProduto
            };
        }
    }
}
