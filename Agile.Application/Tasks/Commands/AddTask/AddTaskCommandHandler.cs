using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Tasks.Commands.AddTask
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, int>
    {
        private readonly IUnitOfWork _work;
        private readonly IEntityRepository _repository;
        private readonly IMapper _mapper;

        public AddTaskCommandHandler(IUnitOfWork work, IMapper mapper)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = work.EntityRepository;
        }
        public async Task<int> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var task = _mapper.Map<Domain.Task>(request);

            await _repository.Add(task);
            await _work.Commit(cancellationToken);

            return task.Id;
        }
    }
}
