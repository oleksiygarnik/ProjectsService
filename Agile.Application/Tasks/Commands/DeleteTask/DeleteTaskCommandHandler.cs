using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IUnitOfWork _work;
        private readonly IEntityRepository _repository;

        public DeleteTaskCommandHandler(IUnitOfWork work)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _repository = work.EntityRepository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var taskForDelete = await _repository.SingleOrDefault<Domain.Task>(t => t.Id == request.Id, cancellationToken);

            if (taskForDelete is null)
                throw new ArgumentNullException(nameof(taskForDelete)); //return Unit.Value;

            await _repository.Remove(taskForDelete);
            await _work.Commit();

            return Unit.Value;
        }
    }
}
