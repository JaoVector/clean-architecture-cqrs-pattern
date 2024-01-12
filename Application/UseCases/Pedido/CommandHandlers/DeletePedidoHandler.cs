using FollowMe.Application.Shared.Exceptions;
using FollowMe.Application.UseCases.Pedido.Commands;
using FollowMe.Application.UseCases.Pedido.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Pedido.CommandHandlers
{
    public sealed record DeletePedidoHandler : IRequestHandler<DeletePedidoRequest, DeletePedidoResponse>
    {
        private readonly IPedidoRepository _pedidoRepo;
        private readonly IUnityOfWork _work;

        public DeletePedidoHandler(IPedidoRepository pedidoRepo, IUnityOfWork work)
        {
            _pedidoRepo = pedidoRepo;
            _work = work;
        }

        public async Task<DeletePedidoResponse> Handle(DeletePedidoRequest request, CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepo.ConsultaPedidoPorId(request.PedidoId, cancellationToken);

            if (pedido is null) throw new PedidoNotFound($"Pedido de Id {request.PedidoId} não Encontrado");

            _pedidoRepo.Exclui(pedido);

            pedido.Status = Domain.Enums.StatusPedido.Excluido;

            await _work.Commit(cancellationToken);

            _pedidoRepo.PedidoExcluido(pedido);

            return new DeletePedidoResponse 
            {
                CodPedido = pedido.CodPedido,
                CodRastreio = pedido.CodRastreio,
                Status = pedido.Status,
            };
        }
    }
}
