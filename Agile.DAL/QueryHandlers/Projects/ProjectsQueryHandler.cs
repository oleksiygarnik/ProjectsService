using Agile.Application.Projects.Queries;
using Agile.Application.Tasks.Queries;
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

namespace Agile.Infrastructure.QueryHandlers.Projects
{
    public class ProjectsQueryHandler :
        IRequestHandler<ProjectsQuery, IEnumerable<ProjectDto>>,
        IRequestHandler<ProjectByIdQuery, ProjectDto>,
        IRequestHandler<ProjectsDetailInformationQuery, IEnumerable<ProjectDetailInformationDto>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public ProjectsQueryHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProjectDto>> Handle(ProjectsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var projects = await _context.Projects
                .Include(p => p.Author)
                .Include(p => p.Team)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<ProjectDto> Handle(ProjectByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var project = await _context.Projects
                .Include(p => p.Author)
                .Include(p => p.Team)
                .SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (project is null)
                throw new NotFoundException(nameof(project));

            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<IEnumerable<ProjectDetailInformationDto>> Handle(ProjectsDetailInformationQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var projects = await _context.Projects
                .Include(p => p.Author)
                .Include(p => p.Team)
                    .ThenInclude(t => t.Members)
                .Include(p => p.Tasks)
                .ToListAsync();

            var result = new List<ProjectDetailInformationDto>();

            foreach (var project in projects)
            {
                var dto = new ProjectDetailInformationDto()
                {
                    Project = _mapper.Map<ProjectDto>(project),
                    LongestTask = _mapper.Map<TaskDto>(project.Tasks.OrderByDescending(t => t.Description.Length).FirstOrDefault()),
                    ShortestTask = _mapper.Map<TaskDto>(project.Tasks.OrderBy(t => t.Name.Length).FirstOrDefault()),
                    TeamCount = (project.Description.Length > 20 || project.Tasks.Count() < 3) ? project.Team.Members.Count() : 0
                };

                result.Add(dto);
            }

            return result;
        }

        
    }
}
