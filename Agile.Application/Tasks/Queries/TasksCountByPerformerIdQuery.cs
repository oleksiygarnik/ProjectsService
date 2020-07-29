using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Tasks.Queries
{
    [DataContract]
    public class TasksCountByPerformerIdQuery : IRequest<TasksCountByPerformerIdDto>
    {
        public int Id { get; set; }
    }
}
