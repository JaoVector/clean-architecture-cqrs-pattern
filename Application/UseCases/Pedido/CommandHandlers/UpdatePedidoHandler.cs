using FollowMe.Application.Shared.Exceptions;
using FollowMe.Application.UseCases.Pedido.Commands;
using FollowMe.Application.UseCases.Pedido.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Pedido.CommandHandlers
{
    public class UpdatePedidoHandler : IRequestHandler<UpdateStatusPedidoRequest, UpdateStatusPedidoResponse>
    {
        private readonly IPedidoRepository _pedidoRepo;
        private readonly IUnityOfWork _work;
        
        public UpdatePedidoHandler(IPedidoRepository pedidoRepo, IUnityOfWork work)
        {
            _pedidoRepo = pedidoRepo;
            _work = work;
        }

        public async Task<UpdateStatusPedidoResponse> Handle(UpdateStatusPedidoRequest request, CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepo.AtualizaStatusPedido(request.CodPedido, cancellationToken);

            if (pedido is null) throw new PedidoNotFound($"Pedido de Id {request.CodPedido} não Encontrado");

            await _work.Commit(cancellationToken);

            return new UpdateStatusPedidoResponse 
            {
                CodRastreio = pedido.CodRastreio,
                Status = pedido.Status,
            };
        }
    }
}
