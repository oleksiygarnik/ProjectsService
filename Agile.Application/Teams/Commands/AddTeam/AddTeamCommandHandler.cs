using Agile.Domain;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Teams.Commands.AddTeam
{
    public class AddTeamCommandHandler : IRequestHandler<AddTeamCommand, int>
    {
        private readonly IUnitOfWork _work;
        private readonly IEntityRepository _repository;
        private readonly IMapper _mapper;

        public AddTeamCommandHandler(IUnitOfWork work, IMapper mapper)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = work.EntityRepository;
        }
        public async Task<int> Handle(AddTeamCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var team = _mapper.Map<Team>(request);

            await _repository.Add(team);
            await _work.Commit(cancellationToken);

            return team.Id;
        }
    }
}
