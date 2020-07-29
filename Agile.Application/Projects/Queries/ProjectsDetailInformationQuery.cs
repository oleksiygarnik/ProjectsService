using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Projects.Queries
{
    [DataContract]
    public class ProjectsDetailInformationQuery : IRequest<IEnumerable<ProjectDetailInformationDto>>
    {
    }
}
