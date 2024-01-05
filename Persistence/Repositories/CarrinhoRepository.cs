using FollowMe.Domain.Entities;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FollowMe.Persistence.Repositories
{
    public class CarrinhoRepository : BaseRepository<Carrinho>, ICarrinhoRepository
    {

        private readonly AppDbContext _context;

        public CarrinhoRepository(AppDbContext appDb) : base(appDb)
        {
            _context = appDb;
        }

        public async Task<Carrinho?> ConsultaCarrinho(Guid CarrinhoId)
        {
            var query = await _context.Carrinho
                .Where(c => c.CarrinhoId == CarrinhoId)
                .AsNoTracking()
                .Select(c => new Carrinho
                {
                    CarrinhoId= c.CarrinhoId,
                    Items= c.Items.Select(i => new ItemCarrinho 
                    {
                        ItemCarrinhoId = i.ItemCarrinhoId,
                        Produto = new Produto 
                        {
                            CodProduto = i.Produto.CodProduto,
                            Nome = i.Produto.Nome,
                            Descricao = i.Produto.Descricao,
                            Preco = i.Produto.Preco,

                        },
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return query;
        }
    }
}

/*
 * 
 * 
 * c.CarrinhoId,
                    c.Items =
                    c.Items.Select(i => new ItemCarrinho
                    {
                        i.ItemCarrinhoId,
                        produto = new Produto
                        {
                            CodProduto = i.Produto.CodProduto,
                            Nome = i.Produto.Nome,
                            Descricao = i.Produto.Descricao,
                            Preco = i.Produto.Preco,
                        }


                    }).ToList()
 * 
 * 
 * 
 * 
 */