using FollowMe.Domain.Entities;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
            catch (Exception)
            {

                throw;
            }
        }

        public void Atualiza(T entity)
        {
            try
            {
                entity.DataAtualizacao = DateTimeOffset.Now;
                //appDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
                appDbContext.Set<T>().Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Exclui(T entity)
        {
            try
            {
                 entity.DataExclusao = DateTimeOffset.Now;
                 appDbContext.Set<T>().Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> Consulta(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            try
            {
                return await appDbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(expression, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<T>> ConsultaTodos(int skip, int take, CancellationToken cancellationToken)
        {
            try
            {
                return await appDbContext.Set<T>().AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
