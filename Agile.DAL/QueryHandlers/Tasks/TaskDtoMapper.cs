using Agile.Application.Tasks.Commands.AddTask;
using Agile.Application.Tasks.Queries;
using Agile.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Infrastructure.QueryHandlers.Tasks
{
    public class TaskDtoMapper : Profile
    {
        public TaskDtoMapper()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<AddTaskCommand, Task>();
        }
    }
}
