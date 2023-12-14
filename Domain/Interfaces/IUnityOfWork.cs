using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Domain.Interfaces
{
    public interface IUnityOfWork
    {
        Task Commit(CancellationToken cancellationToken);
    }
}
