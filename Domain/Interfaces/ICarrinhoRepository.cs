using FollowMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Domain.Interfaces
{
    public interface ICarrinhoRepository : IBaseRepository<Carrinho>
    {
        Task<Carrinho?> ConsultaCarrinho(Guid CarrinhoId);
    }
}
