using Agile.Domain;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Users.Commands.AddUserCommand
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IUnitOfWork _work;
        private readonly IEntityRepository _repository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUnitOfWork work, IMapper mapper)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = work.EntityRepository;
        }

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var user = _mapper.Map<User>(request);

            await _repository.Add(user);
            await _work.Commit(cancellationToken);

            return user.Id;
        }
    }
}
