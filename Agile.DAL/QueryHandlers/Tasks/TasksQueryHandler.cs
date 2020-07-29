using Agile.Application.Tasks.Queries;
using Agile.Application.Tasks.Queries.DTO;
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

namespace Agile.Infrastructure.QueryHandlers.Tasks
{
    public class TasksQueryHandler :
        IRequestHandler<TasksQuery, IEnumerable<TaskDto>>,
        IRequestHandler<TaskByIdQuery, TaskDto>

    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public TasksQueryHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TaskDto>> Handle(TasksQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var tasks = await _context.Tasks
                .Include(t => t.Performer)
                .Include(t => t.Project)
                .ToListAsync();

            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto> Handle(TaskByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var task = await _context.Tasks
                .Include(t => t.Performer)
                .Include(t => t.Project)
                .SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (task is null)
                throw new NotFoundException(nameof(task));

            return _mapper.Map<TaskDto>(task);
        }
    }
}
