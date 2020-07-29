using Agile.Domain;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IUnitOfWork _work;
        private readonly IEntityRepository _repository;

        public DeleteProjectCommandHandler(IUnitOfWork work)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _repository = work.EntityRepository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var projectForDelete = await _repository.SingleOrDefault<Project>(t => t.Id == request.Id, cancellationToken);

            if (projectForDelete is null)
                throw new ArgumentNullException(nameof(projectForDelete)); //return Unit.Value;

            await _repository.Remove(projectForDelete);
            await _work.Commit();

            return Unit.Value;
        }
    }
}
