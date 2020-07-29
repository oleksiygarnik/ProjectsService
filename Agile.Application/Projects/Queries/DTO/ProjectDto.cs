using Agile.Application.Teams.Queries;
using Agile.Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Projects.Queries
{
    [DataContract]
    public class ProjectDto
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
        public UserDto Author { get; set; } 

        [DataMember]
        public TeamDTO Team { get; set; }

    }
}
