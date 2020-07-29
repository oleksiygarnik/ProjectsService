using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Teams.Queries
{
    [DataContract]
    public class TeamByIdQuery : IRequest<TeamDTO>
    {
        [DataMember]
        public int Id { get; set; }
    }
}
