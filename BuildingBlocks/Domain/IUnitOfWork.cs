using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUnitOfWork
    {
        IEntityRepository EntityRepository { get; }

        Task Commit(CancellationToken cancellationToken = default(CancellationToken));
    }
}
