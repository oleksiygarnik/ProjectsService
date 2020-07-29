using Agile.Application.Tasks.Queries;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
    {

        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(IUnitOfWork work, IMapper mapper)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var task = await _work.EntityRepository.SingleOrDefault<Domain.Task>(t => t.Id == request.Id, cancellationToken);

            if (task is null)
                throw new NotFoundException(nameof(task));

            task.ChangeName(request.Name);
            task.ChangeDescription(request.Description);
            task.ChangeFinishedDate(request.FinishedAt);
            task.ChangeTaskState(request.TaskState);
            task.ChangeProject(request.ProjectId);
            task.ChangePerformer(request.PerformerId);

            await _work.Commit();

            return _mapper.Map<TaskDto>(task);
        }
    }
}
