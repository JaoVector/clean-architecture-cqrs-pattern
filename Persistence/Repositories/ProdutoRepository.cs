using FollowMe.Application.Shared.Exceptions;
using FollowMe.Domain.Entities;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FollowMe.Persistence.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProdutoRepository(AppDbContext appDb, AppDbContext appDbContext) : base(appDb)
        {
            _appDbContext = appDbContext;
        }

        public void ExcluiProduto(Produto produto)
        {
            try
            {
                var itens = _appDbContext.ItemCarrinho
                        .Where(i => i.CodProduto == produto.CodProduto)
                        .Include(c => c.Carrinho)
                             .ThenInclude(c => c.Items)
                                 .ThenInclude(i => i.Produto)
                        .ToList();

                if (itens != null)
                {
                    _appDbContext.RemoveRange(itens);
                }

                var itensP = _appDbContext.ItensPedido
                           .Where(i => i.CodProduto == produto.CodProduto)
                           .AsNoTracking()
                           .Include(c => c.Produto)
                           .ToList();
                
                if (itensP != null) 
                {
                    _appDbContext.RemoveRange(itensP);
                }

                _appDbContext.SaveChanges();

                _appDbContext.Entry(produto).State = EntityState.Detached;

                _appDbContext.Produtos.Remove(produto);

            }
            catch (Exception ex)
            {

                throw new BadRequestException($"Erro ao Excluir Produto {ex}");
            }
            
        }
    }
}