using Agile.Application.Teams.Queries;
using Agile.DAL.Context;
using Agile.Domain;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Infrastructure.QueryHandlers.Teams
{
    public class TeamsQueryHandler :
        IRequestHandler<TeamsQuery, IEnumerable<TeamDTO>>,
        IRequestHandler<TeamByIdQuery, TeamDTO>,
        IRequestHandler<TeamsOrderedAndSortedQuery, IEnumerable<TeamDTO>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
       
        private IQueryable<TeamRecord> RecordSet
            => from team in _context.Teams
               join member in _context.Users on team.Id equals member.TeamId
               where (DateTime.Now.Year - member.Birthday.Year) > 10
               orderby member.RegisteredAt descending
               group member by new { team.Id, team.Name } into g
               select new TeamRecord
               {
                   Id = g.Key.Id,
                   Name = g.Key.Name,
                   Members = from mem in _context.Users
                             where mem.TeamId == g.Key.Id
                             select mem
                             //from mem in g select mem ??? why not???
               };


        public TeamsQueryHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TeamDTO>> Handle(TeamsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var teams = await _context.Teams
                                        .Include(t => t.Members)
                                        .ToListAsync();

            return _mapper.Map<IEnumerable<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> Handle(TeamByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var team = await _context.Teams.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (team is null)
                throw new NotFoundException(nameof(team));

            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<IEnumerable<TeamDTO>> Handle(TeamsOrderedAndSortedQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var records = await RecordSet.ToListAsync();

            return _mapper.Map<IEnumerable<TeamDTO>>(records);
        }
    }
}
