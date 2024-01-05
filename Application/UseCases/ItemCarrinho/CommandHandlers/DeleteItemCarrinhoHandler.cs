using FollowMe.Application.UseCases.ItemCarrinho.Commands;
using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            _itemCarrinhoRepository.Exclui(item);

            await _work.Commit(cancellationToken);

            return new DeleteItemCarrinhoResponse 
            {
                ItemCarrinhoId = item.ItemCarrinhoId,
            };
        }
    }
}
