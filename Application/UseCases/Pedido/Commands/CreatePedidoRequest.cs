using FollowMe.Application.UseCases.Pedido.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Pedido.Commands
{
    public sealed record CreatePedidoRequest(Guid UsuarioId) : IRequest<CreatePedidoResponse>;
}
