using Agile.Application.Projects.Queries;
using Agile.Domain;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, ProjectDto>
    {

        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IUnitOfWork work, IMapper mapper)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ProjectDto> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var project = await _work.EntityRepository.SingleOrDefault<Project>(t => t.Id == request.Id, cancellationToken);

            if (project is null)
                throw new NotFoundException(nameof(project));

            project.ChangeName(request.Name);
            project.ChangeDescription(request.Description);
            project.ChangeTeam(request.TeamId);
            project.ChangeDeadline(request.Deadline);
            project.ChangeAuthor(request.AuthorId);

            await _work.Commit();

            return _mapper.Map<ProjectDto>(project);
        }
    }
}
