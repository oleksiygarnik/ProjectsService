using Agile.Application.Tasks.Queries;
using Agile.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Projects.Queries
{
    public class ProjectDetailInformationDto
    {
        public ProjectDto Project { get; set; }
        public TaskDto LongestTask { get; set; }
        public TaskDto ShortestTask { get; set; }
        public int TeamCount { get; set; }
    }
}
