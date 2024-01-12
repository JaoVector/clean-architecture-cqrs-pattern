using FollowMe.Application.UseCases.ItemCarrinho.Commands;
using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.ItemCarrinho.CommandHandlers
{
    public class AddItemCarrinhoHandler : IRequestHandler<AddItemCarrinhoRequest, AddItemCarrinhoResponse>
    {
        
        private readonly IItemCarrinhoRepository _itemCarrinhoRepository;
        private readonly IUnityOfWork _work;

        public AddItemCarrinhoHandler(IItemCarrinhoRepository itemCarrinhoRepository, IUnityOfWork work)
        {
            _itemCarrinhoRepository = itemCarrinhoRepository;
            _work = work;
        }

        public async Task<AddItemCarrinhoResponse> Handle(AddItemCarrinhoRequest request, CancellationToken cancellationToken)
        {

            var item = new Domain.Entities.ItemCarrinho
            {
                ItemCarrinhoId = new Guid(),
                CarrinhoId = request.carrinhoId,
                CodProduto= request.codProduto,
                Quantidade = request.Quantidade
            };

             _itemCarrinhoRepository.Cria(item);

             await _work.Commit(cancellationToken);

            _itemCarrinhoRepository.ItemAdicionadoNoCarrinho(item);

            return new AddItemCarrinhoResponse
            {
                ItemCarrinhoId= item.ItemCarrinhoId,
                CarrinhoId = item.CarrinhoId,
                CodProduto = item.CodProduto,
                Quantidade = item.Quantidade
                
            };
        }
    }
}
