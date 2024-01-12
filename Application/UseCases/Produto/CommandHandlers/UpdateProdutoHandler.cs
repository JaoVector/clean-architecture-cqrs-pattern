using FollowMe.Application.Shared.Exceptions;
using FollowMe.Application.Shared.Extensions;
using FollowMe.Application.UseCases.Produto.Commands;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Produto.CommandHandlers
{
    public class UpdateProdutoHandler : IRequestHandler<UpdateProdutoRequest, UpdateProdutoResponse>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnityOfWork _work;

        public UpdateProdutoHandler(IProdutoRepository produtoRepository, IUnityOfWork work)
        {
            _produtoRepository = produtoRepository;
            _work = work;
        }

        public async Task<UpdateProdutoResponse> Handle(UpdateProdutoRequest request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.Consulta(p => p.CodProduto == request.CodProduto, cancellationToken);

            if (produto is null) throw new ProdutoNotFound($"Produto de Id {request.CodProduto} não Encontrado");

            produto.AtualizaProduto(request);

            _produtoRepository.Atualiza(produto);

            await _work.Commit(cancellationToken);

            return new UpdateProdutoResponse 
            {
                CodProduto = produto.CodProduto,
                Nome = produto.Nome,
                Descricao= produto.Descricao,
                Preco = produto.Preco,
                DataAtualizacao = produto.DataAtualizacao?.ToString("dd/MM/yyyy - HH:mm:ss")
            };   
        }
    }
}
