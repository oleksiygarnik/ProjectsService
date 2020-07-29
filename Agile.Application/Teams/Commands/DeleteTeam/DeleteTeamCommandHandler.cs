using Agile.Domain;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Teams.Commands.DeleteTeam
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand>
    {
        private readonly IUnitOfWork _work;
        private readonly IEntityRepository _repository;

        public DeleteTeamCommandHandler(IUnitOfWork work)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _repository = work.EntityRepository;
        }

        public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var teamForDelete = await _repository.SingleOrDefault<Team>(t => t.Id == request.Id, cancellationToken);

            if (teamForDelete is null)
                throw new ArgumentNullException(nameof(teamForDelete)); //return Unit.Value;

            await _repository.Remove(teamForDelete);
            await _work.Commit();

            return Unit.Value;
        }
    }
}
