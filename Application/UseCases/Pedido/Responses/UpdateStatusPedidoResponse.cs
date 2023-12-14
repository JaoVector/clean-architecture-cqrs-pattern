using FollowMe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Pedido.Responses
{
    public sealed record UpdateStatusPedidoResponse(string CodRastreio, StatusPedido Status);
}
