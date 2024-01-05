using FollowMe.Application.UseCases.Carrinho.Queries;
using FollowMe.Application.UseCases.Carrinho.Responses;
using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Carrinho.QueryHandlers
{
    public class ConsultaCarrinhoHandler : IRequestHandler<ConsultaCarrinho, ReadCarrinhoResponse>
    {
        private readonly ICarrinhoRepository _carrinhoRepository;

        public ConsultaCarrinhoHandler(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<ReadCarrinhoResponse> Handle(ConsultaCarrinho request, CancellationToken cancellationToken)
        {
            var item = await _carrinhoRepository.ConsultaCarrinho(request.CarrinhoId);

            if (item == null) return default;

            return new ReadCarrinhoResponse 
            {
                CarrinhoId = item.CarrinhoId,
                Itens = (from i in item.Items select new ReadItemCarrinhoResponse 
                {
                    ItemCarrinhoId = i.ItemCarrinhoId,
                    Produto = new ReadProdutoResponse 
                    {
                        CodProduto = i.Produto.CodProduto,
                        Nome = i.Produto?.Nome,
                        Descricao = i.Produto?.Descricao,
                        Preco = i.Produto.Preco
                    }

                }).ToList()
            };
        }
    }
}
