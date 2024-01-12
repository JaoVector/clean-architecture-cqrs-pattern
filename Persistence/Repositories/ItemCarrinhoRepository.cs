using FollowMe.Application.Shared.Exceptions;
using FollowMe.Domain.Entities;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using FollowMe.Persistence.Messaging;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace FollowMe.Persistence.Repositories
{
    public class ItemCarrinhoRepository : BaseRepository<ItemCarrinho>, IItemCarrinhoRepository
    {
        private readonly AppDbContext _context;
        private readonly IBusControl _bus;

        public ItemCarrinhoRepository(AppDbContext appDb, IBusControl bus) : base(appDb)
        {
            _context = appDb;
            _bus = bus;
        }

        public void ItemAdicionadoNoCarrinho(ItemCarrinho itemCarrinho)
        {
            try
            {
                var query = _context.ItemCarrinho.
                     Where(i => i.ItemCarrinhoId == itemCarrinho.ItemCarrinhoId)
                     .Include(c => c.Carrinho)
                             .ThenInclude(c => c.Items)
                                 .ThenInclude(i => i.Produto)
                     .FirstOrDefault();

                var user = _context.Usuarios
                    .Where(u => u.Carrinho.CarrinhoId == query.CarrinhoId).FirstOrDefault();

                if (user is null) throw new UsuarioNotFound($"Usuario não Encontrado");

                PublicaMensagensUsuarios.PublicaItemAdicionadoNoCarrinho(_bus, query, user);

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro {ex}");
            }
           
        }
    }
}