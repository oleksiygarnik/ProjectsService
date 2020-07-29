using Agile.Application.Users.Queries;
using Agile.DAL.Context;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Infrastructure.QueryHandlers.Users
{
    public class UsersQueryHandler :
        IRequestHandler<UsersQuery, IEnumerable<UserDto>>,
        IRequestHandler<UsersOrderingQuery, IEnumerable<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

    public UsersQueryHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<UserDto>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var users = await _context.Users
                .Include(u => u.Team)
                .Include(u => u.Tasks)
                .Include(u => u.Projects)
                .ToListAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<IEnumerable<UserDto>> Handle(UsersOrderingQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var users = await _context.Users
                .Include(u => u.Tasks)
                .SortUserByFirstname(SortDirection.Asending)
                .SortTaskByNameLength(SortDirection.Descending)
                .ToListAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
