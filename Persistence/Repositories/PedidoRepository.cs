using FollowMe.Domain.Entities;
using FollowMe.Domain.Enums;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FollowMe.Persistence.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext appDb) : base(appDb)
        {
        }

        public async Task<Pedido> AtualizaStatusPedido(Guid CodPedido, CancellationToken cancellation)
        {
            try
            {
                var pedido = await appDbContext.Pedidos.FirstOrDefaultAsync(x => x.CodPedido == CodPedido, cancellation);

                if (pedido is null) return default;

                var status = pedido.Status switch
                {
                    StatusPedido.Feito => pedido.Status = StatusPedido.Enviado,
                    StatusPedido.Enviado => pedido.Status = StatusPedido.SaiuParaEntrega,
                    StatusPedido.SaiuParaEntrega => pedido.Status = StatusPedido.Entregue,
                    StatusPedido.Entregue => pedido.Status = StatusPedido.Concluido,
                    _ => pedido.Status = StatusPedido.Excluido
                };

                pedido.Status = status;

                appDbContext.Update(pedido);

                return pedido;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public string GeraCodRatreio()
        {
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rand = new Random();

            return new string 
            (
                Enumerable.Repeat(caracteres, 10).Select(x => x[rand.Next(x.Length)]).ToArray()
            );
        }
    }
}

/*
 *  switch (pedido.Status)
            {
                case StatusPedido.Feito:
                    pedido.Status = StatusPedido.Enviado;
                    break;
                case StatusPedido.Enviado:
                    pedido.Status = StatusPedido.SaiuParaEntrega;
                    break;
                case StatusPedido.SaiuParaEntrega:
                    pedido.Status = StatusPedido.Entregue;
                    break;
                case StatusPedido.Entregue:
                    pedido.Status = StatusPedido.Concluido;
                    break;
                default:
                    pedido.Status = StatusPedido.Excluido;
                    break;
            }
 *
 */