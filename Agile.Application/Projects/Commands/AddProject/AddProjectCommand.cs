using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Projects.Commands.AddProject
{
    [DataContract]
    public class AddProjectCommand : IRequest<int>
    {

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
