using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Pedido.Commands
{
    public sealed record CreateItemPedido(Guid pedidoId, Guid codProduto, int Quantidade);
}
