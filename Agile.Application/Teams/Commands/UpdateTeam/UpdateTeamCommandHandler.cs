using Agile.Application.Teams.Queries;
using Agile.Domain;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Teams.Commands.UpdateTeam
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, TeamDTO>
    {

        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public UpdateTeamCommandHandler(IUnitOfWork work, IMapper mapper)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<TeamDTO> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var team = await _work.EntityRepository.SingleOrDefault<Team>(t => t.Id == request.Id, cancellationToken);

            if (team is null)
                throw new NotFoundException(nameof(team));

            team.ChangeName(request.Name);

            await _work.Commit();

            return _mapper.Map<TeamDTO>(team);
        }
    }
}
