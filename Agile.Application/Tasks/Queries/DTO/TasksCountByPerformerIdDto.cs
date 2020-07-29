using Agile.Application.Projects.Queries;
using Agile.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Tasks.Queries
{
    public class TasksCountByPerformerIdDto
    {
        public IDictionary<ProjectDto, int> Tasks { get; set; }
    }
}
