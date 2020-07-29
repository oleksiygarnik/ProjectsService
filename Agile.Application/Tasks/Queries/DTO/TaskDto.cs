using Agile.Application.Projects.Queries;
using Agile.Application.Users.Queries;
using Agile.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Tasks.Queries
{
    [DataContract]
    public class TaskDto
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
        public DateTime FinishedAt { get; set; }

        [DataMember]
        public TaskState TaskState { get; set; }

        [DataMember]
        public ProjectDto Project { get; set; }

        [DataMember]
        public UserDto Performer { get; set; }
    }
}
