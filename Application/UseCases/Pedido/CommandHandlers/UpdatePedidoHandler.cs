using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdatePedidoHandler(IPedidoRepository pedidoRepo, IUnityOfWork work, IMapper mapper)
        {
            _pedidoRepo = pedidoRepo;
            _work = work;
            _mapper = mapper;
        }

        public async Task<UpdateStatusPedidoResponse> Handle(UpdateStatusPedidoRequest request, CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepo.AtualizaStatusPedido(request.CodPedido, cancellationToken);
            
            await _work.Commit(cancellationToken);

            return _mapper.Map<UpdateStatusPedidoResponse>(pedido);
        }
    }
}
