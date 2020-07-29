using Agile.Application.Projects.Queries;
using Agile.Application.Tasks.Queries;
using Agile.Application.Users.Queries;
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

namespace Agile.Infrastructure.QueryHandlers.Users
{
        public class UsersByQueryHandler :
        IRequestHandler<UserByIdQuery, UserDto>,
        IRequestHandler<UserByIdDetailInformationQuery, UserDetailInformationDto>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public UsersByQueryHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       
                                                 
        public async Task<UserDto> Handle(UserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = await _context.Users.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (user is null)
                throw new NotFoundException(nameof(user));

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDetailInformationDto> Handle(UserByIdDetailInformationQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = await _context.Users
                .Include(u => u.Team)
                .Include(u => u.Projects)
                .Include(u => u.Tasks)
                .SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (user is null)
                throw new NotFoundException(nameof(user));

            var inProcess = new List<TaskState>() { TaskState.Canceled, TaskState.Started, TaskState.Created };

            var lastProject =  user.Projects?
                                .OrderByDescending(p => p.CreatedAt)
                                .FirstOrDefault();

            var userInfoDto = new UserDetailInformationDto
            {
                User = _mapper.Map<UserDto>(user),
                LastProject = _mapper.Map<ProjectDto>(lastProject),
                TasksCount = lastProject is null ? 0 : user.Tasks.Where(t => t.ProjectId == lastProject.Id).Count(),
                TasksCanceledCount = user.Tasks.Where(t => inProcess.Contains(t.TaskState)).Count(),
                LongestTask = _mapper.Map<TaskDto>(user.Tasks.OrderBy(t => t.FinishedAt - t.CreatedAt).FirstOrDefault())
            };

            return userInfoDto;
        }
    }
}
