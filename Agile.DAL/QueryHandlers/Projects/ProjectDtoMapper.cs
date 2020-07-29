using Agile.Application.Projects.Commands.AddProject;
using Agile.Application.Projects.Queries;
using Agile.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Infrastructure.QueryHandlers.Projects
{
    public class ProjectDtoMapper : Profile
    {
        public ProjectDtoMapper()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<AddProjectCommand, Project>();
            //CreateMap<TeamRecord, TeamDTO>();
        }
    }
}
