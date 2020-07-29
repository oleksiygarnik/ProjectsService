using Agile.Application.Users.Queries;
using Agile.Domain;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {

        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUnitOfWork work, IMapper mapper)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var user = await _work.EntityRepository.SingleOrDefault<User>(t => t.Id == request.Id, cancellationToken);

            if (user is null)
                throw new NotFoundException(nameof(user));

            user.ChangeFirstname(request.FirstName);
            user.ChangeLastname(request.LastName);
            user.ChangeEmail(request.Email);

            if (request.TeamId.HasValue)
                user.ChangeTeam(request.TeamId.Value);

            await _work.Commit();

            return _mapper.Map<UserDto>(user);
        }

    }
}
