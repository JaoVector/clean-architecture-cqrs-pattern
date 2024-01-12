using FollowMe.Application.Shared.Exceptions;
using FollowMe.Domain.Entities;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FollowMe.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected readonly AppDbContext appDbContext;

        public BaseRepository(AppDbContext appDb)
        {
            appDbContext = appDb;
        }

        public void Cria(T entity)
        {
            try
            {
                entity.DataCriacao = DateTimeOffset.Now;
                appDbContext.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {

                throw new ErroNoBanco($"Erro ao Salvar Dados no Banco {ex}");
            }
        }

        public void Atualiza(T entity)
        {
            try
            {
                entity.DataAtualizacao = DateTimeOffset.Now;
                appDbContext.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {

                throw new ErroNoBanco($"Erro ao Atualizar Dados no Banco {ex}");
            }
        }

        public void Exclui(T entity)
        {
            try
            {
                 entity.DataExclusao = DateTimeOffset.Now;
                 appDbContext.Set<T>().Remove(entity);
            }
            catch (Exception ex) { throw new ErroNoBanco($"Erro ao Excluir Dados do Banco {ex}"); }
        }

        public async Task<T> Consulta(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            try
            {
                return await appDbContext.Set<T>().SingleOrDefaultAsync(expression, cancellationToken);
            }
            catch (Exception ex)
            {

                throw new NotFoundExceptions($"Erro ao Retornar Valores do Banco {ex}");
            }
        }

        public async Task<List<T>> ConsultaTodos(int skip, int take, CancellationToken cancellationToken)
        {
            try
            {
                return await appDbContext.Set<T>().AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw new NotFoundExceptions($"Erro ao Retornar Valores do Banco {ex}");
            }
        }
    }
}
