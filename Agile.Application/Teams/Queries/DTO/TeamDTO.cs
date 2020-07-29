using Agile.Application.Users.Queries;
using Agile.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Teams.Queries
{
    [DataContract]
    public class TeamDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public ICollection<UserDto> Members { get; set; }
    }
}
