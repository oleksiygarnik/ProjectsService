using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Teams.Commands.AddTeam
{
    [DataContract]
    public class AddTeamCommand : IRequest<int>
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

    }
}
