using FollowMe.Application.Shared.Exceptions;
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
            try
            {
                await _contex.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw new ErroNoBanco($"Erro ao salvar dados no Banco {ex}");
            }
            
        }
    }
}
