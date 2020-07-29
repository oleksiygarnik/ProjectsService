using Agile.DAL.Context;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEntityRepository EntityRepository { get; }

        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            EntityRepository = new EntityRepository(context);
        }

        public async Task Commit(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);
    }
}
