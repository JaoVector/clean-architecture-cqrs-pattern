using FollowMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Domain.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
         Task<Pedido> AtualizaStatusPedido(Guid id, CancellationToken cancellation);
         string GeraCodRatreio();
    }
}
