using Agile.Application.Projects.Queries;
using Agile.Application.Tasks.Queries;
using Agile.Application.Tasks.Queries.DTO;
using Agile.DAL.Context;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Infrastructure.QueryHandlers.Tasks
{
    public class TasksByPerformerIdQueryHandler :
        IRequestHandler<TasksCountByPerformerIdQuery, TasksCountByPerformerIdDto>,
        IRequestHandler<TasksByPerformerIdQuery, IEnumerable<TaskDto>>,
        IRequestHandler<TasksByPerformerIdFilterQuery, IEnumerable<TaskShortInformationDto>>
    {

        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public TasksByPerformerIdQueryHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TasksCountByPerformerIdDto> Handle(TasksCountByPerformerIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user is null)
                throw new NotFoundException(nameof(user));

            return new TasksCountByPerformerIdDto()
            {
                Tasks = await _context.Projects
                        .Include(p => p.Team)
                        .Include(p => p.Author)
                        .Include(p => p.Tasks)
                        .ToDictionaryAsync(k => _mapper.Map<ProjectDto>(k), i => i.Tasks.Where(t => t.PerformerId == request.Id)
                        .Count())
            };
        }

        public async Task<IEnumerable<TaskDto>> Handle(TasksByPerformerIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user is null)

                throw new NotFoundException(nameof(user));
            var tasks = await _context.Tasks
                                   .Where(t => t.Performer.Id == request.Id)
                                   .FilterByNameLessLength(45)
                                   .ToListAsync();

            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<IEnumerable<TaskShortInformationDto>> Handle(TasksByPerformerIdFilterQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user is null)
                throw new NotFoundException(nameof(user));

            return await _context.Tasks
                 .Where(t => t.Performer.Id == request.Id)
                 .FilterByYear(2020)
                 .Select(t => new TaskShortInformationDto
                 {
                     Id = t.Id,
                     Name = t.Name
                 })
                 .ToListAsync();
        }
    }

}

