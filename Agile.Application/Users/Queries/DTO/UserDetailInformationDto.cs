using Agile.Application.Projects.Queries;
using Agile.Application.Tasks.Queries;
using Agile.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Users.Queries
{
    public class UserDetailInformationDto 
    {
        public UserDto User { get; set; }

        public ProjectDto LastProject { get; set; }

        public int TasksCount { get; set; }

        public int TasksCanceledCount { get; set; }

        public TaskDto LongestTask { get; set; }
    }
}
