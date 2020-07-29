using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Teams.Commands.DeleteTeam
{
    [DataContract]
    public class DeleteTeamCommand : IRequest
    {
        public int Id { get; set; }
    }
}
