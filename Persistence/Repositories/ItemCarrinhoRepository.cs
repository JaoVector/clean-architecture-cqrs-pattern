using FollowMe.Domain.Entities;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Persistence.Repositories
{
    public class ItemCarrinhoRepository : BaseRepository<ItemCarrinho>, IItemCarrinhoRepository
    {
        private readonly AppDbContext _context;

        public ItemCarrinhoRepository(AppDbContext appDb) : base(appDb)
        {
            _context = appDb;
        }
    }
}
