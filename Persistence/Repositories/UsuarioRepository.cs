using FollowMe.Application.Shared.Exceptions;
using FollowMe.Domain.Entities;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using FollowMe.Persistence.Messaging;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace FollowMe.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly IBusControl _bus;

        public UsuarioRepository(AppDbContext appDb, IBusControl bus) : base(appDb)
        {
            _appDbContext = appDb;
            _bus = bus;
        }

        public async Task<Usuario?> ConsultaUsuarioPorId(Guid id, CancellationToken cancellationToken)
        {
            try
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
            catch (ErroNoBanco ex)
            {

                throw new ErroNoBanco($"Erro na Consulta {ex}");

            }
            catch (ErroSistemico ex)
            {
                throw new ErroSistemico($"Um Endereco precisa ser cadastrado {ex}");
            }
        }

        public void PublicaUsuario(Usuario usuario)
        {
            PublicaMensagensUsuarios.PublicaUsuario(_bus, usuario);
        }

        public void UsuarioAtualizado(Usuario usuario)
        {
            PublicaMensagensUsuarios.UsuarioAtualizado(_bus, usuario);
        }

        public void UsuarioExcluido(Usuario usuario)
        {
            PublicaMensagensUsuarios.UsuarioExcluido(_bus, usuario);
        }
    }
}