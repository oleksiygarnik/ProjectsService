using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Tasks.Queries
{
    [DataContract]
    public class TasksByPerformerIdQuery : IRequest<IEnumerable<TaskDto>>
    {
        public int Id { get; set; }
    }
}
