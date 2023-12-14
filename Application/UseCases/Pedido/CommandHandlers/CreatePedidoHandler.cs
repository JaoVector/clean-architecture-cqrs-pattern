using AutoMapper;
using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Application.UseCases.Pedido.Commands;
using FollowMe.Application.UseCases.Pedido.Responses;
using FollowMe.Domain.Entities;
using FollowMe.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Pedido.CommandHandlers
{
    public class CreatePedidoHandler : IRequestHandler<CreatePedidoRequest, CreatePedidoResponse>
    {
        private readonly IPedidoRepository _pedidoRepo;
        private readonly IUnityOfWork _work;
        private readonly IMapper _mapper;

        public CreatePedidoHandler(IPedidoRepository pedidoRepo, IUnityOfWork work, IMapper mapper)
        {
            _pedidoRepo = pedidoRepo;
            _work = work;
            _mapper = mapper;
        }

        public async Task<CreatePedidoResponse> Handle(CreatePedidoRequest request, CancellationToken cancellationToken)
        {
            var pedido = _mapper.Map<Domain.Entities.Pedido>(request);

            pedido.CodRastreio = _pedidoRepo.GeraCodRatreio();

            _pedidoRepo.Cria(pedido);

            await _work.Commit(cancellationToken);

            return _mapper.Map<CreatePedidoResponse>(pedido);
        }
    }
}
