using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {

        private readonly AppDbContext _contex;

        public UnityOfWork(AppDbContext contex)
        {
            _contex = contex;
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _contex.SaveChangesAsync(cancellationToken);
        }
    }
}
