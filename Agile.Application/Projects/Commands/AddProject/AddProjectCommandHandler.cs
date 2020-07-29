using Agile.Domain;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Application.Projects.Commands.AddProject
{
    public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, int>
    {
        private readonly IUnitOfWork _work;
        private readonly IEntityRepository _repository;
        private readonly IMapper _mapper;

        public AddProjectCommandHandler(IUnitOfWork work, IMapper mapper)
        {
            _work = work ?? throw new ArgumentNullException(nameof(work));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = work.EntityRepository;
        }
        public async Task<int> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var project = _mapper.Map<Project>(request);

            await _repository.Add(project);
            await _work.Commit(cancellationToken);

            return project.Id;
        }
    }
}
