using Agile.Application.Teams.Commands.AddTeam;
using Agile.Application.Teams.Queries;
using Agile.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Infrastructure.QueryHandlers.Teams
{
    public class TeamDtoMapper : Profile
    {
        public TeamDtoMapper()
        {
            CreateMap<Team, TeamDTO>();
            CreateMap<AddTeamCommand, Team>();
            CreateMap<TeamRecord, TeamDTO>();
        }
    }
}
