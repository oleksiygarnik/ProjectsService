using Agile.Application.Teams.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Teams.Commands.UpdateTeam
{
    [DataContract]
    public class UpdateTeamCommand : IRequest<TeamDTO>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }
    }
}
