using Agile.Application.Tasks.Queries;
using Agile.Application.Teams.Queries;
using Agile.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Users.Queries
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public DateTime RegisteredAt { get; set; }

        [DataMember]
        public TeamDTO Team { get; set; }

        [DataMember]
        public ICollection<TaskDto> Task { get; set; }
    }
}
