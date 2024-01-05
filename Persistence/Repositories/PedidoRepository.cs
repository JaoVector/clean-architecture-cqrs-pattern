using FollowMe.Domain.Entities;
using FollowMe.Domain.Enums;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using FollowMe.Persistence.Messaging;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace FollowMe.Persistence.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IBusControl _bus;

        public PedidoRepository(AppDbContext appDb, IBusControl bus) : base(appDb)
        {
            _appDbContext = appDb;
            _bus = bus;
        }

        public async Task<Pedido> AtualizaStatusPedido(Guid CodPedido, CancellationToken cancellation)
        {
            try
            {
                
                var pedido = await ConsultaPedidoPorId(CodPedido, cancellation);

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

                _appDbContext.Update(pedido);

                PublicaMensagemPedidos.PublicaStatusPedido(_bus, pedido);

                return pedido;

            }

            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<Pedido?> ConsultaPedidoPorId(Guid id, CancellationToken cancellation)
        {
            var query = await _appDbContext.Pedidos
                        .Where(p => p.CodPedido == id)
                        .Include(u => u.Usuario)
                        .Include(e => e.Endereco)
                        .Include(i => i.ItensPedido)
                            .ThenInclude(p => p.Produto)
                        .FirstOrDefaultAsync(cancellation);

            return query;
        }

        public Pedido CriaPedido(Guid UsuarioId, Guid EnderecoId, Guid CarrinhoId, CancellationToken cancellation)
        {

            var pedido = new Pedido
            {
                CodPedido = new Guid(),
                UsuarioId = UsuarioId,
                EnderecoId = EnderecoId,
            };

            pedido.CodRastreio = GeraCodRatreio();

            _appDbContext.Pedidos.Add(pedido);

            var itens = _appDbContext.ItemCarrinho
                                .Where(it => it.CarrinhoId == CarrinhoId)
                                .AsNoTracking()
                                .Select(x => new
                                {
                                    x.Quantidade,
                                    x.CodProduto
                                });

            foreach (var item in itens)
            {
                var itemPedido = new ItemPedido
                {
                    ItemPedidoId = new Guid(),
                    PedidoId = pedido.CodPedido,
                    CodProduto = item.CodProduto,
                    Quantidade = item.Quantidade,
                };

                _appDbContext.ItensPedido.Add(itemPedido);

            }

            ExcluiItensCarrinho(CarrinhoId);

            PublicaMensagemPedidos.PublicaPedido(_bus, pedido);

            return pedido;

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

        public void ExcluiItensCarrinho(Guid? CarrinhoId) 
        {
            var itensCarrinho = appDbContext.ItemCarrinho
                                .Where(it => it.CarrinhoId == CarrinhoId)
                                .Select(x => new ItemCarrinho
                                {
                                    ItemCarrinhoId = x.ItemCarrinhoId,
                                    Produto = new Produto
                                    {
                                        CodProduto = x.Produto.CodProduto,
                                        Nome = x.Produto.Nome,
                                        Descricao = x.Produto.Descricao,
                                        Preco = x.Produto.Preco,

                                    },
                                }).ToList();

            _appDbContext.ItemCarrinho.RemoveRange(itensCarrinho);
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
 *
 *
 *
 *var itens = _appDbContext.ItemCarrinho
                                .Where(it => it.CarrinhoId == CarrinhoId)
                                .AsNoTracking()
                                .Select(x => new
                                {
                                    x.Quantidade,
                                    x.CodProduto
                                });

            foreach (var item in itens)
            {
                var itemPedido = new ItemPedido
                {
                    ItemPedidoId = new Guid(),
                    PedidoId = pedido.CodPedido,
                    CodProduto = item.CodProduto,
                    Quantidade = item.Quantidade,
                };

                _appDbContext.ItensPedido.Add(itemPedido);
                
            }
 *
 *
 *
 *
 *
 *
 *.Select(p => new Pedido 
                        {
                            CodPedido= p.CodPedido,
                            CodRastreio = p.CodRastreio,
                            Usuario = _appDbContext.Usuarios
                                        .FirstOrDefault(u => u.UsuarioId == p.UsuarioId),

                            Endereco = _appDbContext.Enderecos
                                       .FirstOrDefault(e => e.EnderecoId == p.EnderecoId),

                            ItensPedido = p.ItensPedido
                                    .Select(i => new ItemPedido 
                                    {
                                        ItemPedidoId = i.ItemPedidoId,
                                        Produto = new Produto
                                        {
                                            CodProduto = i.Produto.CodProduto,
                                            Nome = i.Produto.Nome,
                                            Descricao = i.Produto.Descricao,
                                            Preco = i.Produto.Preco,

                                        },
                                        Quantidade= i.Quantidade

                                    }).ToList(),

                        })
 *
 *
 *
 */