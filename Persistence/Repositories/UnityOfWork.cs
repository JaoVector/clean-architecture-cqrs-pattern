using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;

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
