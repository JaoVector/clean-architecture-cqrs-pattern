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
         Pedido CriaPedido(Guid UsuarioId, Guid EnderecoId, Guid CarrinhoId, CancellationToken cancellation);
         Task<Pedido?> ConsultaPedidoPorId(Guid id, CancellationToken cancellation);
         string GeraCodRatreio();
    }
}
