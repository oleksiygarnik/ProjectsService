using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Projects.Queries
{
    [DataContract]
    public class ProjectByIdQuery : IRequest<ProjectDto>
    {
        public int Id { get; set; }
    }
}
