using FollowMe.Domain.Entities;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FollowMe.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {

        private readonly AppDbContext _appDbContext;

        public UsuarioRepository(AppDbContext appDb) : base(appDb)
        {
            _appDbContext = appDb;
        }

        public async Task<Usuario?> ConsultaUsuarioPorId(Guid id, CancellationToken cancellationToken)
        {

            var query = await _appDbContext.Usuarios
                       .Where(u => u.UsuarioId == id)
                       .Include(u => u.Enderecos)
                       .Include(c => c.Carrinho)
                            .ThenInclude(c => c.Items)
                                .ThenInclude(i => i.Produto)
                       .FirstOrDefaultAsync(cancellationToken);
               

                return query;
 
        }
    }
}

/*
 * 
 * 
 * 
 * c.Items
                                          .Select(i => new ItemCarrinho
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
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * .Select(u => new Usuario
                       {
                           UsuarioId = u.UsuarioId,
                           Nome = u.Nome,
                           Email = u.Email,
                           Enderecos = _appDbContext.Enderecos
                                       .Where(u => u.UsuarioId == id)
                                       .Select(e => new Endereco 
                                       {
                                           EnderecoId = e.EnderecoId,
                                           Cep = e.Cep,
                                           Rua = e.Rua,
                                           Bairro = e.Bairro,
                                           Numero = e.Numero
                      
                                       }).ToList(),

                           Carrinho = _appDbContext.Carrinho
                                      .Where(u => u.UsuarioId == id)
                                      .Select(c => new Carrinho 
                                      {
                                          CarrinhoId = c.CarrinhoId,
                                          Items = c.Items
                                          .Select(i => new ItemCarrinho
                                          {
                                              ItemCarrinhoId = i.ItemCarrinhoId,
                                              Produto = new Produto
                                              {
                                                  CodProduto = i.Produto.CodProduto,
                                                  Nome = i.Produto.Nome,
                                                  Descricao = i.Produto.Descricao,
                                                  Preco = i.Produto.Preco,

                                              },
                                              Quantidade = i.Quantidade,
                                          }).ToList()
                                      }).FirstOrDefault(),
                           
                       })
 * 
 * 
 * 
 * 
 * 
 * 
 */