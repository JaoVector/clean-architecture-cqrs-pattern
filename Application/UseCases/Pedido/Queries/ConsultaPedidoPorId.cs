using FollowMe.Application.UseCases.Pedido.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Pedido.Queries
{
    public sealed record ConsultaPedidoPorId(Guid PedidoId) : IRequest<ReadPedidoResponse>;
}
