using FollowMe.Application.Shared.Exceptions;
using FollowMe.Application.UseCases.ItemCarrinho.Commands;
using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.ItemCarrinho.CommandHandlers
{
    public class DeleteItemCarrinhoHandler : IRequestHandler<DeleteItemCarrinhoRequest, DeleteItemCarrinhoResponse>
    {
        private readonly IItemCarrinhoRepository _itemCarrinhoRepository;
        private readonly IUnityOfWork _work;

        public DeleteItemCarrinhoHandler(IItemCarrinhoRepository itemCarrinhoRepository, IUnityOfWork work)
        {
            _itemCarrinhoRepository = itemCarrinhoRepository;
            _work = work;
        }

        public async Task<DeleteItemCarrinhoResponse> Handle(DeleteItemCarrinhoRequest request, CancellationToken cancellationToken)
        {
            var item = await _itemCarrinhoRepository.Consulta(x => x.ItemCarrinhoId == request.ItemCarrinhoId, cancellationToken);

            if (item is null) throw new NotFoundExceptions($"ItemCarrinho de Id {request.ItemCarrinhoId} não Encontrado");

            _itemCarrinhoRepository.Exclui(item);

            await _work.Commit(cancellationToken);

            return new DeleteItemCarrinhoResponse 
            {
                ItemCarrinhoId = item.ItemCarrinhoId,
            };
        }
    }
}
