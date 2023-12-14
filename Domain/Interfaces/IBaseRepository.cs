using FollowMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Cria(T entity);
        void Atualiza(T entity);
        void Exclui(T entity);
        Task<T> Consulta(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task<List<T>> ConsultaTodos(int take, int skip, CancellationToken cancellationToken);
    }
}
