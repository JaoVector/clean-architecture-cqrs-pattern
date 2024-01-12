using FollowMe.Application.UseCases.Pedido.Commands;
using FollowMe.Application.UseCases.Pedido.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Pedido.CommandHandlers
{
    public class CreatePedidoHandler : IRequestHandler<CreatePedidoRequest, CreatePedidoResponse>
    {
        private readonly IPedidoRepository _pedidoRepo;
        private readonly IUnityOfWork _work;
        
        public CreatePedidoHandler(IPedidoRepository pedidoRepo, IUnityOfWork work)
        {
            _pedidoRepo = pedidoRepo;
            _work = work;
        }

        public async Task<CreatePedidoResponse> Handle(CreatePedidoRequest request, CancellationToken cancellationToken)
        {
           
            var pedido = _pedidoRepo.CriaPedido(request.UsuarioId, request.EnderecoId, request.CarrinhoId, cancellationToken);

            await _work.Commit(cancellationToken);

            return new CreatePedidoResponse 
            {
                CodPedido = pedido.CodPedido,
                CodRastreio = pedido.CodRastreio,
                Status= pedido.Status,
                UsuarioId = pedido.UsuarioId,
                EnderecoId = pedido.EnderecoId
            };
        }
    }
}
