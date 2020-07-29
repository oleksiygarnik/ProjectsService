using Agile.Application.Projects.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Projects.Commands.UpdateProject
{
    [DataContract]
    public class UpdateProjectCommand : IRequest<ProjectDto>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public DateTime Deadline { get; set; }

        [DataMember]
        public int AuthorId { get; set; }

        [DataMember]
        public int TeamId { get; set; }

    }
}
